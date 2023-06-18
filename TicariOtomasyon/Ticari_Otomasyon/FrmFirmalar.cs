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
    public partial class FrmFirmalar : Form
    {
        public FrmFirmalar()
        {
            InitializeComponent();
        }

        sqlbaglantisi bgl = new sqlbaglantisi();

        void firmalistesi()
        {
            SqlDataAdapter da = new SqlDataAdapter("Select * From TBL_FIRMALAR", bgl.baglanti());
            DataTable dt = new DataTable();
            da.Fill(dt);
            gridControl1.DataSource = dt;

        }

        void sehirlistesi()
        {
            SqlCommand komut = new SqlCommand("Select SEHIR From TBL_ILLER", bgl.baglanti());
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                comboIl.Properties.Items.Add(dr[0]);
            }
            bgl.baglanti().Close();
        }

        void carikodaciklamalar()
        {
            SqlCommand komut = new SqlCommand("Select FIRMAKOD1 from TBL_KODLAR", bgl.baglanti());
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                txtAnlam1.Text = dr[0].ToString();
            }
            bgl.baglanti().Close();
        }



        void temizle()
        {
            comboIl.Text = "";
            comboIlce.Text = "";
            txtAd.Text = "";
            txtID.Text = "";
            txtKod2.Text = "";
            txtKod3.Text = "";
            txtMail.Text = "";
            txtSektör.Text = "";
            txtVergiDairesi.Text = "";
            txtYetkiki.Text = "";
            txtYetkiliGorev.Text = "";
            txtFax.Text = "";
            txtTel1.Text = "";
            txtTel2.Text = "";
            txtTel3.Text = "";
            txtTC.Text = "";
            txtAdres.Text = "";
            txtKod1.Text = "";
            txtAd.Focus();
        }

        private void xtraTabPage1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void FrmFirmalar_Load(object sender, EventArgs e)
        {
            firmalistesi();

            sehirlistesi();

            carikodaciklamalar();

            temizle();
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);

            if (dr != null)
            {
                txtID.Text = dr["ID"].ToString();
                txtAd.Text = dr["AD"].ToString();
                txtYetkiliGorev.Text = dr["YETKILISTATU"].ToString();
                txtYetkiki.Text = dr["YETKILIADSOYAD"].ToString();
                txtTC.Text = dr["YETKILITC"].ToString();
                txtSektör.Text = dr["SEKTOR"].ToString();
                txtTel1.Text = dr["TELEFON1"].ToString();
                txtTel2.Text = dr["TELEFON2"].ToString();
                txtTel3.Text = dr["TELEFON3"].ToString();
                txtMail.Text = dr["MAIL"].ToString();
                txtFax.Text = dr["FAX"].ToString();
                comboIl.Text = dr["IL"].ToString();
                comboIlce.Text = dr["ILCE"].ToString();
                txtVergiDairesi.Text = dr["VERGIDAIRE"].ToString();
                txtAdres.Text = dr["ADRES"].ToString();
                txtKod1.Text = dr["OZELKOD1"].ToString();
                txtKod2.Text = dr["OZELKOD2"].ToString();
                txtKod3.Text = dr["OZELKOD3"].ToString();
            }
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("insert into TBL_FIRMALAR (AD,YETKILISTATU,YETKILIADSOYAD,YETKILITC,SEKTOR,TELEFON1,TELEFON2,TELEFON3,MAIL,FAX,IL,ILCE,VERGIDAIRE,ADRES,OZELKOD1,OZELKOD2,OZELKOD3) VALUES (@P1,@P2,@P3,@P4,@P5,@P6,@P7,@P8,@P9,@P10,@P11,@P12,@P13,@P14,@P15,@P16,@P17)", bgl.baglanti());
            komut.Parameters.AddWithValue("@P1", txtAd.Text);
            komut.Parameters.AddWithValue("@P2", txtYetkiliGorev.Text);
            komut.Parameters.AddWithValue("@P3", txtYetkiki.Text);
            komut.Parameters.AddWithValue("@P4", txtTC.Text);
            komut.Parameters.AddWithValue("@P5", txtSektör.Text);
            komut.Parameters.AddWithValue("@P6", txtTel1.Text);
            komut.Parameters.AddWithValue("@P7", txtTel2.Text);
            komut.Parameters.AddWithValue("@P8", txtTel3.Text);
            komut.Parameters.AddWithValue("@P9", txtMail.Text);
            komut.Parameters.AddWithValue("@P10", txtFax.Text);
            komut.Parameters.AddWithValue("@P11", comboIl.Text);
            komut.Parameters.AddWithValue("@P12", comboIlce.Text);
            komut.Parameters.AddWithValue("@P13", txtVergiDairesi.Text);
            komut.Parameters.AddWithValue("@P14", txtAdres.Text);
            komut.Parameters.AddWithValue("@P15", txtKod1.Text);
            komut.Parameters.AddWithValue("@P16", txtKod2.Text);
            komut.Parameters.AddWithValue("@P17", txtKod3.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Firma Sisteme Kaydedildi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            firmalistesi();
            temizle();
        }

        private void comboIl_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Select ILCE from TBL_ILCELER where SEHIR=@p1", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", comboIl.SelectedIndex + 1);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                comboIlce.Properties.Items.Add(dr[0]);
            }
            bgl.baglanti().Close();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Delete From TBL_FIRMALAR where ID=@p1", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", txtID.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            firmalistesi();
            MessageBox.Show("Firma listeden silindi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            temizle();
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Update TBL_FIRMALAR set AD=@P1,YETKILISTATU=@P2,YETKILIADSOYAD=@P3,YETKILITC=@P4,SEKTOR=@P5,TELEFON1=@P6,TELEFON2=@P7,TELEFON3=@P8,MAIL=@P9,IL=@P11,ILCE=@P12,FAX=@P10,VERGIDAIRE=@P13,ADRES=@P14,OZELKOD1=@P15,OZELKOD2=@P16,OZELKOD3=@P17 WHERE ID=@P18", bgl.baglanti());
            komut.Parameters.AddWithValue("@P1", txtAd.Text);
            komut.Parameters.AddWithValue("@P2", txtYetkiliGorev.Text);
            komut.Parameters.AddWithValue("@P3", txtYetkiki.Text);
            komut.Parameters.AddWithValue("@P4", txtTC.Text);
            komut.Parameters.AddWithValue("@P5", txtSektör.Text);
            komut.Parameters.AddWithValue("@P6", txtTel1.Text);
            komut.Parameters.AddWithValue("@P7", txtTel2.Text);
            komut.Parameters.AddWithValue("@P8", txtTel3.Text);
            komut.Parameters.AddWithValue("@P9", txtMail.Text);
            komut.Parameters.AddWithValue("@P10", txtFax.Text);
            komut.Parameters.AddWithValue("@P11", comboIl.Text);
            komut.Parameters.AddWithValue("@P12", comboIlce.Text);
            komut.Parameters.AddWithValue("@P13", txtVergiDairesi.Text);
            komut.Parameters.AddWithValue("@P14", txtAdres.Text);
            komut.Parameters.AddWithValue("@P15", txtKod1.Text);
            komut.Parameters.AddWithValue("@P16", txtKod2.Text);
            komut.Parameters.AddWithValue("@P17", txtKod3.Text);
            komut.Parameters.AddWithValue("@P18", txtID.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Firma Bilgileri Güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            firmalistesi();
            temizle();
        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            temizle();
        }
    }
}
