using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Assessment3;
using Assessment3.Encryptions;
using Assessment3.Encryptions.Interface;
using Assessment3.Readers.Abstract;
using Assessment3.SecurityRoles;
using Assessment3.SecurityRoles.Interface;

namespace Assessment3Test
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            textBox3.Enabled = false;
            textBox4.Enabled = false;
        
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox2.Checked)
            {
                textBox3.Enabled = true;
                textBox4.Enabled = true;
            }
            else
            {
                textBox3.Enabled = false;
                textBox4.Enabled = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            IEncryption encryption = null;
            ISecurityRole securityRole = null;
            AbstractReader reader = null;

            if (checkBox1.Checked)
            {
                encryption = new ReverseEncryption();
            }

            if(checkBox2.Checked)
            {
                securityRole = new ClassicSecurityRole();
            }

            reader = GetReaderByIndex(comboBox1.SelectedIndex, encryption, securityRole, textBox3.Text, textBox4.Text);

            textBox2.Text = reader.Read(textBox1.Text);
        }

        private AbstractReader GetReaderByIndex(int index, IEncryption encryption, ISecurityRole securityRole, string user, string role)
        {
            switch(index)
            {
                case 0: return new TextReader(encryption, securityRole, user, role);
                case 1: return new XmlReader(encryption, securityRole, user, role);
                case 2: return new JsonReader(encryption, securityRole, user, role);
                default: return null;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
