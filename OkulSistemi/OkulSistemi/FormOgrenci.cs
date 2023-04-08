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
using System.CodeDom;

namespace OkulSistemi
{
    public partial class FormOgrenci : Form
    {
        public FormOgrenci()
        {
            InitializeComponent();
        }

        DataSet1TableAdapters.DataTable1TableAdapter ds = new DataSet1TableAdapters.DataTable1TableAdapter();
        
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-23T2RIK\\SQLEXPRESS;Initial Catalog=OkulSistemi;Integrated Security=True");
        
        string cinsiyet = "";
        
        private void label7_Click(object sender, EventArgs e)
        {

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

        private void FormOgrenci_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ds.OgrenciListesi();
            baglanti.Open();
            SqlCommand cmd = new SqlCommand("select*from Table_Kulupler",baglanti);
            SqlDataAdapter da= new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            cmbkulup.DisplayMember = "KulupAd";
            cmbkulup.ValueMember = "KulupId";
            cmbkulup.DataSource = dt;
            baglanti.Close();

        }

        private void btnekle_Click(object sender, EventArgs e)
        {
            
            if(radioButton1.Checked == true)
            {
                cinsiyet = "Erkek";
            }
            if (radioButton2.Checked == true)
            {
                cinsiyet = "Kadın";
            }

            ds.OgrenciEkle(txtad.Text, txtsoyad.Text, byte.Parse(cmbkulup.SelectedValue.ToString()), cinsiyet);
            MessageBox.Show("Öğrenci Başarıyla Eklendi!", "İşlem Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void btnlistele_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ds.OgrenciListesi();
        }

        private void cmbkulup_SelectedIndexChanged(object sender, EventArgs e)
        {
            //txtid.Text = cmbkulup.SelectedValue.ToString();
        }

        private void btnsil_Click(object sender, EventArgs e)
        {
            ds.OgrenciSil(int.Parse(txtid.Text));
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtid.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtad.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtsoyad.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            cinsiyet = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            cmbkulup.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            
            if (cinsiyet == "Erkek")
            {
                radioButton1.Checked= true;
               
            }
            if (cinsiyet == "Kadın")
            {
                radioButton2.Checked= true;
               
            }
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                cinsiyet = "Erkek";
            }
            if (radioButton2.Checked == true)
            {
                cinsiyet = "Kadın";
            }
            ds.OgrenciGuncelle(txtad.Text,txtsoyad.Text,byte.Parse(cmbkulup.SelectedValue.ToString()),cinsiyet,int.Parse(txtid.Text));
        }

        private void btnogrenciara_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource= ds.OgrenciFiltreleme(txtara.Text);

        }
    }
}
