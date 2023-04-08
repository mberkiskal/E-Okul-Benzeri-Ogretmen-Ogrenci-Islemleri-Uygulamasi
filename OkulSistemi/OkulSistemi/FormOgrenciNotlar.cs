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
    public partial class FormOgrenciNotlar : Form
    {
        public FormOgrenciNotlar()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-23T2RIK\\SQLEXPRESS;Initial Catalog=OkulSistemi;Integrated Security=True");
        public string numara;
        public string adsoyad;
        private void FormOgrenciNotlar_Load(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("select DersAd, Sınav1, Sınav2, Sınav3, Proje, Ortalama, Durum from Table_Notlar inner join Table_Dersler on Table_Notlar.DersId=Table_Dersler.DersId where OgrenciId=@p1", baglanti);
            cmd.Parameters.AddWithValue("@p1", numara);
            //this.Text=numara.ToString();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }
    }
}
