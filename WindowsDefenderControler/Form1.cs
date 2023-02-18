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
            DialogResult dr = new DialogResult();
            dr = MessageBox.Show("Disabling Windows Defender Antivirus can increase the risk of your Windows receiving viruses. So try not to disable this antivirus as much as possible.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.None);
            ServiceRun = true;
            Srvce.Text = "Service is running";
            Srvce.ForeColor = System.Drawing.Color.Green;
           


        }

        private void Start_Click(object sender, EventArgs e)
        {
  
            
            if(ServiceRun == true)
            {
                System.Diagnostics.Process.Start("CMD.exe", "/c net stop WinDefend");
                Srvce.Text = "Service is stopped ";
                Srvce.ForeColor = System.Drawing.Color.Red;
                ServiceRun = false;
                Console.WriteLine("Reg Added.");
            }
            else
            {
                System.Diagnostics.Process.Start("CMD.exe", "/c net start WinDefend");
                Srvce.Text = "Service is running ";
                Srvce.ForeColor = System.Drawing.Color.Green;
                ServiceRun = true;
                Console.WriteLine("Reg Added.");
            }
            
        }

        private void Help_Click(object sender, EventArgs e)
        {
            DialogResult dr = new DialogResult();
            dr = MessageBox.Show("To use this software, just click on the Start/Stop button to activate or deactivate the service. The initial status of your antivirus service is detected by this software, which you can control by clicking on it.", "Help", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
