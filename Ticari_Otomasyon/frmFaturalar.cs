using DevExpress.XtraGrid;
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
    public partial class frmFaturalar : Form
    {
        public frmFaturalar()
        {
            InitializeComponent();
        }
        ConSQL cnSql = new ConSQL();
        ListSQL lstSql = new ListSQL();

        void drop()
        {
            txtFaturaId.Text = "";
            txtSeri.Text = "";
            txtSiraNo.Text = "";
            mtbTarih.Text = "";
            mtbSaat.Text = "";
            txtVergiD.Text = "";
            txtAlici.Text = "";
            txtTeslimE.Text = "";
            txtTeslimA.Text = "";
            luedUrun.Text = "";
            txtMiktar.Text = "";
            txtFiyat.Text = "";
            txtTutar.Text = "";

        }
        void lst()
        {
            //Grid Control' e dönen değerleri yolluyoruz.
            gridControl1.DataSource = lstSql.lstFaturaB();
        }

        void lstUrun()
        {
            luedUrun.Properties.ValueMember = "MODEL";
            luedUrun.Properties.DisplayMember = "URUNAD";
            luedUrun.Properties.DataSource = lstSql.lstUrun();
        }

        private void frmFaturalar_Load(object sender, EventArgs e)
        {
            lst();
            lstUrun();
            drop();
        }
        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            txtFaturaId.Text = dr["FATURAID"].ToString();
            txtFaturaId2.Text = dr["FATURAID"].ToString();
            txtSeri.Text= dr["SERI"].ToString();
            txtSiraNo.Text = dr["SIRANO"].ToString();
            mtbTarih.Text = dr["TARIH"].ToString();
            mtbSaat.Text = dr["SAAT"].ToString();
            txtVergiD.Text = dr["VERGIDAIRE"].ToString();
            txtAlici.Text = dr["ALICI"].ToString();
            txtTeslimE.Text = dr["TESLIMEDEN"].ToString();
            txtTeslimA.Text = dr["TESLIMALAN"].ToString();
            cmbDurum.Text = dr["DURUM"].ToString();

        }



        private void btnKaydet_Click(object sender, EventArgs e)
        {
                double miktar, tutar, fiyat;
                fiyat = double.Parse(txtFiyat.Text);
                miktar = double.Parse(txtMiktar.Text);
                tutar = miktar * fiyat;
                txtTutar.Text = tutar.ToString();

            SqlCommand cmd = new SqlCommand
            (
            "Insert Into TBL_FATURADETAY(URUNAD,MODEL,MIKTAR,FIYAT,TUTAR,FATURAID,DURUM2)values(@p1,@p2,@p3,@p4,@p5,@p6,@p7) ", cnSql.connMSSQL());
            cmd.Parameters.AddWithValue("@p1", luedUrun.Text);
            cmd.Parameters.AddWithValue("@p2", luedUrun.EditValue.ToString());
            cmd.Parameters.AddWithValue("@p3", txtMiktar.Text);
            cmd.Parameters.AddWithValue("@p4", decimal.Parse(txtFiyat.Text));
            cmd.Parameters.AddWithValue("@p5", decimal.Parse(txtTutar.Text));
            cmd.Parameters.AddWithValue("@p6", txtFaturaId2.Text);
            cmd.Parameters.AddWithValue("@p7", false);
            cmd.ExecuteNonQuery();
            cnSql.connMSSQL().Close();
            MessageBox.Show("Ürün sisteme eklendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            lst();
            drop();

        }



        private void btnKaydetB_Click(object sender, EventArgs e)
        {
            if (cmbDurum.Text != "FALSE")
            {
                SqlCommand cmd = new SqlCommand
                (
                "Insert Into TBL_FATURABILGI(SERI,SIRANO,TARIH,SAAT,VERGIDAIRE,ALICI,TESLIMEDEN,TESLIMALAN,DURUM)values(@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9) ", cnSql.connMSSQL());
                cmd.Parameters.AddWithValue("@p1", txtSeri.Text);
                cmd.Parameters.AddWithValue("@p2", txtSiraNo.Text);
                cmd.Parameters.AddWithValue("@p3", mtbTarih.Text);
                cmd.Parameters.AddWithValue("@p4", mtbSaat.Text);
                cmd.Parameters.AddWithValue("@p5", txtVergiD.Text);
                cmd.Parameters.AddWithValue("@p6", txtAlici.Text);
                cmd.Parameters.AddWithValue("@p7", txtTeslimE.Text);
                cmd.Parameters.AddWithValue("@p8", txtTeslimA.Text);
                cmd.Parameters.AddWithValue("@p9", cmbDurum.Text);
                cmd.ExecuteNonQuery();
                cnSql.connMSSQL().Close();
                MessageBox.Show("Fatura sisteme eklendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                lst();
                drop();
            }
            else
            {
                MessageBox.Show("Lütfen kayıt eklemek için durumu aktıf(TRUE) hale getiriniz.", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }
        private void btnSilB_Click(object sender, EventArgs e)
        {
            DialogResult secenek = MessageBox.Show("Faturayı silmek için lütfen fatura içindeki ürünleri temizleyiniz. Temizlediyseniz EVET tuşuna basınız...:", "SORU", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
            if (secenek == DialogResult.Yes)
            {
                SqlCommand cmd = new SqlCommand("Select FATURAID From TBL_FATURADETAY Where FATURAID = @p1", cnSql.connMSSQL());
                cmd.Parameters.AddWithValue("@p1", txtFaturaId.Text);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    MessageBox.Show("Lütfen faturanın içindeki ürün kayıtlarını siliniz....", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    SqlCommand cmd1 = new SqlCommand("DELETE FROM TBL_FATURABILGI WHERE FATURAID = @p1", cnSql.connMSSQL());
                    cmd1.Parameters.AddWithValue("@p1", txtFaturaId.Text);
                    cmd1.ExecuteNonQuery();
                    cnSql.connMSSQL().Close();
                    lst();
                    drop();
                }
                
            }
        }
        private void btnGunB_Click(object sender, EventArgs e)
        {
            
            SqlCommand cmd = new SqlCommand("UPDATE TBL_FATURABILGI SET SERI=@P1,SIRANO=@P2,TARIH=@P3, SAAT=@P4,VERGIDAIRE=@P5,ALICI=@P6,TESLIMEDEN=@P7,TESLIMALAN=@P8,DURUM=@P9 WHERE FATURAID = @P10", cnSql.connMSSQL());
            cmd.Parameters.AddWithValue("@P1", txtSeri.Text);
            cmd.Parameters.AddWithValue("@P2", txtSiraNo.Text);
            cmd.Parameters.AddWithValue("@P3", mtbTarih.Text);
            cmd.Parameters.AddWithValue("@P4", mtbSaat.Text);
            cmd.Parameters.AddWithValue("@P5", txtVergiD.Text);
            cmd.Parameters.AddWithValue("@P6", txtAlici.Text);
            cmd.Parameters.AddWithValue("@P7", txtTeslimE.Text);
            cmd.Parameters.AddWithValue("@P8", txtTeslimA.Text);
            cmd.Parameters.AddWithValue("@P9", cmbDurum.Text);
            cmd.Parameters.AddWithValue("@P10", txtFaturaId.Text);
            cmd.ExecuteNonQuery();
            cnSql.connMSSQL().Close();
            MessageBox.Show("Fatura güncellendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            lst();
            drop();

        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            frmFaturaUrunler fr = new frmFaturaUrunler();
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            if (dr!=null)
            {
                fr.id = int.Parse(dr["FATURAID"].ToString());
                fr.Show();
            }
        }

        private void luedUrun_TextChanged(object sender, EventArgs e)
        {
            txtFiyat.Text = lstSql.lstFiyat(luedUrun.EditValue.ToString());
        }
    }
}
