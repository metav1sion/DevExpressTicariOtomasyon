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

namespace Ticari_Otomasyon
{
    public partial class FrmFaturaUrunDuzenleme : Form
    {
        public FrmFaturaUrunDuzenleme()
        {
            InitializeComponent();
        }

        void listele()
        {
            SqlCommand komut = new SqlCommand("Select * From tbl_faturadetay where FaturaUrunID=@p1", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", urunid);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                txtFiyat.Text = dr[3].ToString();
                txtMiktar.Text = dr[2].ToString();
                txtTutar.Text = dr[4].ToString();
                txtUrunAd.Text = dr[1].ToString();

                bgl.baglanti().Close();
            }
        }

        sqlbaglantisi bgl = new sqlbaglantisi();

        public string urunid;
        private void FrmFaturaUrunDuzenleme_Load(object sender, EventArgs e)
        {
            txtUrunID.Text = urunid;
            listele();
            
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            

            double miktar, tutar, fiyat;
            fiyat = Convert.ToDouble(txtFiyat.Text);
            miktar = Convert.ToDouble(txtMiktar.Text);
            tutar = miktar * fiyat;
            txtTutar.Text = tutar.ToString();

            SqlCommand komut = new SqlCommand("update tbl_faturadetay set URUNADI=@P1,MIKTAR=@P2,FIYAT=@P3,TUTAR=@P4 WHERE FATURAURUNID=@P5", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", txtUrunAd.Text);
            komut.Parameters.AddWithValue("@p2", txtMiktar.Text);
            komut.Parameters.AddWithValue("@p3", decimal.Parse(txtFiyat.Text));
            komut.Parameters.AddWithValue("@p4", decimal.Parse(txtTutar.Text));
            komut.Parameters.AddWithValue("@p5", txtUrunID.Text);

            

            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Değişiklikler Kaydedildi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            this.Owner.Close();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Delete From Tbl_FaturaDetay where FATURAURUNID=@p1", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", txtUrunID.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Ürün Silindi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Question);
        }
    }
}
