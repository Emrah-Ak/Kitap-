
Bu uygulama windows forms (.Net framework) ile hazırlanmıştır. Uygulama masaüstü olmakla birlikte 
dil olarak C# kullanılmıştır. Uygulama bir kitapçı uygulamasıdır hem gelen ürünleri hem de satılan 
ürünlerin kayıtlarını yapmaktadır. 

Uygulamanın amacı hem satış yaptığımızda hem de yeni ürünler geldiğinde türüne göre listeleme yapılabilmesidir.
müşteri bilgileri de dahil olmak üzere hangi kitabın nereye satıldığına kadar bilgileri oluşturduğumuz localdb veri tabanı 
sayesinde tutabiliriz. 

Müşteri bilgileri ve Kitaplar hakkında tutulması gereken bilgiler bu veritabanı sayesinde sürekli olarak tutulabilecek ve 
istediğimiz zaman artık işimize yaramayacak olan kayıtları silmemizi sağlayacaktır

silinen eklenen ya da herhangi bir bilgisi yanlış girilen müşteriler veya kitapların yeniden bilgileri girilip güncellemelerini 
de yeniden yapılabilmektedir.



  SqlConnection baglantı = new SqlConnection
("Data Source = (LocalDB)\\MSSQLLocalDB; AttachDbFilename=|DataDirectory|\\Kitap.mdf;Integrated Security = True");
        public void Kayıtlar(string Kayıt)
        { SqlDataAdapter da = new SqlDataAdapter(Kayıt, baglantı);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }


        Bu kod parçağında yaptığımız uygulamanın local veritabanı ve datagridview kullanılarak veri tabanında oluşturduğumuz
        tabloları datagridview yardımıyla görüntülüyoruz tablolarımız listlenmiş bir şekilde kullanabiliyoruz.

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

            Bu alanda ise listlediğimiz kayıtlara yeni kayıt eklememizi sağlamaktadır EKLE adında oluştudurğumuz button kontrolü
            sayesinde yeni bir Müşteri kaydı oluşturduğumuzda  bu button sayesinde yeni kayıtlarımızı ekleyebiliriz.
             
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
            
            Silmek için önce ekledimiz Sİl adlı button kontrolünü sileceğimiz kaydın adını yazmamız yeterli olacaktır.
            button kontrolünün karşısında bulunan alana sileceğimiz kaydın adını yani müşterinin adını yazıp 
            sil Buttonunu kullanıyoruz.

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

               Yaptığımız işlemleri silme ekleme gibi işlemlerden sonra bu işlemlerin uygulama tarafından güncellenmesini sağlar.
               yaptığımız değişiklikler güncellenmiş bir şekilde tutulmaya devam eder.



               Bu uygulamada 2 tane tablo ve bu tablolara bağlı iki tane datagridview kullanılmıştır.
               uygulamaının form kısmında karşımıza iki tane liste çıkacaktır bu listelerden biri müşteri kayıtları,Ekleme,Silme ve
               Güncellemelerini yapacaktır.

               İkinci Listeleme kitaplar içindir burası da kitaplar için aynı işlemleri yapacaktır.

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
         
                Bu alanda da görülebileceği üzere datagridview2 yi kullanarak ekleme yaptığımız kod parçacığı tamamı zaten gözükecektir
                ama kısa anlatımlar olarak kabul edin.

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
           

            Bu parçada ise ikinci alan için silme işlemi yapacak olan button kontrolü için kullanıcak alan 

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
     
            Bu alan ise ikinci tabloda yapacağımız işlemlerin güncellemelerini yapmamızı sağlayacak olan button kontrolü
            kullanımı içindir.


 
    