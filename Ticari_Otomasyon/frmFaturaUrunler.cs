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
    public partial class frmFaturaUrunler : Form
    {
        public frmFaturaUrunler()
        {
            InitializeComponent();
        }
        ConSQL cnSql = new ConSQL();
        ListSQL lstSql = new ListSQL();
        

        public int id;
        public string urunAd,miktar,fiyat,tutar,urunId;

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            frmFaturaUrunUpdt fr = new frmFaturaUrunUpdt();
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            if (dr!=null)
            {
                fr.urunId = dr["FATURAURUNID"].ToString();
            }
            fr.Show();
        }

        public void lst()
        {
            gridControl1.DataSource = lstSql.lstFaturaD(id);
        }

        
        private void frmFaturaUrunler_Load(object sender, EventArgs e)
        {
            lst();
        }

    }
}
