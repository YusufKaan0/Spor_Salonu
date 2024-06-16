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

namespace SporSalonuTakip
{
    public partial class düzenle : Form
    {
        public düzenle()
        {
            InitializeComponent();
        }
        public int numara;
        SqlConnection baglanti = new SqlConnection(@"Data Source=KAAN;Initial Catalog=hediye;Integrated Security=True;Encrypt=False");
        private void button1_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("update detay set yagorani = @p1, belolcusu = @p2, kalcaolcusu = @p3",baglanti);
            komut.Parameters.AddWithValue("@p1", textBox1.Text);
            komut.Parameters.AddWithValue("@p2",textBox2.Text);
            komut.Parameters.AddWithValue("@p3",textBox3.Text);
            komut.ExecuteNonQuery();

            MessageBox.Show("Güncellendi");
            //Personel.Verialma();
        }
    }
}
