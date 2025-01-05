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

namespace _87.seçimekranı
{
    public partial class FrmOy1 : Form
    {
        public FrmOy1()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-PU4VJM0\\SQLEXPRESS;Initial Catalog=SECİM2023UDEMY;Integrated Security=True");
        private void btnoygiris_Click(object sender, EventArgs e)
        {
            // Eğer herhangi bir textbox boşsa
            if (string.IsNullOrWhiteSpace(textilce.Text) ||
                string.IsNullOrWhiteSpace(textA.Text) ||
                string.IsNullOrWhiteSpace(textB.Text) ||
                string.IsNullOrWhiteSpace(textC.Text) ||
                string.IsNullOrWhiteSpace(textD.Text) ||
                string.IsNullOrWhiteSpace(textE.Text))
            {
                MessageBox.Show("Lütfen tüm alanları doldurun.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; // SQL komutunu çalıştırmadan metoddan çık
            }

            baglanti.Open();
            SqlCommand komut = new SqlCommand("INSERT INTO TBLILCE (ILCEAD, APARTİSİ, BPARTİSİ, CPARTİSİ, DPARTİSİ, EPARTİSİ) VALUES (@P1, @P2, @P3, @P4, @P5, @P6)", baglanti);
            komut.Parameters.AddWithValue("@P1", textilce.Text);
            komut.Parameters.AddWithValue("@P2", textA.Text);
            komut.Parameters.AddWithValue("@P3", textB.Text);
            komut.Parameters.AddWithValue("@P4", textC.Text);
            komut.Parameters.AddWithValue("@P5", textD.Text);
            komut.Parameters.AddWithValue("@P6", textE.Text);

            komut.ExecuteNonQuery();
            MessageBox.Show("Başarılı");
            baglanti.Close();
        }


        private void btngrfik_Click(object sender, EventArgs e)
        {
            FrmGrafikler frm = new FrmGrafikler();
            frm.Show();
            

        }

        private void btncikis_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmOy1_Load(object sender, EventArgs e)
        {

        }

        
    }
}
