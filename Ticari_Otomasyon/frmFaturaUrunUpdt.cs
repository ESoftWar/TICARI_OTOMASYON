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
    public partial class frmFaturaUrunUpdt : Form
    {
        public frmFaturaUrunUpdt()
        {
            InitializeComponent();
        }
        public string urunId;
        ConSQL cnSql = new ConSQL();
        void lst()
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM TBL_FATURADETAY Where FATURAURUNID = @p1",cnSql.connMSSQL());
            cmd.Parameters.AddWithValue("@p1", urunId);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                txtUrunId.Text = dr[0].ToString();
                txtUrunAd.Text = dr[1].ToString(); 
                txtModel.Text = dr[2].ToString();
                txtMiktar.Text = dr[3].ToString();
                txtFiyat.Text = dr[4].ToString();
                txtTutar.Text = dr[5].ToString();
                txtFaturaId2.Text = dr[6].ToString();
            }
        }
        private void frmFaturaUrunUpdt_Load(object sender, EventArgs e)
        {
            lst();
        }

        private void btnGun_Click(object sender, EventArgs e)
        {
            double miktar, tutar, fiyat;
            fiyat = double.Parse(txtFiyat.Text);
            miktar = double.Parse(txtMiktar.Text);
            tutar = miktar * fiyat;
            txtTutar.Text = tutar.ToString();

            SqlCommand cmd = new SqlCommand("UPDATE TBL_FATURADETAY SET URUNAD=@P1,MODEL=@P2,MIKTAR=@P3,FIYAT=@P4,TUTAR=@P5,DURUM=@P6 WHERE FATURAURUNID=@P7",cnSql.connMSSQL());
            cmd.Parameters.AddWithValue("@P1", txtUrunAd.Text);
            cmd.Parameters.AddWithValue("@P2", txtModel.Text);
            cmd.Parameters.AddWithValue("@P3", txtMiktar.Text);
            cmd.Parameters.AddWithValue("@P4", decimal.Parse(txtFiyat.Text));
            cmd.Parameters.AddWithValue("@P5", decimal.Parse(txtTutar.Text));
            cmd.Parameters.AddWithValue("@P6", true);
            cmd.Parameters.AddWithValue("@P7", txtUrunId.Text);
            cmd.ExecuteNonQuery();
            cnSql.connMSSQL().Close();
            MessageBox.Show("Fatura ürünü güncellendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            DialogResult secenek = MessageBox.Show("Ürünü yanlış girdiğiniz için mi silmek istiyorsunuz ?", "SORU", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if (secenek==DialogResult.Yes)
            {
                SqlCommand cmd1 = new SqlCommand("UPDATE TBL_FATURADETAY SET DURUM2=@p1 WHERE FATURAID = @p2", cnSql.connMSSQL());
                cmd1.Parameters.AddWithValue("@p1", true);
                cmd1.Parameters.AddWithValue("@p2", txtFaturaId2.Text);
                cmd1.ExecuteNonQuery();
                cnSql.connMSSQL().Close();
                SqlCommand cmd = new SqlCommand("DELETE FROM TBL_FATURADETAY WHERE FATURAURUNID=@p1", cnSql.connMSSQL());
                cmd.Parameters.AddWithValue("@p1", txtUrunId.Text);
                cmd.ExecuteNonQuery();
                cnSql.connMSSQL().Close();
                MessageBox.Show("Ürün silindi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (secenek == DialogResult.No)
            {
                SqlCommand cmd3 = new SqlCommand("DELETE FROM TBL_FATURADETAY WHERE FATURAID = @p1", cnSql.connMSSQL());
                cmd3.Parameters.AddWithValue("@p1", txtFaturaId2.Text);
                cmd3.ExecuteNonQuery();
                cnSql.connMSSQL().Close();
                MessageBox.Show("Ürün silindi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
