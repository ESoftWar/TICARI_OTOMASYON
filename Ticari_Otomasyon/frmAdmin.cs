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
    public partial class frmAdmin : Form
    {
        public frmAdmin()
        {
            InitializeComponent();
        }
        ConSQL cnSql = new ConSQL();
        private void btnCik_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        
        private void btnGiris_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM TBL_KULLANICIGIRIS WHERE KULLANICIADI=@P1 AND SIFRE=@P2",cnSql.connMSSQL());
            cmd.Parameters.AddWithValue("@P1",txtKullanici.Text);
            cmd.Parameters.AddWithValue("@P2",txtSifre.Text);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                
                Form1 frm = new Form1();
                frm.kullanici = txtKullanici.Text;
                frm.yetki = Boolean.Parse(dr[2].ToString());
                frm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("HATALI KULLANICI ADI VEYA ŞİFRE", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            cnSql.connMSSQL().Close();
        }
    }
}
