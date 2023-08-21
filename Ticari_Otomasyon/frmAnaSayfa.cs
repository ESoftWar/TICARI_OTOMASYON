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
    public partial class frmAnaSayfa : Form
    {
        public frmAnaSayfa()
        {
            InitializeComponent();
        }
        ConSQL cnSql = new ConSQL();
        ListSQL lstSql = new ListSQL();

        void lst()
        {
            gridControl1.DataSource = lstSql.lstStoklarYirmi();
            gridControl2.DataSource = lstSql.lstAjanda();
            gridControl3.DataSource = lstSql.lstSonOn();
            gridControl4.DataSource = lstSql.lstFihrist();
            webBrowser2.Navigate("https://www.tcmb.gov.tr/kurlar/kurlar_tr.html");
        }
        private void frmAnaSayfa_Load(object sender, EventArgs e)
        {
            lst();
        }

        private void gridView2_DoubleClick(object sender, EventArgs e)
        {
            frmNotlarDetay fr = new frmNotlarDetay();
            DataRow dr = gridView2.GetDataRow(gridView2.FocusedRowHandle);
            if (dr != null)
            {
                fr.metin = dr["DETAY"].ToString();
                fr.Show();
            }
        }
    }
}
