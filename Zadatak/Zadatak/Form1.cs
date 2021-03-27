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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        dbControl sql = new dbControl();
        private void button2_Click(object sender, EventArgs e)
        {
            Register rf = new Register();
            Hide();
            rf.ShowDialog();
        }

        bool Login()
        {
            sql.Param("@username",txtUser.Text);
            sql.Param("@password", txtPass.Text);
            sql.query("select count(*) from korisnici where username=@username and password=@password");
            if ((int)sql.dt.Rows[0][0]==1)
            {
                return true;
            }
            MessageBox.Show("Invalid username or password","Invalid",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
            return false;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (Login()==true)
            {
                Main mf = new Main();
                Hide();
                mf.ShowDialog();
            }
        }
    }
}
