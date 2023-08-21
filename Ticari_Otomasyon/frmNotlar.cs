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
    public partial class frmNotlar : Form
    {
        public frmNotlar()
        {
            InitializeComponent();
        }
        ConSQL cnSql = new ConSQL();
        ListSQL lstSql = new ListSQL();


        void drop()
        {
            txtId.Text = null;
            mtbTarih.Text = "";
            mtbSaat.Text = "";
            txtBaslık.Text = "";
            txtOlus.Text = "";
            txtHitap.Text = "";
            rtbDetay.Text = "";

        }
        void lst()
        {
            gridControl1.DataSource = lstSql.lstNotlar();
        }


        private void frmNotlar_Load(object sender, EventArgs e)
        {
            lst();
            drop();
        }
        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            if (dr != null)
            {
                txtId.Text = dr["ID"].ToString();
                mtbTarih.Text = dr["TARIH"].ToString();
                mtbSaat.Text = dr["SAAT"].ToString();
                txtBaslık.Text = dr["BASLIK"].ToString();
                rtbDetay.Text = dr["DETAY"].ToString();
                txtOlus.Text = dr["OLUSTURAN"].ToString();
                txtHitap.Text = dr["HITAP"].ToString();
            }
        }
        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            frmNotlarDetay fr = new frmNotlarDetay();
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            if (dr != null)
            {
                fr.metin = dr["DETAY"].ToString();
                fr.Show();
            }
        }


        private void btnKaydet_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("INSERT INTO TBL_NOTLAR(TARIH,SAAT,BASLIK,DETAY,OLUSTURAN,HITAP) VALUES (@p1,@p2,@p3,@p4,@p5,@p6)",cnSql.connMSSQL());
            cmd.Parameters.AddWithValue("@p1", mtbTarih.Text);
            cmd.Parameters.AddWithValue("@p2", mtbSaat.Text);
            cmd.Parameters.AddWithValue("@p3", txtBaslık.Text);
            cmd.Parameters.AddWithValue("@p4", rtbDetay.Text);
            cmd.Parameters.AddWithValue("@p5", txtOlus.Text);
            cmd.Parameters.AddWithValue("@p6", txtHitap.Text);
            cmd.ExecuteNonQuery();
            cnSql.connMSSQL().Close();
            MessageBox.Show("Not sisteme eklendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            lst();
            drop();
        }
        private void btnSil_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("DELETE FROM TBL_NOTLAR WHERE ID=@p1", cnSql.connMSSQL());
            cmd.Parameters.AddWithValue("@p1",txtId.Text);
            cmd.ExecuteNonQuery();
            cnSql.connMSSQL().Close();
            MessageBox.Show("Not silindi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            lst();
            drop();
        }
        private void btnGuncel_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("UPDATE TBL_NOTLAR SET TARIH=@p1,SAAT=@p2,BASLIK=@p3,DETAY=@p4,OLUSTURAN=@p5,HITAP=@p6 WHERE ID=@p7", cnSql.connMSSQL());
            cmd.Parameters.AddWithValue("@p1", mtbTarih.Text);
            cmd.Parameters.AddWithValue("@p2", mtbSaat.Text);
            cmd.Parameters.AddWithValue("@p3", txtBaslık.Text);
            cmd.Parameters.AddWithValue("@p4", rtbDetay.Text);
            cmd.Parameters.AddWithValue("@p5", txtOlus.Text);
            cmd.Parameters.AddWithValue("@p6", txtHitap.Text);
            cmd.Parameters.AddWithValue("@p7", txtId.Text);
            cmd.ExecuteNonQuery();
            cnSql.connMSSQL().Close();
            MessageBox.Show("Not güncellendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            lst();
            drop();
        }


    }
}
