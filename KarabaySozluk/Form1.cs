using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;


namespace KarabaySozluk
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=sozluk.accdb");
        OleDbCommand komut = new OleDbCommand();
        DataSet ds = new DataSet();



        private void Form1_Load(object sender, EventArgs e)
        {
            textBox1.Enabled = false;
            label2.Enabled = false;
          
   }

        private void button1_Click(object sender, EventArgs e)
        {
            string aranan = textBox1.Text;
            bool kelimeyok = true;

            if (textBox1.Text!="")
            {
                baglanti.Open();
                komut.CommandText = "SELECT * FROM ingilizce";
                komut.Connection = baglanti;
                OleDbDataReader oku = komut.ExecuteReader();
                if (radioButton1.Checked)
                {
                    while (oku.Read())
                    {
                        if (aranan==oku[0].ToString())
                        {
                            label2.Text = oku[1].ToString();
                            kelimeyok = false;
                        }
                        
                    }
                    
                }

                if (radioButton2.Checked)
                {
                    while (oku.Read())
                    {
                        if (aranan==oku[1].ToString())
                        {
                            label2.Text = oku[0].ToString();
                            kelimeyok = false;
                        }
                        
                    }
                    
                }

                oku.Close();
                baglanti.Close();

                if (kelimeyok)
                {
                    MessageBox.Show("Kelime Bulunamadı...");
                }
               
  }
            else
            {
                MessageBox.Show("Lütfen değer girdikten sonra ara butonuna basınız");
            }
  }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            textBox1.Enabled = true;
            label2.Enabled = true;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            textBox1.Enabled = true;
            label2.Enabled = true;
        }
    }
}
