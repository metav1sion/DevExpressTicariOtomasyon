using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Mail;

namespace Ticari_Otomasyon
{
    public partial class FrmMail : Form
    {
        public FrmMail()
        {
            InitializeComponent();
        }

        public string mail;
        private void FrmMail_Load(object sender, EventArgs e)
        {
            txtMailAdres.Text = mail;
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btnGonder_Click(object sender, EventArgs e)
        {
            try
            {
                //Benim bu proje için oluşturduğum mail adresi.
                MailMessage mesaj = new MailMessage();
                SmtpClient istemci = new SmtpClient();
                istemci.Credentials = new System.Net.NetworkCredential("otomasyondeneme@outlook.com", "otomasyon123"); //kimlik
                istemci.Port = 587;
                istemci.Host = "smtp-mail.outlook.com";
                istemci.EnableSsl = true;
                mesaj.To.Add(txtMailAdres.Text);
                mesaj.From = new MailAddress("otomasyondeneme@outlook.com");
                mesaj.Subject = txtKonu.Text;
                mesaj.Body = txtMesaj.Text;
                istemci.Send(mesaj);

                MessageBox.Show("Mail başarıyla gönderildi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Mail gönderme işlemi sırasında hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
