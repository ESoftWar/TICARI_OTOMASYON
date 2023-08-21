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
using System.Collections;

namespace Ticari_Otomasyon
{
    public partial class frmBankalar : Form
    {
        public frmBankalar()
        {
            InitializeComponent();
        }
        ConSQL cnSql = new ConSQL();
        ListSQL lstSql = new ListSQL();

        void drop()
        {
            txtId.Text = null;
            txtBnkAd.Text = "";
            txtSube.Text = "";
            mtbIban.Text = "";
            mtbHesap.Text = "";
            txtYetkılı.Text = "";
            mtbTel.Text = "";
            mtbTarih.Text = "";
            cmbIl.SelectedItem = null;
            cmbIlce.SelectedItem = null;
            txtHesapT.Text = "";
            luedFirmaAd.Text = "";
        }
        void lst()
        {
            gridControl1.DataSource = lstSql.lstBankalar();
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
        //luedComboBox kullanımı. DisplayMember ve ValueMember özelliği ile.
        void lstFirmaAd()
        {
            luedFirmaAd.Properties.ValueMember = "ID";
            luedFirmaAd.Properties.DisplayMember = "AD";
            luedFirmaAd.Properties.DataSource = lstSql.lstFirmaAd();
        }



        private void frmBankalar_Load(object sender, EventArgs e)
        { 
            lst();
            lstIller();
            lstFirmaAd();
            drop();
        }
        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            txtId.Text = dr["ID"].ToString();
            txtBnkAd.Text = dr["BANKAADI"].ToString();
            txtSube.Text = dr["SUBE"].ToString();
            mtbIban.Text = dr["IBAN"].ToString();
            mtbHesap.Text = dr["HESAPNO"].ToString();
            txtYetkılı.Text = dr["YETKILI"].ToString();
            mtbTel.Text = dr["TELEFON"].ToString();
            mtbTarih.Text = dr["TARIH"].ToString();
            cmbIl.SelectedItem = dr["IL"].ToString();
            cmbIlce.SelectedItem = dr["ILCE"].ToString();
            txtHesapT.Text = dr["HESAPTURU"].ToString();
            luedFirmaAd.Text = dr["AD"].ToString();
        }
        private void cmbIl_SelectedValueChanged(object sender, EventArgs e)
        {
            cmbIlce.Text = "";
            cmbIlce.Properties.Items.Clear();
            lstIlceler();
        }



        private void btnKaydet_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand
                (
                "Insert Into TBL_BANKALAR(BANKAADI,IL,ILCE,SUBE,IBAN,HESAPNO,YETKILI,TELEFON,TARIH,HESAPTURU,FIRMAID)values(@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9,@p10,@p11) ", cnSql.connMSSQL());
            cmd.Parameters.AddWithValue("@p1", txtBnkAd.Text);
            cmd.Parameters.AddWithValue("@p2", cmbIl.Text);
            cmd.Parameters.AddWithValue("@p3", cmbIlce.Text);
            cmd.Parameters.AddWithValue("@p4", txtSube.Text);
            cmd.Parameters.AddWithValue("@p5", mtbIban.Text);
            cmd.Parameters.AddWithValue("@p6", mtbHesap.Text);
            cmd.Parameters.AddWithValue("@p7", txtYetkılı.Text);
            cmd.Parameters.AddWithValue("@p8", mtbTel.Text);
            cmd.Parameters.AddWithValue("@p9", mtbTarih.Text);
            cmd.Parameters.AddWithValue("@p10", txtHesapT.Text);
            cmd.Parameters.AddWithValue("@p11", luedFirmaAd.EditValue);
            cmd.ExecuteNonQuery();
            cnSql.connMSSQL().Close();
            MessageBox.Show("Banka sisteme eklendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            lst();
            drop();
        }
        private void btnSil_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("Delete From TBL_BANKALAR where ID=@p1", cnSql.connMSSQL());
            cmd.Parameters.AddWithValue("@p1", txtId.Text);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Banka silindi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            lst();
            drop();
        }
        private void btnGuncel_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("Update TBL_BANKALAR SET BANKAADI=@P1,IL=@P2,ILCE=@P3,SUBE=@P4,IBAN=@P5,HESAPNO=@P6,YETKILI=@P7,TELEFON=@P8,TARIH=@P9,HESAPTURU=@P10,FIRMAID=@P11 Where ID = @P12", cnSql.connMSSQL());
            cmd.Parameters.AddWithValue("@P1", txtBnkAd.Text);
            cmd.Parameters.AddWithValue("@P2", cmbIl.Text);
            cmd.Parameters.AddWithValue("@P3", cmbIlce.Text);
            cmd.Parameters.AddWithValue("@P4", txtSube.Text);
            cmd.Parameters.AddWithValue("@P5", mtbIban.Text);
            cmd.Parameters.AddWithValue("@P6", mtbHesap.Text);
            cmd.Parameters.AddWithValue("@P7", txtYetkılı.Text);
            cmd.Parameters.AddWithValue("@P8", mtbTel.Text);
            cmd.Parameters.AddWithValue("@P9", mtbTarih.Text);
            cmd.Parameters.AddWithValue("@P10", txtHesapT.Text);
            cmd.Parameters.AddWithValue("@P11", luedFirmaAd.EditValue);//VALUEMEMBER DAKİ DEĞERİ YAZDIRIR.
            cmd.Parameters.AddWithValue("@P12", txtId.Text);
            cmd.ExecuteNonQuery();
            cnSql.connMSSQL().Close();
            MessageBox.Show("Banka güncellendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            lst();
            drop();
        }
    }
    
}

