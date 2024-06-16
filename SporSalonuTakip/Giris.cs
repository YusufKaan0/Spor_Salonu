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
    public partial class GrsEkran : Form
    {
        public GrsEkran()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            KayitOl frm = new KayitOl();
            this.Hide();
            frm.ShowDialog();
            this.Close();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=KAAN;Initial Catalog=hediye;Integrated Security=True;Encrypt=False");
        SqlCommand komut;
        SqlCommand komut2;
        SqlDataReader dr;
        SqlDataReader dy;
        private void button1_Click(object sender, EventArgs e)
        {
            komut = new SqlCommand("Select *  From Personel Where kullaniciadi='" + textBox1.Text + "'and sifre='" + textBox2.Text + "'", baglanti);
            komut2 = new SqlCommand("Select *  From Uye Where kullaniciadi='" + textBox1.Text + "'and sifre='" + textBox2.Text + "'", baglanti);
            baglanti.Open();
            dr = komut.ExecuteReader();

            bool oturum = false;
            if (dr.Read())
            {
                oturum = true;
                Personel frm = new Personel();
                this.Hide();
                frm.ShowDialog();
                this.Close();
            }
            dr.Close();
            dy = komut2.ExecuteReader();
                if (dy.Read())
                    {
                        oturum = true;
                        uye frm1 = new uye();
                        this.Hide();
                        frm1.ShowDialog();
                        this.Close();
                    }
            dy.Close();

            if (oturum == false)
            {
                MessageBox.Show("Kullanıcı Adı veya Şifre Yanlış");
            }
            baglanti.Close();
            komut.Dispose();
            komut2.Dispose();
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1.PerformClick();
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.CheckState == CheckState.Checked)
            {
                textBox2.UseSystemPasswordChar = true;
            }
            else
            {
                textBox2.UseSystemPasswordChar = false;
            }
        }

        private void checkBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1.PerformClick();
            }
        }

        private void GrsEkran_Load(object sender, EventArgs e)
        {

        }
    }
}
