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

namespace SporSalonuTakip
{
    public partial class uye : Form
    {
        
        public uye()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection(@"Data Source=KAAN;Initial Catalog=hediye;Integrated Security=True;Encrypt=False");


        private void button2_Click(object sender, EventArgs e)
        {
            GrsEkran frm = new GrsEkran();
            frm.Show();
        }

        private void uye_Load(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut1 = new SqlCommand("SELECT SUM(karbonhidrat),SUM(protein),SUM(yag) FROM besin", baglanti);
            SqlDataReader dr = komut1.ExecuteReader();
            while (dr.Read())
            {
                chart1.Series["Besinler"].Points.AddXY("karbonhidrat", dr[0]);
                chart1.Series["Besinler"].Points.AddXY("protein", dr[1]);
                chart1.Series["Besinler"].Points.AddXY("yag", dr[2]);
            }
            baglanti.Close();
        }
    


        private void button4_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("insert into besin (karbonhidrat,protein,yag) values (@p1,@p2,@p3)",baglanti);
            komut.Parameters.AddWithValue("@p1",textBox1.Text);
            komut.Parameters.AddWithValue("@p2", textBox2.Text);
            komut.Parameters.AddWithValue("@p3",textBox3.Text);
            komut.ExecuteNonQuery();
            MessageBox.Show("Bilgiler Eklendi");
            baglanti.Close();


        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

    }
}
