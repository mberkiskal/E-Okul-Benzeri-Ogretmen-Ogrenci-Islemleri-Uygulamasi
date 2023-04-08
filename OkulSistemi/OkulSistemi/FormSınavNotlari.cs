using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace OkulSistemi
{
    public partial class FormSınavNotlari : Form
    {
        public FormSınavNotlari()
        {
            InitializeComponent();
        }
        DataSet1TableAdapters.Table_NotlarTableAdapter ds = new DataSet1TableAdapters.Table_NotlarTableAdapter();
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-23T2RIK\\SQLEXPRESS;Initial Catalog=OkulSistemi;Integrated Security=True");

        int sınav1, sınav2, sınav3, proje;
        double ortalama;
        //string durum;
        int notId;
        private void btnara_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ds.NotListesi(int.Parse(txtid.Text));
        }

        private void FormSınavNotlari_Load(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand cmd = new SqlCommand("select*from Table_Dersler", baglanti);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            cmbders.DisplayMember = "DersAd";
            cmbders.ValueMember = "DersId";
            cmbders.DataSource = dt;
            baglanti.Close();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            notId =int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            txtid.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtsınav1.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            txtsınav2.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            txtsınav3.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            txtproje.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
            txtOrtalama.Text = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
            txtDurum.Text = dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString();
        }

        private void btnHesapla_Click(object sender, EventArgs e)
        {

            sınav1 = Convert.ToInt16(txtsınav1.Text);
            sınav2 = Convert.ToInt16(txtsınav2.Text);
            sınav3 = Convert.ToInt16(txtsınav3.Text);
            proje = Convert.ToInt16(txtproje.Text);
            ortalama = (sınav1 + sınav2 + sınav3 + proje)/4.00;
            txtOrtalama.Text=ortalama.ToString();
            if (ortalama >= 50)
            {
              
                txtDurum.Text = "True";
            }
            else
            {
                
                txtDurum.Text = "False";
            }
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            ds.DersGuncelle(byte.Parse(cmbders.SelectedValue.ToString()), int.Parse(txtid.Text), byte.Parse(txtsınav1.Text), byte.Parse(txtsınav2.Text), byte.Parse(txtsınav3.Text), (byte?)decimal.Parse(ortalama.ToString()), byte.Parse(txtproje.Text), bool.Parse(txtDurum.Text),notId);
           
        }
    }
}
