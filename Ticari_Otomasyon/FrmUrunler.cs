using System;
using System.Data;
//Database için gerekli namespace.
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Ticari_Otomasyon
{
    public partial class frmUrunler : Form
    {
        public frmUrunler()
        {
            InitializeComponent();
        }
        //Bağlantı sınıfımızı tanımladık.
        ConSQL cnSql = new ConSQL();
        //Listeleme metodlarımız için oluşturduğumuz sınıfı tanımlıyoruz.
        ListSQL lstSql = new ListSQL();

        void drop()
        {
            txtUrunAd.Text = "";
            txtMarka.Text = "";
            txtModel.Text = "";
            mtbYil.Text = "";
            nudAdet.Value = 0;
            txtAlis.Text = "";
            txtSatis.Text = "";
            rtbDetay.Text = "";
        }
        void lst()
        {
            //Grid Control' e dönen değerleri yolluyoruz.
            gridControl1.DataSource = lstSql.lstUrunler();
        }

       

        private void frmUrunler_Load(object sender, EventArgs e)
        {
            lst();
        }


        //Tabloda seçilen değerin textlere yazılması.
        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            /*Veri Satırı türünde bir instance oluşturduk ve bunu gridView in
             sütun getirme metodunu kullanarak seçilen sütünü getir özelliğinden gelen
            sonuca atadık.
            */
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            if (dr != null)
            {
                txtId.Text = dr["ID"].ToString();
                txtUrunAd.Text = dr["URUNAD"].ToString();
                txtMarka.Text = dr["MARKA"].ToString();
                txtModel.Text = dr["MODEL"].ToString();
                mtbYil.Text = dr["YIL"].ToString();
                nudAdet.Value = int.Parse(dr["ADET"].ToString());
                txtAlis.Text = dr["ALISFIYAT"].ToString();
                txtSatis.Text = dr["SATISFIYAT"].ToString();
                rtbDetay.Text = dr["DETAY"].ToString();
            }
        }



        //Kaydetme işlemleri.
        private void btnKaydet_Click(object sender, EventArgs e)
        {
                SqlCommand cmd = new SqlCommand
                (
                "Insert Into TBL_URUNLER(URUNAD,MARKA,MODEL,YIL,ADET,ALISFIYAT,SATISFIYAT,DETAY)values(@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8) ", cnSql.connMSSQL());
                cmd.Parameters.AddWithValue("@p1", txtUrunAd.Text);
                cmd.Parameters.AddWithValue("@p2", txtMarka.Text);
                cmd.Parameters.AddWithValue("@p3", txtModel.Text);
                cmd.Parameters.AddWithValue("@p4", mtbYil.Text);
                cmd.Parameters.AddWithValue("@p5", int.Parse(nudAdet.Value.ToString()));
                cmd.Parameters.AddWithValue("@p6", decimal.Parse(txtAlis.Text));
                cmd.Parameters.AddWithValue("@p7", decimal.Parse(txtSatis.Text));
                cmd.Parameters.AddWithValue("@p8", rtbDetay.Text);
                cmd.ExecuteNonQuery();
                cnSql.connMSSQL().Close();
                MessageBox.Show("Ürün sisteme eklendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                lst();
                drop();
            
        }

        //Silme işlemleri.
        private void btnSil_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("Delete From TBL_URUNLER where ID=@p1",cnSql.connMSSQL());
            cmd.Parameters.AddWithValue("@p1", txtId.Text);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Ürün silindi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            lst();
            drop();
        }

        //Güncelleme işlemleri.
        private void btnGuncel_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("Update TBL_URUNLER SET URUNAD=@P1,MARKA=@P2,MODEL=@P3,YIL=@P4,ADET=@P5,ALISFIYAT=@P6,SATISFIYAT=@P7,DETAY=@P8 Where ID = @P9",cnSql.connMSSQL());
            cmd.Parameters.AddWithValue("@P1", txtUrunAd.Text);
            cmd.Parameters.AddWithValue("@P2", txtMarka.Text);
            cmd.Parameters.AddWithValue("@P3", txtModel.Text);
            cmd.Parameters.AddWithValue("@P4", mtbYil.Text);
            cmd.Parameters.AddWithValue("@P5", int.Parse(nudAdet.Value.ToString()));
            cmd.Parameters.AddWithValue("@P6", decimal.Parse(txtAlis.Text));
            cmd.Parameters.AddWithValue("@P7", decimal.Parse(txtSatis.Text));
            cmd.Parameters.AddWithValue("@P8", rtbDetay.Text);
            cmd.Parameters.AddWithValue("P9",txtId.Text);
            cmd.ExecuteNonQuery();
            cnSql.connMSSQL().Close();
            MessageBox.Show("Ürün güncellendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            lst();
            drop();
        }

       
    }
}
