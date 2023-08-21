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
    public partial class frmRehber : Form
    {
        public frmRehber()
        {
            InitializeComponent();
        }

        ConSQL cnSql = new ConSQL();
        ListSQL lstSql = new ListSQL();


        void lstMust()
        {
            //Grid Control' e dönen değerleri yolluyoruz.
            gridControl1.DataSource = lstSql.lstMusterilerRehber();
        }
        void lstFirma()
        {
            //Grid Control' e dönen değerleri yolluyoruz.
            gridControl2.DataSource = lstSql.lstFirmalarRehber();
        }

        
        private void frmRehber_Load(object sender, EventArgs e)
        {
            lstMust();
            lstFirma();
        }


        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            //Mail formumuzu tanımlıyoruz.
            frmMail frm = new frmMail();
            //Üstünde olan değerleri içeriyor.
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            //Kontrol,n, yaptırıyoruz.
            if (dr != null)
            {
                //Mail formundaki mail değerine atama işlemlerini gerçekleştiriyoruz.
                frm.mail = dr["MAIL"].ToString();
            }
            //Daha sonra da formu gösteriyoruz.
            frm.Show();
        }
        private void gridView2_DoubleClick(object sender, EventArgs e)
        {
            frmMail frm = new frmMail();
            DataRow dr = gridView2.GetDataRow(gridView2.FocusedRowHandle);

            if (dr != null)
            {
                frm.mail = dr["MAIL"].ToString();
            }
            frm.Show();
        }


    }
}
