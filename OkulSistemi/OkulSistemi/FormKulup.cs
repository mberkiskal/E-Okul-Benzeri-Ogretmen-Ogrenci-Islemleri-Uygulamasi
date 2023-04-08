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

namespace OkulSistemi
{
    public partial class FormKulup : Form
    {
        public FormKulup()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-23T2RIK\\SQLEXPRESS;Initial Catalog=OkulSistemi;Integrated Security=True");

        void listele()
        {
            SqlDataAdapter dataAdapter = new SqlDataAdapter("select * from Table_Kulupler", baglanti);
            DataTable dt = new DataTable();
            dataAdapter.Fill(dt);
            dataGridView1.DataSource = dt;
        }
        private void FormKulup_Load(object sender, EventArgs e)
        {
            listele();
        }

        private void btnlistele_Click(object sender, EventArgs e)
        {
            listele();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand cmd = new SqlCommand("insert into Table_Kulupler (KulupAd) values (@p1)",baglanti);
            cmd.Parameters.AddWithValue("@p1", txtkulupad.Text);
            cmd.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Kulüp Başarıyla Oluşturuldu!", "İşlem Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            listele();
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

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtkulupid.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtkulupad.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand cmd2 = new SqlCommand("delete from Table_Kulupler where KulupId=@p2", baglanti);
            cmd2.Parameters.AddWithValue("@p2", txtkulupid.Text);
            cmd2.ExecuteNonQuery();
            baglanti.Close() ;
            MessageBox.Show("Kulüp Başarıyla Silindi!", "İşlem Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            listele();
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand cmd3 = new SqlCommand("update Table_Kulupler set KulupAd=@g1 where KulupId=@g2", baglanti);
            cmd3.Parameters.AddWithValue("@g1", txtkulupad.Text);
            cmd3.Parameters.AddWithValue("@g2", txtkulupid.Text);
            cmd3.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Kulüp Başarıyla Güncellendi!", "İşlem Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            listele();
        }
    }
}
