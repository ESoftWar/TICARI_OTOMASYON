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
    public partial class frmKasa : Form
    {
        public frmKasa()
        {
            InitializeComponent();
        }
        ConSQL cnSql = new ConSQL();
        ListSQL lstSQL = new ListSQL();

        void lst()
        {
            gridControl1.DataSource = lstSQL.lstMusteriHareketler();
            gridControl3.DataSource = lstSQL.lstFirmaHareketler();
            gridControl2.DataSource = lstSQL.lstGiderler();
            
        }
        
        void toplamT()
        {
            SqlCommand cmd = new SqlCommand("SELECT SUM(TUTAR) AS TOPLAMTUTAR FROM TBL_FATURADETAY", cnSql.connMSSQL());
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                lblTotal.Text = dr[0].ToString() + " TL";
            }
            cnSql.connMSSQL().Close();
        }
        void toplamM()
        {
            SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM TBL_MUSTERILER",cnSql.connMSSQL());
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                lblMusS.Text = dr[0].ToString();
            }
            cnSql.connMSSQL().Close();
        }
        void toplamF()
        {
            SqlCommand cmd = new SqlCommand("SELECT COUNT(DISTINCT (AD)) FROM TBL_FIRMALAR ", cnSql.connMSSQL());
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                lblFirmaS.Text = dr[0].ToString();
            }
            cnSql.connMSSQL().Close();
        }
        void toplamMS()
        {
            SqlCommand cmd = new SqlCommand("SELECT COUNT(DISTINCT (IL)) FROM TBL_MUSTERILER ", cnSql.connMSSQL());
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                lblMusteriSehirS.Text = dr[0].ToString();
            }
            cnSql.connMSSQL().Close();
        }
        void toplamFS()
        {
            SqlCommand cmd = new SqlCommand("SELECT COUNT(DISTINCT (IL)) FROM TBL_FIRMALAR ", cnSql.connMSSQL());
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                lblFirmaSehirS.Text = dr[0].ToString();
            }
            cnSql.connMSSQL().Close();
        }
        void toplamPS()
        {
            SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM TBL_PERSONELLER ", cnSql.connMSSQL());
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                lblPerS.Text = dr[0].ToString();
            }
            cnSql.connMSSQL().Close();
        }  
        void toplamSS()
        {
            SqlCommand cmd = new SqlCommand("SELECT SUM(ADET) FROM TBL_URUNLER ", cnSql.connMSSQL());
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                lblStokS.Text = dr[0].ToString();
            }
            cnSql.connMSSQL().Close();
        }
        void sonDortAyElkt()
        {
            
            SqlCommand cmd = new SqlCommand("SELECT TOP 4 AY,ELEKTRIK FROM TBL_GIDERLER ORDER BY ID DESC", cnSql.connMSSQL());
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                chartControl1.Series["AYLAR"].Points.Add(new DevExpress.XtraCharts.SeriesPoint(dr[0], dr[1]));
            }
            cnSql.connMSSQL().Close();
            
        }
        void sonDortAySu()
        {
            
            SqlCommand cmd = new SqlCommand("SELECT TOP 4 AY,SU FROM TBL_GIDERLER ORDER BY ID DESC", cnSql.connMSSQL());
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                chartControl1.Series["AYLAR"].Points.Add(new DevExpress.XtraCharts.SeriesPoint(dr[0], dr[1]));
            }
            cnSql.connMSSQL().Close();
            
        }
        void sonDortAyDogalgaz()
        {
            
            SqlCommand cmd = new SqlCommand("SELECT TOP 4 AY,DOGALGAZ FROM TBL_GIDERLER ORDER BY ID DESC", cnSql.connMSSQL());
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                chartControl1.Series["AYLAR"].Points.Add(new DevExpress.XtraCharts.SeriesPoint(dr[0], dr[1]));
            }
            cnSql.connMSSQL().Close();
            
        }
        void sonDortAyInternet()
        {
            
            SqlCommand cmd = new SqlCommand("SELECT TOP 4 AY,INTERNET FROM TBL_GIDERLER ORDER BY ID DESC", cnSql.connMSSQL());
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                chartControl1.Series["AYLAR"].Points.Add(new DevExpress.XtraCharts.SeriesPoint(dr[0], dr[1]));
            }
            cnSql.connMSSQL().Close();
            
        }
        void sonDortAyEkstra()
        {
            
            SqlCommand cmd = new SqlCommand("SELECT TOP 4 AY,EKSTRA FROM TBL_GIDERLER ORDER BY ID DESC", cnSql.connMSSQL());
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                chartControl1.Series["AYLAR"].Points.Add(new DevExpress.XtraCharts.SeriesPoint(dr[0], dr[1]));
            }
            cnSql.connMSSQL().Close();
            
        }

        public string ad;
        private void frmKasa_Load(object sender, EventArgs e)
        {
            lst();
            toplamT();
            toplamM();
            toplamF();
            toplamMS();
            toplamFS();
            toplamPS();
            toplamSS();
            lblAktifK.Text = ad;
            timer1.Enabled = true;
        }

        int sayac = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            sayac++;
            if (sayac>0 && sayac<=5)
            {
                lblFatura.Text = "ELEKTRİK";
                chartControl1.Series["AYLAR"].Points.Clear();
                sonDortAyElkt();
            }
            else if (sayac>5 && sayac<=10)
            {
                lblFatura.Text = "SU";
                chartControl1.Series["AYLAR"].Points.Clear();
                sonDortAySu();
            }
            else if(sayac>10 && sayac<=15)
            {
                lblFatura.Text = "DOGALGAZ";
                chartControl1.Series["AYLAR"].Points.Clear();
                sonDortAyDogalgaz();
            }
            else if(sayac>15 && sayac<=20)
            {
                lblFatura.Text = "INTERNET";
                chartControl1.Series["AYLAR"].Points.Clear();
                sonDortAyInternet();
            }
            else if (sayac>20 && sayac<=25)
            {
                lblFatura.Text = "EKSTRA";
                chartControl1.Series["AYLAR"].Points.Clear();
                sonDortAyEkstra();
            }
            else if (sayac==26)
            {
                sayac = 0;
            }
        }
    }
}
