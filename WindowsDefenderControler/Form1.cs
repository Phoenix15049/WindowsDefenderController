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
            RegistryKey rk = Registry.CurrentUser.CreateSubKey("Computer\\HKEY_LOCAL_MACHINE\\SOFTWARE\\Microsoft\\Windows Defender");
            rk.SetValue("1", 0x00000001, RegistryValueKind.QWord);
        }

        private void Start_Click(object sender, EventArgs e)
        {

        }

        private void Help_Click(object sender, EventArgs e)
        {

        }
    }
}
