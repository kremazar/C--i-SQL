using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Zadatak
{
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
        }
        dbControl sql = new dbControl();
        void register()
        {
            sql.Param("username", txtUser.Text);
            sql.Param("password", txtPass.Text);
            sql.query("insert into korisnici (username,password) values(@username,@password)");
            if (sql.Check4error(true))
            {
                return;
            }
            MessageBox.Show("Registered","Success",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }
        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btnReg_Click(object sender, EventArgs e)
        {
            register();
            Form rf = new Form1();
            Hide();
            rf.ShowDialog();
        }

        private void Register_FormClosing(object sender, FormClosingEventArgs e)
        {
            foreach (Form frm in Application.OpenForms)
            {
                if (frm is Form1)
                {
                    frm.Show();
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void txtPass_TextChanged(object sender, EventArgs e)
        {
            txtPass.PasswordChar = '*';
        }
    }
}
