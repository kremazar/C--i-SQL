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
    public partial class Dodaj : Form
    {
        public Dodaj()
        {
            InitializeComponent();
        }
        dbControl sql = new dbControl();
        void dodajIgraca()
        {
            sql.Param("ime", textIme.Text);
            sql.Param("prezime", textPrezime.Text);
            sql.Param("pozicija", textPozicija.Text);
            sql.Param("klub", textKlub.Text);
            sql.query("insert into igrac (ime,prezime,pozicija,klub) values(@ime,@prezime,@pozicija,@klub)");
            if (sql.Check4error(true))
            {
                return;
            }
            MessageBox.Show("Dodan igrač!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnDodaj_Click(object sender, EventArgs e)
        {
            dodajIgraca();
            Hide();
        }

        
    }
}
