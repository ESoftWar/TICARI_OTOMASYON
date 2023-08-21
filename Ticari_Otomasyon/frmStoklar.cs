using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ticari_Otomasyon
{
    public partial class frmStoklar : Form
    {
        public frmStoklar()
        {
            InitializeComponent();
        }
        ListSQL lstSql = new ListSQL();
        ConSQL cnSql = new ConSQL();

        void lst()
        {
            gridControl1.DataSource = lstSql.lstStok();
        }
        private void frmStoklar_Load(object sender, EventArgs e)
        {
            lst();

            //Charta stok miktarı listeleme

            SqlCommand cmd = new SqlCommand("SELECT URUNAD,SUM(ADET) AS ADET FROM TBL_URUNLER GROUP BY URUNAD", cnSql.connMSSQL());
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                chartControl1.Series["Series 1"].Points.AddPoint(dr["URUNAD"].ToString(), int.Parse(dr["ADET"].ToString()));
            }
            cnSql.connMSSQL().Close();
        }
    }
}
