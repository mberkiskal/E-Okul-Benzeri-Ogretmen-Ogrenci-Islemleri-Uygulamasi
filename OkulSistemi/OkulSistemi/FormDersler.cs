using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OkulSistemi
{
    public partial class FormDersler : Form
    {
        public FormDersler()
        {
            InitializeComponent();
        }
        void liste() 
        {
            dataGridView1.DataSource = ds.DersListesi();
        }
        DataSet1TableAdapters.Table_DerslerTableAdapter ds = new DataSet1TableAdapters.Table_DerslerTableAdapter();
        private void FormDersler_Load(object sender, EventArgs e)
        {
            liste();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
           this.Close();
        }

        private void pictureBox6_MouseHover(object sender, EventArgs e)
        {
            pictureBox6.BackColor = Color.Red;
        }

        private void pictureBox6_MouseLeave(object sender, EventArgs e)
        {
            pictureBox6.BackColor = Color.Transparent;
        }

        private void btnlistele_Click(object sender, EventArgs e)
        {
            liste();
        }
        private void btnekle_Click(object sender, EventArgs e)
        {
            ds.DersEkle(txtdersad.Text);
            liste();
            MessageBox.Show("Ders Başarıyla Eklendi!", "İşlem Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void btnsil_Click(object sender, EventArgs e)
        {
            ds.DersSil(byte.Parse(txtdersid.Text));
            liste();
            MessageBox.Show("Ders Başarıyla Silindi!", "İşlem Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            ds.DersGuncelle(txtdersad.Text, byte.Parse(txtdersid.Text));
            liste();
            MessageBox.Show("Ders Başarıyla Güncellendi!", "İşlem Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtdersid.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtdersad.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
        }
    }
}
