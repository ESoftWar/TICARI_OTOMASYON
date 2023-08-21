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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public string kullanici;
        public bool yetki;
        

        private void Form1_Load(object sender, EventArgs e)
        {
            if (frmAna == null)
            {
                frmAna = new frmAnaSayfa();
                frmAna.MdiParent = this;
                frmAna.Show();
            }
            if (yetki==true)
            {
                MessageBox.Show("Hoşgeldin " + kullanici + " . Yetki Türü : Üst Düzey Yetki", "ESoftWar İyi Günler Diler...:)", MessageBoxButtons.OK);
            }
            else if(yetki==false)
            {
                MessageBox.Show("Hoşgeldin " + kullanici + " . Yetki Türü : Sınırlı Yetki", "ESoftWar İyi Günler Diler...:)", MessageBoxButtons.OK);
                btnNotlar.Enabled = false;
                btnAyarlar.Enabled = false;
            }
            else
            {
                MessageBox.Show("Hoşgeldin " + kullanici + " . Yetki Türü : Yetki Yok", "ESoftWar İyi Günler Diler...:)", MessageBoxButtons.OK);
                btnAnaSayfa.Enabled = false;
                btnUrunler.Enabled = false;
                btnStoklar.Enabled = false;
                btnMusteriler.Enabled = false;
                btnFirmalar.Enabled = false;
                btnPersoneller.Enabled = false;
                btnGiderler.Enabled = false;
                btnKasa.Enabled = false;
                btnNotlar.Enabled=false;
                btnBankalar.Enabled = false;
                btnRehber.Enabled = false;
                btnFaturalar.Enabled = false;
                btnHareket.Enabled = false;
                btnRaporlar.Enabled = false;
                btnAyarlar.Enabled=false;

            }
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }


        //Form ile ilgili işlem yapabilmek için formu tanımlıyoruz.
        frmUrunler frmUrun;
        private void btnUrunler_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            //Tekrara düşmesin diye bir kez açıldıysa eğer bir daha açma diyoruz.
            if (frmUrun == null || frmUrun.IsDisposed) 
            {
                frmUrun = new frmUrunler();
                //MdiManager' in MdiParent özelliğine instance ımızı yolluroyuruz.
                frmUrun.MdiParent = this;
                //Formumuzu gösteriyoruz.
                frmUrun.Show();
            }

        }

        frmMusteriler frmMusteri;
        private void btnMusteriler_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //Tekrara düşmesin diye bir kez açıldıysa eğer bir daha açma diyoruz.
            if (frmMusteri == null || frmMusteri.IsDisposed)
            {
                frmMusteri = new frmMusteriler();
                //MdiManager' in MdiParent özelliğine instance ımızı yolluroyuruz.
                frmMusteri.MdiParent = this;
                //Formumuzu gösteriyoruz.
                frmMusteri.Show();
            }
        }

        frmFirmalar frmFirma;
        private void btnFirmalar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //Tekrara düşmesin diye bir kez açıldıysa eğer bir daha açma diyoruz.
            if (frmFirma == null || frmFirma.IsDisposed)
            {
                frmFirma = new frmFirmalar();
                //MdiManager' in MdiParent özelliğine instance ımızı yolluroyuruz.
                frmFirma.MdiParent = this;
                //Formumuzu gösteriyoruz.
                frmFirma.Show();
            }
        }

        frmPersoneller frmPersonel;
        private void btnPersoneller_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //Tekrara düşmesin diye bir kez açıldıysa eğer bir daha açma diyoruz.
            if (frmPersonel == null || frmPersonel.IsDisposed)
            {
                frmPersonel = new frmPersoneller();
                //MdiManager' in MdiParent özelliğine instance ımızı yolluroyuruz.
                frmPersonel.MdiParent = this;
                //Formumuzu gösteriyoruz.
                frmPersonel.Show();
            }
        }
        
        frmRehber frmRehb;
        private void btnRehber_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //Tekrara düşmesin diye bir kez açıldıysa eğer bir daha açma diyoruz.
            if (frmRehb == null || frmRehb.IsDisposed)
            {
                frmRehb = new frmRehber();
                //MdiManager' in MdiParent özelliğine instance ımızı yolluroyuruz.
                frmRehb.MdiParent = this;
                //Formumuzu gösteriyoruz.
                frmRehb.Show();
            }
        }

        frmGiderler frmGider;
        private void btnGiderler_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //Tekrara düşmesin diye bir kez açıldıysa eğer bir daha açma diyoruz.
            if (frmGider == null || frmGider.IsDisposed)
            {
                frmGider = new frmGiderler();
                //MdiManager' in MdiParent özelliğine instance ımızı yolluroyuruz.
                frmGider.MdiParent = this;
                //Formumuzu gösteriyoruz.
                frmGider.Show();
            }
        }

        frmBankalar frmBanka;
        private void btnBankalar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //Tekrara düşmesin diye bir kez açıldıysa eğer bir daha açma diyoruz.
            if (frmBanka == null || frmBanka.IsDisposed)
            {
                frmBanka = new frmBankalar();
                //MdiManager' in MdiParent özelliğine instance ımızı yolluroyuruz.
                frmBanka.MdiParent = this;
                //Formumuzu gösteriyoruz.
                frmBanka.Show();
            }
        }

        frmFaturalar frmFatura;
        private void btnFaturalar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (frmFatura == null || frmFatura.IsDisposed)
            {
                frmFatura = new frmFaturalar();
                frmFatura.MdiParent = this;
                frmFatura.Show();
            }
        }

        frmNotlar frmNot;
        private void btnNotlar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (frmNot == null || frmNot.IsDisposed)
            {
                frmNot = new frmNotlar();
                frmNot.MdiParent = this;
                frmNot.Show();
            }
        }

        frmHareketler frmHareket;
        private void btnHareket_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (frmHareket == null || frmHareket.IsDisposed)
            {
                frmHareket = new frmHareketler();
                frmHareket.MdiParent = this;
                frmHareket.Show();
            }
        }

        frmRaporlar frmRapor;
        private void btnRapor_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (frmRapor == null || frmRapor.IsDisposed)
            {
                frmRapor = new frmRaporlar();
                frmRapor.MdiParent = this;
                frmRapor.Show();
            }
        }

        frmStoklar frmStok;
        private void btnStoklar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (frmStok == null || frmStok.IsDisposed)
            {
                frmStok = new frmStoklar();
                frmStok.MdiParent = this;
                frmStok.Show();
            }
        }

        frmAyarlar frmAyar;
        private void btnAyarlar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
                
                frmAyar = new frmAyarlar();
                frmAyar.Show();
        }

        frmKasa frmK;
        private void btnKasa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (frmK == null || frmK.IsDisposed)
            {
                frmK = new frmKasa();
                frmK.ad = kullanici;
                frmK.MdiParent = this;
                frmK.Show();
                
            }
        }

        frmAnaSayfa frmAna;
        private void btnAnaSayfa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (frmAna == null || frmAna.IsDisposed)
            {
                frmAna = new frmAnaSayfa();
                frmAna.MdiParent = this;
                frmAna.Show();

            }
        }
    }
}
