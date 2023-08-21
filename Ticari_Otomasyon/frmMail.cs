using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//Mail isim uzayı
using System.Net.Mail;
namespace Ticari_Otomasyon
{
    public partial class frmMail : Form
    {
        public frmMail()
        {
            InitializeComponent();
        }
        public string mail;
        private void frmMail_Load(object sender, EventArgs e)
        {
            txtMail.Text = mail;
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            try
            {
                //Mail mesaj bilgilerimizi tutacak sınıfı tanımlıyoruz.
                MailMessage mesajım = new MailMessage();
                //İstemci bilgilerini tutup iletişimi sağlayacak bilgileri tutuyoruz.
                SmtpClient istemci = new SmtpClient();
                //E posta yollayacağımız hesabı tanımlıyoruz.
                istemci.Credentials = new System.Net.NetworkCredential("mail", "sifre");
                //Türkiyede port 
                istemci.Port = 587;
                //Türkiyede host
                istemci.Host = "smtp-mail.outlook.com";
                //Mesajları şifrelesin
                istemci.EnableSsl = true;
                //Göndereceğimiz mail adresini ekliyoruz.
                mesajım.To.Add(txtMail.Text);
                //Kimden gönderileceği
                mesajım.From = new MailAddress("mail");
                //Mesajın Konusu
                mesajım.Subject = txtKonu.Text;
                //Mesajın kendisi
                mesajım.Body = rtbMesaj.Text;
                //Ve gönder
                istemci.Send(mesajım);
                //Bilgi ver.
                MessageBox.Show("Mesajınız başarı ile gönderildi.", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);


                //E posta gönderilmesi için e postayı göndereceğimiz hesabın doğrulanmış olması gerekir.
            }
            catch (Exception)
            {
                MessageBox.Show("Lütfen e posta hesabınızı doğrulayınız. Doğruluğundan eminseniz yollayacağınız e posta adresini doğru yazdığınızdan emin olun. Sorun çözülmediyse ESoftWar ile irtibata geçiniz.", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }
    }
}
