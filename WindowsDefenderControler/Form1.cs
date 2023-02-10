using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsDefenderControler
{
    public partial class Main : Form
    {
        bool ServiceRun;
        //Computer\HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows Defender
        public Main()
        {
            InitializeComponent();
        }

        
        static RegistryKey createAllSubkey(string completeSubkey, RegistryKey rootreg)
        {
            RegistryKey _rtrn = null;
            StringBuilder sb = new StringBuilder();
            var stepreg = rootreg;
            var stestr = "";
            
            foreach (var item in completeSubkey.Split('\\'))
            {
                if (item != "")
                {
                    try
                    {

                        stestr += item + @"\";
                        var reg = stepreg.OpenSubKey(item, true);
                        if (reg == null)
                        {
                            stepreg.CreateSubKey(item);
                            stepreg = stepreg.OpenSubKey(item, true);
                        }
                        else
                        {
                            stepreg = stepreg.OpenSubKey(item, true);
                        }
                    }
                    catch (Exception exc)
                    {
                        Console.WriteLine(exc.Message);
                    }
                }
                _rtrn = stepreg;
            }

            return _rtrn;
        }



        private void Form1_Load(object sender, EventArgs e)
        {
            ServiceRun = true;
            Srvce.Text = "Service is running";
            Srvce.ForeColor = System.Drawing.Color.Green;


            //using (RegistryKey key = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\IDG"))

            //{

            //    key.SetValue("Key 1", "Value 1");

            //    key.SetValue("Key 2", "Value 2");

            //    key.Close();

            //}




            // Create a subkey named Test9999 under HKEY_CURRENT_USER.
            RegistryKey test9999 =
                Registry.CurrentUser.CreateSubKey("Test9999");
            // Create two subkeys under HKEY_CURRENT_USER\Test9999. The
            // keys are disposed when execution exits the using statement.
            using (RegistryKey
                testName = test9999.CreateSubKey("TestName"),
                testSettings = test9999.CreateSubKey("TestSettings"))
            {
                // Create data for the TestSettings subkey.
                testSettings.SetValue("Language", "French");
                testSettings.SetValue("Level", "Intermediate");
                testSettings.SetValue("ID", 123);
            }

            // Print the information from the Test9999 subkey.
            Console.WriteLine("There are {0} subkeys under {1}.",
                test9999.SubKeyCount.ToString(), test9999.Name);
            foreach (string subKeyName in test9999.GetSubKeyNames())
            {
                using (RegistryKey
                    tempKey = test9999.OpenSubKey(subKeyName))
                {
                    Console.WriteLine("\nThere are {0} values for {1}.",
                        tempKey.ValueCount.ToString(), tempKey.Name);
                    foreach (string valueName in tempKey.GetValueNames())
                    {
                        Console.WriteLine("{0,-8}: {1}", valueName,
                            tempKey.GetValue(valueName).ToString());
                    }
                }
            }

            

        }

        private void Start_Click(object sender, EventArgs e)
        {
            var rootreg = Registry.CurrentUser; //Registry.LocalMachine

            var str = @"SOFTWARE\Test\subkey1";
            var myRegistry = createAllSubkey(str, rootreg);

            var keyval = myRegistry.GetValue("log", "0").ToString();
            if (keyval != "1")
            {
                myRegistry.SetValue("log", 1, RegistryValueKind.DWord);
            }
            Console.Read();
            Console.WriteLine("Reg Added.");
            if(ServiceRun == true)
            {
                Srvce.Text = "Service is stopped ";
                Srvce.ForeColor = System.Drawing.Color.Red;
                ServiceRun = false;
            }
            else
            {
                Srvce.Text = "Service is running ";
                Srvce.ForeColor = System.Drawing.Color.Green;
                ServiceRun = true;
            }
            
        }

        private void Help_Click(object sender, EventArgs e)
        {

        }
    }
}
