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
    public partial class FrmMusteriler : Form
    {


        public FrmMusteriler()
        {
            InitializeComponent();
        }

        sqlbaglantisi bgl = new sqlbaglantisi();

        void listele()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * From TBL_MUSTERILER", bgl.baglanti());
            da.Fill(dt);
            gridControl1.DataSource = dt;
        }

        void sehirlistesi() //İlleri getirme
        {
            SqlCommand komut = new SqlCommand("Select SEHIR From TBL_ILLER", bgl.baglanti());
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                comboIl.Properties.Items.Add(dr[0]);
            }
            bgl.baglanti().Close();
        }

        private void labelControl10_Click(object sender, EventArgs e)
        {

        }

        private void FrmMusteriler_Load(object sender, EventArgs e)
        {
            listele();

            sehirlistesi();
        }

        private void comboIl_SelectedIndexChanged(object sender, EventArgs e) //İlçeleri Getirme
        {
            comboIlce.Properties.Items.Clear();

            SqlCommand komut = new SqlCommand("Select ILCE from TBL_ILCELER where SEHIR=@p1", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", comboIl.SelectedIndex + 1); //COMBOBOX indeksleri 0'dan başlıyor fakat şehir ID'leri 1'den başlıyor.
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                comboIlce.Properties.Items.Add(dr[0]);
            }
            bgl.baglanti().Close();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            txtAd.Text = "";
            txtID.Text = "";
            txtMail.Text = "";
            txtSoyad.Text = "";
            textVergiDairesi.Text = "";
            textTC.Text = "";
            txtTel1.Text = "";
            textTel2.Text = "";
            comboIl.Text = "";
            comboIlce.Text = "";
            txtAdres.Text = "";
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Delete from TBL_MUSTERILER where ID=@p1", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", txtID.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Müşteri Silindi", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            listele();
            txtAd.Text = "";
            txtID.Text = "";
            txtMail.Text = "";
            txtSoyad.Text = "";
            textVergiDairesi.Text = "";
            textTC.Text = "";
            txtTel1.Text = "";
            textTel2.Text = "";
            comboIl.Text = "";
            comboIlce.Text = "";
            txtAdres.Text = "";
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            if (dr != null)
            {
                txtID.Text = dr["ID"].ToString();
                txtAd.Text = dr["AD"].ToString();
                txtSoyad.Text = dr["SOYAD"].ToString();
                txtTel1.Text = dr["TELEFON"].ToString();
                textTel2.Text = dr["TELEFON2"].ToString();
                textTC.Text = dr["TC"].ToString();
                txtMail.Text = dr["MAIL"].ToString();
                comboIl.Text = dr["IL"].ToString();
                comboIlce.Text = dr["ILCE"].ToString();
                textVergiDairesi.Text = dr["VERGIDAIRE"].ToString();
                txtAdres.Text = dr["ADRES"].ToString();
            }
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("insert into TBL_MUSTERILER (AD,SOYAD,TELEFON,TELEFON2,TC,MAIL,IL,ILCE,ADRES,VERGIDAIRE) values (@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9,@p10)", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", txtAd.Text);
            komut.Parameters.AddWithValue("@p2", txtSoyad.Text);
            komut.Parameters.AddWithValue("@p3", txtTel1.Text);
            komut.Parameters.AddWithValue("@p4", textTel2.Text);
            komut.Parameters.AddWithValue("@p5", textTC.Text);
            komut.Parameters.AddWithValue("@p6", txtMail.Text);
            komut.Parameters.AddWithValue("@p7", comboIl.Text);
            komut.Parameters.AddWithValue("@p8", comboIlce.Text);
            komut.Parameters.AddWithValue("@p9", txtAdres.Text);
            komut.Parameters.AddWithValue("@p10", textVergiDairesi.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Müşteri Sisteme Eklendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            listele();
            txtAd.Text = "";
            txtID.Text = "";
            txtMail.Text = "";
            txtSoyad.Text = "";
            textVergiDairesi.Text = "";
            textTC.Text = "";
            txtTel1.Text = "";
            textTel2.Text = "";
            comboIl.Text = "";
            comboIlce.Text = "";
            txtAdres.Text = "";
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("update TBL_MUSTERILER set AD=@P1,SOYAD=@P2,TELEFON=@P3,TELEFON2=@P4,TC=@P5,MAIL=@P6,IL=@P7,ILCE=@P8,VERGIDAIRE=@P9,ADRES=@P10 where ID=@P11", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", txtAd.Text);
            komut.Parameters.AddWithValue("@p2", txtSoyad.Text);
            komut.Parameters.AddWithValue("@p3", txtTel1.Text);
            komut.Parameters.AddWithValue("@p4", textTel2.Text);
            komut.Parameters.AddWithValue("@p5", textTC.Text);
            komut.Parameters.AddWithValue("@p6", txtMail.Text);
            komut.Parameters.AddWithValue("@p7", comboIl.Text);
            komut.Parameters.AddWithValue("@p8", comboIlce.Text);
            komut.Parameters.AddWithValue("@p9", textVergiDairesi.Text);
            komut.Parameters.AddWithValue("@p10", txtAdres.Text);
            komut.Parameters.AddWithValue("@p11", txtID.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Müşteri Bilgileri Güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            listele();
        }
    }
}
