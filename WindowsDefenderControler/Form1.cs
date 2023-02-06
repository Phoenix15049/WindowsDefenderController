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
        public Main()
        {
            InitializeComponent();
        }
        void CRegistryDemoDlg::OnBnClickedSet()
        {
            // TODO: Add your control notification handler code here
            CRegKey reg;

            HKEY m_hKeyParent = HKEY_CURRENT_USER;

            //Here I Was wrong while giving path
            LPCTSTR m_myKey = L"Software\\MyRegDemo";

            reg.Create(m_hKeyParent, m_myKey);

            if (reg.Open(m_hKeyParent, m_myKey) == ERROR_SUCCESS)
            {
                DWORD data = 1;
                reg.SetDWORDValue(L"Test", data);
                reg.Close();
            }
        }

        void CRegistryDemoDlg::OnBnClickedGet()
        {
            // TODO: Add your control notification handler code here
            CRegKey reg;
            HKEY m_hkeyParent = HKEY_CURRENT_USER;

            //Here I Was wrong while giving path
            LPCTSTR m_myKey = L"Software\\MyRegDemo";
            DWORD dvalue;
            if (reg.Open(m_hkeyParent, m_myKey) == ERROR_SUCCESS)
            {
                reg.QueryDWORDValue(L"Test", dvalue);
                reg.Close();
            }
            if (dvalue == 1)
                m_chkbox1.SetCheck(true);
            else
                m_chkbox1.SetCheck(false);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void Start_Click(object sender, EventArgs e)
        {

        }

        private void Help_Click(object sender, EventArgs e)
        {

        }
    }
}
