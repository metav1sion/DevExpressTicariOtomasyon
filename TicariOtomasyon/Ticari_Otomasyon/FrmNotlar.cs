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
    public partial class FrmNotlar : Form
    {
        public FrmNotlar()
        {
            InitializeComponent();
        }

        sqlbaglantisi bgl = new sqlbaglantisi();

        void listele()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * From Tbl_Notlar3", bgl.baglanti());
            da.Fill(dt);
            gridControl1.DataSource = dt;
        }

        void temizle()
        {
            txtBaslik.Text = "";
            textHitap.Text = "";
            txtID.Text = "";
            textOluşturan.Text = "";
            txtDetay.Text = "";
            txtSaat.Text = "";
            txtTarih.Text = "";
        }

        private void FrmNotlar_Load(object sender, EventArgs e)
        {
            listele();

            temizle();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("insert into TBL_NOTLAR3 (TARIH,SAAT,BASLIK,DETAY,OLUSTURAN,HITAP) values (@P1,@P2,@P3,@P4,@P5,@P6)", bgl.baglanti());
            komut.Parameters.AddWithValue("@P1", txtTarih.Text);
            komut.Parameters.AddWithValue("@P2", txtSaat.Text);
            komut.Parameters.AddWithValue("@P3", txtBaslik.Text);
            komut.Parameters.AddWithValue("@P4", txtDetay.Text);
            komut.Parameters.AddWithValue("@P5", textOluşturan.Text);
            komut.Parameters.AddWithValue("@P6", textHitap.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            listele();
            MessageBox.Show("Not Bilgisi Siteme Eklendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("UPDATE TBL_NOTLAR set TARIH=@P1,SAAT=@P2,BASLIK=@P3,DETAY=@P4,OLUSTURAN=@P5,HITAP=@P6 where ID=@p7", bgl.baglanti());
            komut.Parameters.AddWithValue("@P1", txtTarih.Text);
            komut.Parameters.AddWithValue("@P2", txtSaat.Text);
            komut.Parameters.AddWithValue("@P3", txtBaslik.Text);
            komut.Parameters.AddWithValue("@P4", txtDetay.Text);
            komut.Parameters.AddWithValue("@P5", textOluşturan.Text);
            komut.Parameters.AddWithValue("@P6", textHitap.Text);
            komut.Parameters.AddWithValue("@P7", txtID.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            listele();
            MessageBox.Show("Not Bilgisi Güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);

            if (dr != null)
            {
                txtID.Text = dr["ID"].ToString();
                txtBaslik.Text = dr["BASLIK"].ToString();
                txtDetay.Text = dr["DETAY"].ToString();
                textOluşturan.Text = dr["OLUSTURAN"].ToString();
                textHitap.Text = dr["HITAP"].ToString();
                txtTarih.Text = dr["TARIH"].ToString();
                txtSaat.Text = dr["SAAT"].ToString();
            }
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Delete From TBl_Notlar Where ID=@p1", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", txtID.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Not Sistemden Silindi", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            listele();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            temizle();
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            FrmNotDetay fr = new FrmNotDetay();

            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);

            if (dr != null)
            {
                fr.detay = dr["DETAY"].ToString();
                fr.tarih = dr["TARIH"].ToString();
                fr.saat = dr["SAAT"].ToString();
                fr.oluşturan = dr["OLUSTURAN"].ToString();
                fr.hitap = dr["HITAP"].ToString();
                fr.başlık = dr["BASLIK"].ToString();
            }
            fr.Show();
        }
    }
}
