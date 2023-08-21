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
    public partial class frmFirmalar : Form
    {
        public frmFirmalar()
        {
            InitializeComponent();
        }
        //Bağlantı sınıfımızı tanımladık.
        ConSQL cnSql = new ConSQL();
        //Listeleme metodlarımız için oluşturduğumuz sınıfı tanımlıyoruz.
        ListSQL lstSql = new ListSQL();


        void drop()
        {
            txtId.Text = null;
            txtAd.Text = "";
            txtSektor.Text = "";
            txtYetkili.Text = "";
            txtGorev.Text = "";
            mtbTC.Text = "";
            mtbTel.Text = "";
            mtbTel2.Text = "";
            mtbTel3.Text = "";
            mtbFax.Text = "";
            txtMail.Text = "";

            cmbIl.SelectedItem = null;
            cmbIlce.SelectedItem = null;
            txtVergiD.Text = "";
            rtbAdres.Text = "";
        }
        void lst()
        {
            //Grid Control' e dönen değerleri yolluyoruz.
            gridControl1.DataSource = lstSql.lstFirmalar();
        }
        //İl listeleme.
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
        //İlçe listeleme
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


        private void frmFirmalar_Load(object sender, EventArgs e)
        {
            lst();
            lstIller();
            drop();
        }
        //Illere ait comboBox ın değeri değişince ilgili ilçeleri listelesin.
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
                txtSektor.Text = dr["SEKTOR"].ToString();
                txtYetkili.Text = dr["YETKILIADSOYAD"].ToString();
                txtGorev.Text = dr["YETKILISTATU"].ToString();
                mtbTC.Text = dr["YETKILITC"].ToString();
                mtbTel.Text = dr["TELEFON1"].ToString();
                mtbTel2.Text = dr["TELEFON2"].ToString();
                mtbTel3.Text = dr["TELEFON3"].ToString();
                mtbFax.Text = dr["FAX"].ToString();
                txtMail.Text = dr["MAIL"].ToString();

                cmbIl.SelectedItem = dr["IL"].ToString();
                cmbIlce.SelectedItem = dr["ILCE"].ToString();
                txtVergiD.Text = dr["VERGIDAIRE"].ToString();
                rtbAdres.Text = dr["ADRES"].ToString();

            
        }



        private void btnKaydet_Click(object sender, EventArgs e)
        {

                SqlCommand cmd = new SqlCommand
                (
                "Insert Into TBL_FIRMALAR(AD,YETKILISTATU,YETKILIADSOYAD,YETKILITC,SEKTOR,TELEFON1,TELEFON2,TELEFON3,MAIL,FAX,IL,ILCE,VERGIDAIRE,ADRES)values(@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9,@p10,@p11,@p12,@p13,@p14) ", cnSql.connMSSQL());
                cmd.Parameters.AddWithValue("@p1", txtAd.Text);
                cmd.Parameters.AddWithValue("@p2", txtGorev.Text);
                cmd.Parameters.AddWithValue("@p3", txtYetkili.Text);
                cmd.Parameters.AddWithValue("@p4", mtbTC.Text);
                cmd.Parameters.AddWithValue("@p5", txtSektor.Text);
                cmd.Parameters.AddWithValue("@p6", mtbTel.Text);
                cmd.Parameters.AddWithValue("@p7", mtbTel2.Text);
                cmd.Parameters.AddWithValue("@p8", mtbTel3.Text);
                cmd.Parameters.AddWithValue("@p9", txtMail.Text);
                cmd.Parameters.AddWithValue("@p10", mtbFax.Text);
                cmd.Parameters.AddWithValue("@p11", cmbIl.Text);
                cmd.Parameters.AddWithValue("@p12", cmbIlce.Text);
                cmd.Parameters.AddWithValue("@p13", txtVergiD.Text);
                cmd.Parameters.AddWithValue("@p14", rtbAdres.Text);


                cmd.ExecuteNonQuery();
                cnSql.connMSSQL().Close();
                MessageBox.Show("Firma sisteme eklendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                lst();
                drop();
           
        }
        private void btnSil_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("Delete From TBL_FIRMALAR where ID=@p1", cnSql.connMSSQL());
            cmd.Parameters.AddWithValue("@p1", txtId.Text);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Firma silindi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            lst();
            drop();
        }
        private void btnGuncel_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("Update TBL_FIRMALAR SET AD=@P1,YETKILISTATU=@P2,YETKILIADSOYAD=@P3,YETKILITC=@P4,SEKTOR=@P5,TELEFON1=@P6,TELEFON2=@P7,TELEFON3=@P8,MAIL=@P9,FAX=@P10,IL=@P11,ILCE=@P12,VERGIDAIRE=@P13,ADRES=@P14 Where ID = @P15", cnSql.connMSSQL());
            cmd.Parameters.AddWithValue("@P1", txtAd.Text);
            cmd.Parameters.AddWithValue("@P2", txtGorev.Text);
            cmd.Parameters.AddWithValue("@P3", txtYetkili.Text);
            cmd.Parameters.AddWithValue("@P4", mtbTC.Text);
            cmd.Parameters.AddWithValue("@P5", txtSektor.Text);
            cmd.Parameters.AddWithValue("@P6", mtbTel.Text);
            cmd.Parameters.AddWithValue("@p7", mtbTel2.Text);
            cmd.Parameters.AddWithValue("@P8", mtbTel3.Text);
            cmd.Parameters.AddWithValue("@P9", txtMail.Text);
            cmd.Parameters.AddWithValue("@P10", mtbFax.Text);
            cmd.Parameters.AddWithValue("@P11", cmbIl.Text);
            cmd.Parameters.AddWithValue("@P12", cmbIlce.Text);
            cmd.Parameters.AddWithValue("@P13", txtVergiD.Text);
            cmd.Parameters.AddWithValue("@P14", rtbAdres.Text);
            cmd.Parameters.AddWithValue("@P15", txtId.Text);
            cmd.ExecuteNonQuery();
            cnSql.connMSSQL().Close();
            MessageBox.Show("Müşteri güncellendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            lst();
            drop();
        }
    }
}
