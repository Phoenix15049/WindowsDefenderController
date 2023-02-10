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
            Microsoft.Win32.RegistryKey key;
            key = Microsoft.Win32.Registry.LocalMachine.CreateSubKey("Software\\Test",true);
            key.SetValue("Name", "Isabella");
            key.Close();


        }

        private void Start_Click(object sender, EventArgs e)
        {
            var rootreg = Registry.LocalMachine; //Registry.LocalMachine

            var str = "SOFTWARE\\AAA\\subkey1";
            var myRegistry = createAllSubkey(str, rootreg);

            var keyval = myRegistry.GetValue("log", "0").ToString();
            if (keyval != "1")
            {
                myRegistry.SetValue("log", 1, RegistryValueKind.DWord);
            }
            
            

            Console.WriteLine("Reg Added.");
            if(ServiceRun == true)
            {

                System.Diagnostics.Process.Start("CMD.exe", "/c net stop WinDefend");
                Srvce.Text = "Service is stopped ";
                Srvce.ForeColor = System.Drawing.Color.Red;
                ServiceRun = false;
            }
            else
            {
                System.Diagnostics.Process.Start("CMD.exe", "/c net start WinDefend");
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
