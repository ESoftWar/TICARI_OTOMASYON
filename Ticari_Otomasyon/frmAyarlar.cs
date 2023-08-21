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
    public partial class frmAyarlar : Form
    {
        public frmAyarlar()
        {
            InitializeComponent();
        }
        ConSQL cnSql = new ConSQL();
        ListSQL lstSql = new ListSQL();

        void lst()
        {
            gridControl1.DataSource = lstSql.lstKullaniciGiris();
        }
        private void frmAyarlar_Load(object sender, EventArgs e)
        {
            lst();
            txtKullanici.Text = "";
            txtSifre.Text = "";
            txtEskiSifre.Text = "";
        }


        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            if (dr != null)
            {
                txtKullanici.Text = dr["KULLANICIADI"].ToString();
                txtSifre.Text = dr["SIFRE"].ToString();
                txtEskiSifre.Text = dr["SIFRE"].ToString();
            }
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if (txtEskiSifre.Text != txtSifre.Text)
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO TBL_KULLANICIGIRIS VALUES (@P1,@P2,@P3)", cnSql.connMSSQL());
                cmd.Parameters.AddWithValue("@P1", txtKullanici.Text);
                cmd.Parameters.AddWithValue("@P2", txtSifre.Text);
                cmd.Parameters.AddWithValue("@P3", cbYetki.EditValue);
                cmd.ExecuteReader();
                cnSql.connMSSQL().Close();
                MessageBox.Show("Kaydetme işlemi başarıyla gerçekleşti..", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                lst();
            }
            else
            {
                MessageBox.Show("Lütfen alanları kontrol ediniz.", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void btnGun_Click(object sender, EventArgs e)
        {
            if (txtEskiSifre.Text!=txtSifre.Text && txtEskiSifre.Text!=""&&txtSifre.Text!="")
            {
                SqlCommand cmd = new SqlCommand("UPDATE TBL_KULLANICIGIRIS SET KULLANICIADI=@P1,SIFRE=@P2,YETKI=@P3 WHERE SIFRE=@P4", cnSql.connMSSQL());
                cmd.Parameters.AddWithValue("@P1", txtKullanici.Text);
                cmd.Parameters.AddWithValue("@P2", txtSifre.Text);
                cmd.Parameters.AddWithValue("@P3", cbYetki.EditValue);
                cmd.Parameters.AddWithValue("@P4", txtEskiSifre.Text);
                cmd.ExecuteNonQuery();
                cnSql.connMSSQL().Close();
                MessageBox.Show("Güncelleme işlemi başarıyla gerçekleşti..", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                lst();
                txtKullanici.Text = "";
                txtSifre.Text = "";
                txtEskiSifre.Text = "";
            }
            else
            {
                MessageBox.Show("Lütfen alanları kontrol ediniz. Eski şifre ile güncelleme yapınız.", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (txtEskiSifre.Text!="")
            {
                SqlCommand cmd = new SqlCommand("DELETE FROM TBL_KULLANICIGIRIS WHERE KULLANICIADI=@p1 AND SIFRE=@p2", cnSql.connMSSQL());
                cmd.Parameters.AddWithValue("@p1", txtKullanici.Text);
                cmd.Parameters.AddWithValue("@p2", txtEskiSifre.Text);
                cmd.ExecuteNonQuery();
                cnSql.connMSSQL().Close();
                MessageBox.Show("Silme işlemi başarıyla gerçekleşti..", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtKullanici.Text = "";
                txtSifre.Text = "";
                txtEskiSifre.Text = "";
                lst();

            }
            else
            {
                MessageBox.Show("Lütfen alanları kontrol ediniz.", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

    }
}
