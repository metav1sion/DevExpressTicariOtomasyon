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
    public partial class FrmFaturalar : Form
    {
        public FrmFaturalar()
        {
            InitializeComponent();
        }
        sqlbaglantisi bgl = new sqlbaglantisi();

        void listele()
        {
            SqlDataAdapter da = new SqlDataAdapter("Select * from TBL_FATURABILGI", bgl.baglanti());
            DataTable dt = new DataTable();
            da.Fill(dt);
            gridControl1.DataSource = dt;
        }

        void Temizle()
        {
            txtAlıcı.Text = "";
            txtID.Text = "";
            txtSeri.Text = "";
            txtSıra.Text = "";
            txtTeslimAlan.Text = "";
            txtTeslimEden.Text = "";
            txtVergi.Text = "";
            txtSaat.Text = "";
            txtTarih.Text = "";
        }

        private void groupControl3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void labelControl15_Click(object sender, EventArgs e)
        {

        }

        private void FrmFaturalar_Load(object sender, EventArgs e)
        {
            listele();
            Temizle();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if (txtFaturaID.Text == "")
            {
                SqlCommand komut = new SqlCommand("insert into TBL_FATURABILGI (SERI,SIRANO,TARIH,SAAT,VERGIDAIRE,ALICI,TESLIMEDEN,TESLIMALAN) VALUES (@P1,@P2,@P3,@P4,@P5,@P6,@P7,@P8)", bgl.baglanti());
                komut.Parameters.AddWithValue("@P1", txtSeri.Text);
                komut.Parameters.AddWithValue("@P2", txtSıra.Text);
                komut.Parameters.AddWithValue("@P3", txtTarih.Text);
                komut.Parameters.AddWithValue("@P4", txtSaat.Text);
                komut.Parameters.AddWithValue("@P5", txtVergi.Text);
                komut.Parameters.AddWithValue("@P6", txtAlıcı.Text);
                komut.Parameters.AddWithValue("@P7", txtTeslimEden.Text);
                komut.Parameters.AddWithValue("@P8", txtTeslimAlan.Text);
                komut.ExecuteNonQuery();
                bgl.baglanti().Close();
                MessageBox.Show("Fatura Bilgisi Sisteme Kaydedildi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                listele();
            }

            if(txtFaturaID.Text != "")
            {
                double miktar, tutar, fiyat;
                fiyat = Convert.ToDouble(txtFiyat.Text);
                miktar = Convert.ToDouble(txtMiktar.Text);
                tutar = miktar * fiyat;
                txtTutar.Text = tutar.ToString();
                SqlCommand komut2 = new SqlCommand("insert into TBL_FATURADETAY (URUNADI,MIKTAR,FIYAT,TUTAR,FATURAID) VALUES (@P1,@P2,@P3,@P4,@P5)", bgl.baglanti());
                komut2.Parameters.AddWithValue("@P1",txtUrunAd.Text);
                komut2.Parameters.AddWithValue("@P2", txtMiktar.Text);
                komut2.Parameters.AddWithValue("@P3", txtFiyat.Text);
                komut2.Parameters.AddWithValue("@P4", txtTutar.Text);
                komut2.Parameters.AddWithValue("@P5", txtFaturaID.Text);
                komut2.ExecuteNonQuery();
                bgl.baglanti().Close();
                MessageBox.Show("Faturaya ait ürün kaydedildi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);

            if (dr != null)
            {
                txtID.Text = dr["FATURABILGIID"].ToString();
                txtSıra.Text = dr["SIRANO"].ToString();
                txtSeri.Text = dr["SERI"].ToString();
                txtTarih.Text = dr["TARIH"].ToString();
                txtSaat.Text = dr["SAAT"].ToString();
                txtAlıcı.Text = dr["ALICI"].ToString();
                txtTeslimEden.Text = dr["TESLIMEDEN"].ToString();
                txtTeslimAlan.Text = dr["TESLIMALAN"].ToString();
                txtVergi.Text = dr["VERGIDAIRE"].ToString();
            }
        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            Temizle();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Delete From tbl_FATURABILGI where FATURABILGIID=@p1", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", txtID.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Fatura Silindi", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Question);
            listele();
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("update TBL_FATURABILGI set SERI=@P1,SIRANO=@P2,TARIH=@P3,SAAT=@P4,VERGIDAIRE=@P5,ALICI=@P6,TESLIMEDEN=@P7,TESLIMALAN=@P8 WHERE FATURABILGIID=@P9", bgl.baglanti());
            komut.Parameters.AddWithValue("@P1", txtSeri.Text);
            komut.Parameters.AddWithValue("@P2", txtSıra.Text);
            komut.Parameters.AddWithValue("@P3", txtTarih.Text);
            komut.Parameters.AddWithValue("@P4", txtSaat.Text);
            komut.Parameters.AddWithValue("@P5", txtVergi.Text);
            komut.Parameters.AddWithValue("@P6", txtAlıcı.Text);
            komut.Parameters.AddWithValue("@P7", txtTeslimEden.Text);
            komut.Parameters.AddWithValue("@P8", txtTeslimAlan.Text);
            komut.Parameters.AddWithValue("@P9", txtID.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Fatura Bilgisi Güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            listele();
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            FrmFaturaUrunDetay fr = new FrmFaturaUrunDetay();
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);

            if (dr != null)
            {
                fr.id = dr["FATURABILGIID"].ToString(); //diğer forma id bilgisini attık
            }
            fr.Show();
        }
    }
}
