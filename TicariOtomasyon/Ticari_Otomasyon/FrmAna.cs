using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ticari_Otomasyon
{
    public partial class FrmAna : Form
    {
        public FrmAna()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        


        FrmUrunler fr;

        private void btnÜrünler_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if(fr==null) //sekmeye her bastığımızda açılmasını önlemek için
            {
                fr = new FrmUrunler();
                fr.MdiParent = this; //mdi parent eklentisini kullanabilmek için
                fr.Show();
            }
            if (fr != null) //sekmeye her bastığımızda açılmasını önlemek için
            {
                fr.Close();
                fr = new FrmUrunler();
                fr.MdiParent = this; //mdi parent eklentisini kullanabilmek için
                fr.Show();
            }

        }

        FrmMusteriler fr2;
        private void btnMüşteriler_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr2 == null) //sekmeye her bastığımızda açılmasını önlemek için
            {
                fr2 = new FrmMusteriler();
                fr2.MdiParent = this; //mdi parent eklentisini kullanabilmek için
                fr2.Show();
            }
            if (fr2 != null) //kapattıktan sonra tekrar açabilmek için
            {
                fr2.Close();
                fr2 = new FrmMusteriler();
                fr2.MdiParent = this; //mdi parent eklentisini kullanabilmek için
                fr2.Show();
            }

        }

        FrmFirmalar fr3;
        private void btnFirmalar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr3 == null) //sekmeye her bastığımızda açılmasını önlemek için
            {
                fr3 = new FrmFirmalar();
                fr3.MdiParent = this; //mdi parent eklentisini kullanabilmek için
                fr3.Show();
            }
            if (fr3 != null) //kapattıktan sonra tekrar açabilmek için
            {
                fr3.Close();
                fr3 = new FrmFirmalar();
                fr3.MdiParent = this; //mdi parent eklentisini kullanabilmek için
                fr3.Show();
            }
        }

        FrmPersonel fr4;
        private void barButtonItem6_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr4 == null) //sekmeye her bastığımızda açılmasını önlemek için
            {
                fr4 = new FrmPersonel();
                fr4.MdiParent = this; //mdi parent eklentisini kullanabilmek için
                fr4.Show();
            }
            if (fr4 != null) //sekmeye her bastığımızda açılmasını önlemek için
            {
                fr4.Close();
                fr4 = new FrmPersonel();
                fr4.MdiParent = this; //mdi parent eklentisini kullanabilmek için
                fr4.Show();
            }
        }

        FrmRehber fr5;
        private void btnRehber_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr5 == null) //sekmeye her bastığımızda açılmasını önlemek için
            {
                fr5 = new FrmRehber();
                fr5.MdiParent = this; //mdi parent eklentisini kullanabilmek için
                fr5.Show();
            }
            if (fr5 != null) //sekmeye her bastığımızda açılmasını önlemek için
            {
                fr5.Close();
                fr5 = new FrmRehber();
                fr5.MdiParent = this; //mdi parent eklentisini kullanabilmek için
                fr5.Show();
            }
        }

        FrmGiderler fr6;
        private void btnGiderler_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr6 == null) //sekmeye her bastığımızda açılmasını önlemek için
            {
                fr6 = new FrmGiderler();
                fr6.MdiParent = this; //mdi parent eklentisini kullanabilmek için
                fr6.Show();
            }
            if (fr6 != null) //sekmeye her bastığımızda açılmasını önlemek için
            {
                fr6.Close();
                fr6 = new FrmGiderler();
                fr6.MdiParent = this; //mdi parent eklentisini kullanabilmek için
                fr6.Show();
            }
        }

        FrmBankalar fr7;
        private void btnBankalar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr7 == null) //sekmeye her bastığımızda açılmasını önlemek için
            {
                fr7 = new FrmBankalar();
                fr7.MdiParent = this; //mdi parent eklentisini kullanabilmek için
                fr7.Show();
            }
            if (fr7 != null) //sekmeye her bastığımızda açılmasını önlemek için
            {
                fr7.Close();
                fr7 = new FrmBankalar();
                fr7.MdiParent = this; //mdi parent eklentisini kullanabilmek için
                fr7.Show();
            }
        }

        FrmFaturalar fr8;
        private void btnFaturalar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr8 == null) //sekmeye her bastığımızda açılmasını önlemek için
            {
                fr8 = new FrmFaturalar();
                fr8.MdiParent = this; //mdi parent eklentisini kullanabilmek için
                fr8.Show();
            }
            if (fr8 != null) //sekmeye her bastığımızda açılmasını önlemek için
            {
                fr8.Close();
                fr8 = new FrmFaturalar();
                fr8.MdiParent = this; //mdi parent eklentisini kullanabilmek için
                fr8.Show();
            }
        }

        FrmNotlar fr9;
        private void btnNotlar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr9 == null) //sekmeye her bastığımızda açılmasını önlemek için
            {
                fr9 = new FrmNotlar();
                fr9.MdiParent = this; //mdi parent eklentisini kullanabilmek için
                fr9.Show();
            }
            if (fr9 != null) //sekmeye her bastığımızda açılmasını önlemek için
            {
                fr9.Close();
                fr9 = new FrmNotlar();
                fr9.MdiParent = this; //mdi parent eklentisini kullanabilmek için
                fr9.Show();
            }
        }

        FrmHareketler fr10;
        private void btnHareketler_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr10 == null) //sekmeye her bastığımızda açılmasını önlemek için
            {
                fr10 = new FrmHareketler();
                fr10.MdiParent = this; //mdi parent eklentisini kullanabilmek için
                fr10.Show();
            }
            if (fr10 != null) //sekmeye her bastığımızda açılmasını önlemek için
            {
                fr10.Close();
                fr10 = new FrmHareketler();
                fr10.MdiParent = this; //mdi parent eklentisini kullanabilmek için
                fr10.Show();
            }
        }

        FrmStoklar fr12;
        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr12 == null) //sekmeye her bastığımızda açılmasını önlemek için
            {
                fr12 = new FrmStoklar();
                fr12.MdiParent = this;//mdi parent eklentisini kullanabilmek için
                fr12.Show();
            }
            if (fr12 != null) //sekmeye her bastığımızda açılmasını önlemek için
            {
                fr12.Close();
                fr12 = new FrmStoklar();
                fr12.MdiParent = this;
                fr12.Show();
            }
        }

        FrmAyarlar fr13;
        private void btnAyarlar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr13 == null) //sekmeye her bastığımızda açılmasını önlemek için
            {
                fr13 = new FrmAyarlar();
                fr13.Show();
            }
            if (fr13 != null) //sekmeye her bastığımızda açılmasını önlemek için
            {
                fr13.Close();
                fr13 = new FrmAyarlar();
                fr13.Show();
            }
        }
    }
}
