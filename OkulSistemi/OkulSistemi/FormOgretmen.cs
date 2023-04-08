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
    public partial class FormOgretmen : Form
    {
        public FormOgretmen()
        {
            InitializeComponent();
        }


        private void button2_Click(object sender, EventArgs e)
        {
            FormKulup fr = new FormKulup();
            fr.Show();

        }

        private void btnders_Click(object sender, EventArgs e)
        {
            FormDersler fr = new FormDersler();
            fr.Show();
        }

        private void btnOgrenciIslemleri_Click(object sender, EventArgs e)
        {
            FormOgrenci frm= new FormOgrenci(); 
            frm.Show();
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FormSınavNotlari frm= new FormSınavNotlari();
            frm.Show();
        }
    }
}
