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
    public partial class FrmNotDetay : Form
    {
        public FrmNotDetay()
        {
            InitializeComponent();
        }
        public string tarih;
        public string saat;
        public string oluşturan;
        public string hitap;
        public string detay;
        public string başlık;

        private void FrmNotDetay_Load(object sender, EventArgs e)
        {
            txtTarih.Text = tarih;
            txtSaat.Text = saat;
            textOluşturan.Text = oluşturan;
            textHitap.Text = hitap;
            txtDetay.Text = detay;
            txtBaslik.Text = başlık;
        }
    }
}
