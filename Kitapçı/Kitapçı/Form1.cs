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

namespace Kitapçı
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        SqlConnection baglantı = new SqlConnection
("Data Source = (LocalDB)\\MSSQLLocalDB; AttachDbFilename=|DataDirectory|\\Kitap.mdf;Integrated Security = True");
        public void Kayıtlar(string Kayıt)
        { SqlDataAdapter da = new SqlDataAdapter(Kayıt, baglantı);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }

        public void display_data()

        {
            baglantı.Open();
            SqlCommand cmd = baglantı.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Select * from Müşteriler";
            cmd.ExecuteNonQuery();
            DataTable dta = new DataTable();
            SqlDataAdapter dataadp = new SqlDataAdapter(cmd);
            dataadp.Fill(dta);
            dataGridView1.DataSource = dta;
            baglantı.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Kayıtlar("select * from Müşteri");
            Ürünler("select*from Kitaplar");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            baglantı.Open();
            SqlCommand Ekle = new SqlCommand("Insert into Müşteri  values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox6.Text + "','" + textBox7.Text + "')", baglantı);
            Ekle.ExecuteNonQuery();
            Kayıtlar("Select*from Müşteri");
            baglantı.Close();
            MessageBox.Show("kayıt başarılı");
            Form1_Load(null, null);
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
           


        }

        private void button3_Click(object sender, EventArgs e)
        {
            baglantı.Open();
            SqlCommand Sil = baglantı.CreateCommand();
            Sil.CommandType = CommandType.Text;
            Sil.CommandText = "delete from Müşteri where Adı='" + textBox8.Text + "'";
            Sil.ExecuteNonQuery();
            baglantı.Close();
            textBox1.Text = "";           
            textBox2.Text = "";
            textBox3.Text = ""; 
            textBox4.Text = ""; 
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            MessageBox.Show("Başarılı");
            Form1_Load(null, null);
            


        }

        private void button4_Click(object sender, EventArgs e)
        {
            {
                baglantı.Open();
                SqlCommand Güncelleme = baglantı.CreateCommand();
                Güncelleme.CommandType = CommandType.Text;
                Güncelleme.CommandText = "update  Müşteri set Adı='" + textBox2.Text + "' where Adı='" + textBox3.Text + "'";
                Güncelleme.ExecuteNonQuery();
                baglantı.Close();
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
                textBox6.Text = "";
                textBox7.Text = "";
                Form1_Load(null, null);
                MessageBox.Show("Başarılı");
                
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: Bu kod satırı 'kitapDataSet1.Kitaplar' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
            this.kitaplarTableAdapter.Fill(this.kitapDataSet1.Kitaplar);
            // TODO: Bu kod satırı 'kitapDataSet.Müşteri' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
            this.müşteriTableAdapter.Fill(this.kitapDataSet.Müşteri);

        }


        SqlConnection baglan= new SqlConnection
("Data Source = (LocalDB)\\MSSQLLocalDB; AttachDbFilename=|DataDirectory|\\Kitap.mdf;Integrated Security = True");
        public void Ürünler(string Ürün)
        {
            SqlDataAdapter da = new SqlDataAdapter(Ürün, baglan);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView2.DataSource = ds.Tables[0];
        }
        
        private void button5_Click(object sender, EventArgs e)
        {
            {
                baglan.Open();
                SqlCommand KitapEkle = new SqlCommand("Insert into Kitaplar  values('" + textBox9.Text + "','" + textBox10.Text + "','" + textBox11.Text + "','" + textBox12.Text + "','" + textBox13.Text + "')", baglan);
               KitapEkle.ExecuteNonQuery();
                Ürünler("Select*from Kitaplar");
                baglan.Close();
                MessageBox.Show("kayıt başarılı");
                Form1_Load(null, null);
                textBox9.Text = "";
                textBox10.Text = "";
                textBox11.Text = "";
                textBox12.Text = "";
                textBox13.Text = "";
               
           }

          

            {
                baglan.Open();
                SqlCommand cmd = baglan.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "Select * from Kitaplar";
                cmd.ExecuteNonQuery();
                DataTable dta = new DataTable();
                SqlDataAdapter dataadp = new SqlDataAdapter(cmd);
                dataadp.Fill(dta);
                dataGridView2.DataSource = dta;
                baglan.Close();

                
            }


        }

        private void button6_Click(object sender, EventArgs e)
        {
            {
                baglan.Open();
                SqlCommand Silme = baglan.CreateCommand();
                Silme.CommandType = CommandType.Text;
                Silme.CommandText = "delete from Kitaplar where Adı='" + textBox14.Text + "'";
                Silme.ExecuteNonQuery();
                baglan.Close();
                textBox9.Text = "";
                textBox10.Text = "";
                textBox11.Text = "";
                textBox12.Text = "";
                textBox13.Text = "";
                display_data();
                MessageBox.Show("Başarılı");
            }

        }

        private void button7_Click(object sender, EventArgs e)
        {
            {
                baglan.Open();
                SqlCommand Güncelle = baglan.CreateCommand();
                Güncelle.CommandType = CommandType.Text;
                Güncelle.CommandText = "update Kitaplar set Adı='" + textBox9.Text + "' where Adı='" + textBox10.Text + "'";
                Güncelle.ExecuteNonQuery();
                baglan.Close();
                textBox9.Text = "";
                textBox10.Text = "";
                textBox11.Text = "";
                textBox12.Text = "";
                textBox13.Text = "";

                display_data();
                MessageBox.Show("Başarılı");
            }

        }
    }

    }

