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
    public partial class Prijava : Form
    {
        public Prijava()
        {
            InitializeComponent();
        }
        dbControl sql = new dbControl();
        private void button2_Click(object sender, EventArgs e)
        {
            Registracija rf = new Registracija();
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
                Igraci mf = new Igraci();
                Hide();
                mf.ShowDialog();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            txtPass.PasswordChar = '*';
        }
    }
}
