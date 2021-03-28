using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace Zadatak
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        dbControl sql = new dbControl();
        public int IgracID;
        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            foreach (Form frm in Application.OpenForms)
            {
                if (frm is Form1)
                {
                    frm.Show();
                }
            }
        }

       

        private void Main_Load(object sender, EventArgs e)
        {
            getIgraci();
        }

        private void getIgraci()
        {
            sql.query2("select * from igrac");
            pregledIgracaGrid.DataSource = sql.ds.Tables[0];
        }

        private void btnDodaj_Click(object sender, EventArgs e)
        {
            dodajIgraca();
        }
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
            getIgraci();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (isValid())
            {
                if (IgracID > 0)
                {
                    sql.Param("ime", textIme.Text);
                    sql.Param("prezime", textPrezime.Text);
                    sql.Param("pozicija", textPozicija.Text);
                    sql.Param("klub", textKlub.Text);
                    sql.Param("id", this.IgracID);
                    sql.query("update  igrac set ime=@ime,prezime=@prezime,pozicija=@pozicija,klub=@klub WHERE id=@id");
                    if (sql.Check4error(true))
                    {
                        return;
                    }
                    MessageBox.Show("Podaci izmjenjeni!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    getIgraci();
                    Reset();
                }
                else
                {
                    MessageBox.Show("Označi podatak kojeg želiš izmjeniti!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
        private bool isValid()
        {
            if (textIme.Text == string.Empty && textPrezime.Text == string.Empty && textPozicija.Text == string.Empty && textKlub.Text == string.Empty)
            {
                MessageBox.Show("Obavezan unos", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            return true;
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            Reset();
        }
        private void Reset()
        {
            textIme.Clear();
            textPrezime.Clear();
            textPozicija.Clear();
            textKlub.Clear();

            textIme.Focus();
        }

        private void pregledIgracaGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            IgracID = Convert.ToInt32(pregledIgracaGrid.SelectedRows[0].Cells[0].Value);
            textIme.Text = pregledIgracaGrid.SelectedRows[0].Cells[1].Value.ToString();
            textPrezime.Text = pregledIgracaGrid.SelectedRows[0].Cells[2].Value.ToString();
            textPozicija.Text = pregledIgracaGrid.SelectedRows[0].Cells[3].Value.ToString();
            textKlub.Text = pregledIgracaGrid.SelectedRows[0].Cells[4].Value.ToString();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (IgracID > 0)
            {
                sql.Param("id", this.IgracID);
                sql.query("delete from igrac WHERE id=@id");
                if (sql.Check4error(true))
                {
                    return;
                }
                MessageBox.Show("Podaci obrisani!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                getIgraci();
                Reset();
            }
            else
            {
                MessageBox.Show("Označi podatak kojeg želiš obrisati!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

     
    }
}
