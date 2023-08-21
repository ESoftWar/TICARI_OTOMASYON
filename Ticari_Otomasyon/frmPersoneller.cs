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
    public partial class frmPersoneller : Form
    {
        public frmPersoneller()
        {
            InitializeComponent();
        }



        ConSQL cnSql = new ConSQL();
        ListSQL lstSql = new ListSQL();
        


        void drop()
        {
            txtId.Text = null;
            txtAd.Text = "";
            txtSoyad.Text = "";
            mtbTel.Text = "";
            mtbTC.Text = "";
            txtMail.Text = "";
            cmbIl.SelectedItem = null;
            cmbIlce.SelectedItem = null;
            rtbAdres.Text = "";
            txtGorev.Text = "";
        }
        void lst()
        {
            //Grid Control' e dönen değerleri yolluyoruz.
            gridControl1.DataSource = lstSql.lstPersoneller();
        }
        void lstIller()
        {
            SqlCommand cmd = new SqlCommand("Select Sehir From TBL_ILLER", cnSql.connMSSQL());
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                cmbIl.Properties.Items.Add(dr[0]);
            }
            cnSql.connMSSQL().Close();
        }
        void lstIlceler()
        {
            SqlCommand cmd = new SqlCommand("Select ilce From TBL_ILCELER Where sehir = @p1", cnSql.connMSSQL());
            cmd.Parameters.AddWithValue("@p1", (cmbIl.SelectedIndex + 1));
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                cmbIlce.Properties.Items.Add(dr[0]);
            }
            cnSql.connMSSQL().Close();

        }



        private void frmPersoneller_Load(object sender, EventArgs e)
        {
            lst();
            lstIller();
            drop();
        }  
        private void cmbIl_SelectedValueChanged(object sender, EventArgs e)
        {
            cmbIlce.Text = "";
            cmbIlce.Properties.Items.Clear();
            lstIlceler();
        }
        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            /*Veri Satırı türünde bir instance oluşturduk ve bunu gridView in
             sütun getirme metodunu kullanarak seçilen sütünü getir özelliğinden gelen
            sonuca atadık.
            */
                DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
                txtId.Text = dr["ID"].ToString();
                txtAd.Text = dr["AD"].ToString();
                txtSoyad.Text = dr["SOYAD"].ToString();
                mtbTel.Text = dr["TELEFON"].ToString();
                mtbTC.Text = dr["TC"].ToString();
                txtMail.Text = dr["MAIL"].ToString();
                cmbIl.SelectedItem = dr["IL"].ToString();
                cmbIlce.SelectedItem = dr["ILCE"].ToString();
                rtbAdres.Text = dr["ADRES"].ToString();
                txtGorev.Text = dr["GOREV"].ToString();
           
        }



        private void btnKaydet_Click(object sender, EventArgs e)
        {

                SqlCommand cmd = new SqlCommand
                (
                "Insert Into TBL_PERSONELLER(AD,SOYAD,TELEFON,TC,MAIL,IL,ILCE,ADRES,GOREV)values(@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9) ", cnSql.connMSSQL());
                cmd.Parameters.AddWithValue("@p1", txtAd.Text);
                cmd.Parameters.AddWithValue("@p2", txtSoyad.Text);
                cmd.Parameters.AddWithValue("@p3", mtbTel.Text);
                cmd.Parameters.AddWithValue("@p4", mtbTC.Text);
                cmd.Parameters.AddWithValue("@p5", txtMail.Text);
                cmd.Parameters.AddWithValue("@p6", cmbIl.Text);
                cmd.Parameters.AddWithValue("@p7", cmbIlce.Text);
                cmd.Parameters.AddWithValue("@p8", rtbAdres.Text);
                cmd.Parameters.AddWithValue("@p9", txtGorev.Text);
                cmd.ExecuteNonQuery();
                cnSql.connMSSQL().Close();
                MessageBox.Show("Personel sisteme eklendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                lst();
                drop();
        }
        private void btnSil_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("Delete From TBL_PERSONELLER where ID=@p1", cnSql.connMSSQL());
            cmd.Parameters.AddWithValue("@p1", txtId.Text);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Personel silindi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            lst();
            drop();
        }
        private void btnGuncel_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("Update TBL_PERSONELLER SET AD=@P1,SOYAD=@P2,TELEFON=@P3,TC=@P4,MAIL=@P5,IL=@P6,ILCE=@P7,ADRES=@P8,GOREV=@P9 Where ID = @P10", cnSql.connMSSQL());
            cmd.Parameters.AddWithValue("@P1", txtAd.Text);
            cmd.Parameters.AddWithValue("@P2", txtSoyad.Text);
            cmd.Parameters.AddWithValue("@P3", mtbTel.Text);
            cmd.Parameters.AddWithValue("@P4", mtbTC.Text);
            cmd.Parameters.AddWithValue("@P5", txtMail.Text);
            cmd.Parameters.AddWithValue("@P6", cmbIl.SelectedItem);
            cmd.Parameters.AddWithValue("@P7", cmbIlce.SelectedItem);
            cmd.Parameters.AddWithValue("@P8", rtbAdres.Text);
            cmd.Parameters.AddWithValue("@P9", txtGorev.Text);
            cmd.Parameters.AddWithValue("@P10", txtId.Text);
            cmd.ExecuteNonQuery();
            cnSql.connMSSQL().Close();
            MessageBox.Show("Personel güncellendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            lst();
            drop();
        }
    }
}
