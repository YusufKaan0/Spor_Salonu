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
    
    public partial class Personel : Form
    {
        static public string abonelik;

        public Personel()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=KAAN;Initial Catalog=hediye;Integrated Security=True;Encrypt=False");
        public void Verialma()
        {
            SqlDataAdapter da = new SqlDataAdapter("execute Ben",baglanti);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

       

        void UyeDuzenle()
        {
            SqlDataAdapter da3 = new SqlDataAdapter("select * from uye",baglanti);
            DataTable dt3 = new DataTable();
            da3.Fill(dt3);
            comboBox2.ValueMember = "id";
            comboBox2.DisplayMember = "adsoyad";
            comboBox2.DataSource = dt3;
        }

        

        private void Personel_Load(object sender, EventArgs e)
        {
            Verialma();
            UyeDuzenle();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            
        }

        private void fillByToolStripButton_Click(object sender, EventArgs e)
        {
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            düzenle frm2 = new düzenle();
            frm2.numara = comboBox2.SelectedIndex;
            frm2.Show();
        }
    }
}

