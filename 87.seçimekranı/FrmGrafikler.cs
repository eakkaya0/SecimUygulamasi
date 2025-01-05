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
    public partial class FrmGrafikler : Form
    {
        public FrmGrafikler()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-PU4VJM0\\SQLEXPRESS;Initial Catalog=SECİM2023UDEMY;Integrated Security=True"); //baglanti
        private void FrmGrafikler_Load(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select ILCEAD FROM TBLILCE", baglanti); //komutla ilceleri alma
            SqlDataReader dr = komut.ExecuteReader(); //sql veri okuma
            while(dr.Read())
            {
                comboBox1.Items.Add(dr[0]);
            }
            baglanti.Close();

            baglanti.Open();

            SqlCommand komut2 = new SqlCommand("select SUM(APARTİSİ), SUM(BPARTİSİ), sum(CPARTİSİ), SUM(DPARTİSİ), SUM(EPARTİSİ) FROM TBLILCE", baglanti);
            SqlDataReader dr2 = komut2.ExecuteReader();
            while(dr2.Read())
            {
                chart1.Series["Partiler"].Points.AddXY("A PARTİSİ", dr2[0]);
                chart1.Series["Partiler"].Points.AddXY("B PARTİSİ.", dr2[1]);
                chart1.Series["Partiler"].Points.AddXY("C PARTİSİ", dr2[2]);
                chart1.Series["Partiler"].Points.AddXY("D PARTİSİ", dr2[3]);
                chart1.Series["Partiler"].Points.AddXY("E PARTİSİ", dr2[4]);
            }
            baglanti.Close();



        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Select * FROM TBLILCE WHERE ILCEAD=@P1",baglanti);
            komut.Parameters.AddWithValue("@P1", comboBox1.Text);
            SqlDataReader dr = komut.ExecuteReader();
            while(dr.Read())
            {
                progressBar1.Value = Convert.ToInt32(dr[2]);
                progressBar2.Value = Convert.ToInt32(dr[3]);
                progressBar3.Value = Convert.ToInt32(dr[4]);
                progressBar4.Value = Convert.ToInt32(dr[5]);
                progressBar5.Value = Convert.ToInt32(dr[6]);


                lblA.Text = dr[2].ToString();
                lblB.Text = dr[3].ToString();
                lblC.Text = dr[4].ToString();
                lblD.Text = dr[5].ToString();
                lblE.Text = dr[6].ToString();
               
            }

            baglanti.Close();
        }

       
    }
}
