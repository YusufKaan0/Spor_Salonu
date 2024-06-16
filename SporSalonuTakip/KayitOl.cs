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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;

namespace SporSalonuTakip
{
    public partial class KayitOl : Form
    {
        public KayitOl()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=KAAN;Initial Catalog=hediye;Integrated Security=True;Encrypt=False");
        

        private void button1_Click_1(object sender, EventArgs e)
        {

            SqlCommand komut2 = new SqlCommand("insert into iletisim (telefon) values (@p4)", baglanti);
            komut2.Parameters.AddWithValue("@p4", textBox1.Text);
            baglanti.Open();
            komut2.ExecuteNonQuery();
            baglanti.Close();

            baglanti.Open();
            SqlCommand komutselect = new SqlCommand("select id from iletisim where telefon = @tel", baglanti);
            komutselect.Parameters.AddWithValue("@tel", textBox1.Text);
            komutselect.ExecuteNonQuery();
            komutselect.CommandText = "select id from iletisim where telefon = @tel";
            int id = (int)komutselect.ExecuteScalar();
            baglanti.Close();


            SqlCommand komut3 = new SqlCommand("insert into uye (adsoyad,kullaniciadi,sifre) values (@p6,@p7,@p8)", baglanti);
            komut3.Parameters.AddWithValue("@p6", txtAdSoyad.Text);
            komut3.Parameters.AddWithValue("@p7", txtKad.Text);
            komut3.Parameters.AddWithValue("@p8", txtSifre.Text);
            baglanti.Open();
            komut3.ExecuteNonQuery();
            baglanti.Close();


            baglanti.Open();
            SqlCommand komutselect2 = new SqlCommand("select id from uye where adsoyad = @as", baglanti);
            komutselect2.Parameters.AddWithValue("@as", txtAdSoyad.Text);
            komutselect2.ExecuteNonQuery();
            komutselect2.CommandText = "select id from uye where adsoyad = @as";
            int id2 = (int)komutselect2.ExecuteScalar();
            baglanti.Close();

            SqlCommand komut = new SqlCommand("insert into detay (cinsiyet,yas,kilo,boy,uye,iletisim) values (@p1,@p2,@p3,@p5,@p6,@p7)", baglanti);
            komut.Parameters.AddWithValue("@p1", txtcinsiyet.SelectedItem);
            komut.Parameters.AddWithValue("@p2",txtYas.Text);
            komut.Parameters.AddWithValue("@p3",txtKilo.Text);
            komut.Parameters.AddWithValue("@p5",txtBoy.Text);
            komut.Parameters.AddWithValue("@p6", id2);
            komut.Parameters.AddWithValue("@p7",id);
            baglanti.Open();
            komut.ExecuteNonQuery();
            baglanti.Close();






          


       
            MessageBox.Show("Başarılı Bir Şekilde Kayıt Oldunuz.");
        }

        private void txtSifre_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1.PerformClick();
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
                GrsEkran frm = new GrsEkran();
                this.Hide();
                frm.ShowDialog();
                this.Close();
            
        }
    }
}
