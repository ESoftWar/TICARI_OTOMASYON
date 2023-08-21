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
    public partial class frmGiderler : Form
    {
        public frmGiderler()
        {
            InitializeComponent();
        }

        ConSQL cnSql = new ConSQL();
        ListSQL lstSql = new ListSQL();

        void drop()
        {
            txtId.Text = null;
            cmbAy.SelectedItem = null;
            cmbYil.SelectedItem = null;
            txtElkt.Text = "";
            txtSu.Text = "";
            txtDgl.Text = "";
            txtInt.Text = "";
            txtMaas.Text = "";
            txtEkstra.Text = "";
            rtbNot.Text = "";

        }
        void lst()
        {
            //Grid Control' e dönen değerleri yolluyoruz.
            gridControl1.DataSource = lstSql.lstGiderler();
        }



        private void frmGiderler_Load(object sender, EventArgs e)
        {
            lst();
            drop();
        }
        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            txtId.Text = dr["ID"].ToString();
            cmbAy.SelectedItem = dr["AY"].ToString();
            cmbYil.SelectedItem = dr["YIL"].ToString();
            txtElkt.Text = dr["ELEKTRIK"].ToString();
            txtSu.Text = dr["SU"].ToString();
            txtDgl.Text = dr["DOGALGAZ"].ToString();
            txtInt.Text = dr["INTERNET"].ToString();
            txtMaas.Text = dr["MAASLAR"].ToString();
            txtEkstra.Text = dr["EKSTRA"].ToString();
            rtbNot.Text = dr["NOTLAR"].ToString();
        }



        private void btnKaydet_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand
                (
                "Insert Into TBL_GIDERLER(AY,YIL,ELEKTRIK,SU,DOGALGAZ,INTERNET,MAASLAR,EKSTRA,NOTLAR)values(@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9) ", cnSql.connMSSQL());
            cmd.Parameters.AddWithValue("@p1", cmbAy.Text);
            cmd.Parameters.AddWithValue("@p2", cmbYil.Text);
            cmd.Parameters.AddWithValue("@p3", decimal.Parse(txtElkt.Text));
            cmd.Parameters.AddWithValue("@p4", decimal.Parse(txtSu.Text));
            cmd.Parameters.AddWithValue("@p5", decimal.Parse(txtDgl.Text));
            cmd.Parameters.AddWithValue("@p6", decimal.Parse(txtInt.Text));
            cmd.Parameters.AddWithValue("@p7", decimal.Parse(txtMaas.Text));
            cmd.Parameters.AddWithValue("@p8", decimal.Parse(txtEkstra.Text));
            cmd.Parameters.AddWithValue("@p9", rtbNot.Text);
            cmd.ExecuteNonQuery();
            cnSql.connMSSQL().Close();
            MessageBox.Show("Giderler sisteme eklendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            lst();
            drop();
        }
        private void btnSil_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("Delete From TBL_GIDERLER where ID=@p1", cnSql.connMSSQL());
            cmd.Parameters.AddWithValue("@p1", txtId.Text);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Gider silindi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            lst();
            drop();
        }
        private void btnGuncel_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("Update TBL_GIDERLER SET AY=@P1,YIL=@P2,ELEKTRIK=@P3,SU=@P4,DOGALGAZ=@P5,INTERNET=@P6,MAASLAR=@P7,EKSTRA=@P8,NOTLAR=@P9 Where ID = @P10", cnSql.connMSSQL());
            cmd.Parameters.AddWithValue("@P1", cmbAy.Text);
            cmd.Parameters.AddWithValue("@P2", cmbYil.Text);
            cmd.Parameters.AddWithValue("@P3", decimal.Parse(txtElkt.Text));
            cmd.Parameters.AddWithValue("@P4", decimal.Parse(txtSu.Text));
            cmd.Parameters.AddWithValue("@P5", decimal.Parse(txtDgl.Text));
            cmd.Parameters.AddWithValue("@P6", decimal.Parse(txtInt.Text));
            cmd.Parameters.AddWithValue("@P7", decimal.Parse(txtMaas.Text));
            cmd.Parameters.AddWithValue("@P8", decimal.Parse(txtEkstra.Text));
            cmd.Parameters.AddWithValue("@P9", rtbNot.Text);
            cmd.Parameters.AddWithValue("@P10", txtId.Text);
            cmd.ExecuteNonQuery();
            cnSql.connMSSQL().Close();
            MessageBox.Show("Müşteri güncellendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            lst();
            drop();
        }
    }
}
