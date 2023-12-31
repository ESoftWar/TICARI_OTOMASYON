﻿using System;
using System.Collections;
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
    public partial class frmMusteriler : Form
    {
        public frmMusteriler()
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
            txtSoyad.Text = "";
            mtbTel.Text = "";
            mtbTel2.Text = "";
            mtbTC.Text = "";
            txtMail.Text = "";
            cmbIl.SelectedItem = null;
            cmbIlce.SelectedItem = null;
            rtbAdres.Text = "";
            txtVergiD.Text = "";
        }
        void lst()
        {
            //Grid Control' e dönen değerleri yolluyoruz.
            gridControl1.DataSource = lstSql.lstMusteriler();
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


        private void frmMusteriler_Load(object sender, EventArgs e)
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
                txtSoyad.Text = dr["SOYAD"].ToString();
                mtbTel.Text = dr["TELEFON"].ToString();
                mtbTel2.Text = dr["TELEFON2"].ToString();
                mtbTC.Text = dr["TC"].ToString();
                txtMail.Text = dr["MAIL"].ToString();
                cmbIl.SelectedItem = dr["IL"].ToString();
                cmbIlce.SelectedItem = dr["ILCE"].ToString();
                rtbAdres.Text = dr["ADRES"].ToString();
                txtVergiD.Text = dr["VERGIDAIRE"].ToString();
        }



        private void btnKaydet_Click(object sender, EventArgs e)
        {

                SqlCommand cmd = new SqlCommand
                (
                "Insert Into TBL_MUSTERILER(AD,SOYAD,TELEFON,TELEFON2,TC,MAIL,IL,ILCE,ADRES,VERGIDAIRE)values(@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9,@p10) ",cnSql.connMSSQL());
                cmd.Parameters.AddWithValue("@p1", txtAd.Text);
                cmd.Parameters.AddWithValue("@p2", txtSoyad.Text);
                cmd.Parameters.AddWithValue("@p3", mtbTel.Text);
                cmd.Parameters.AddWithValue("@p4", mtbTel2.Text);
                cmd.Parameters.AddWithValue("@p5", mtbTC.Text);
                cmd.Parameters.AddWithValue("@p6", txtMail.Text);
                cmd.Parameters.AddWithValue("@p7", cmbIl.Text);
                cmd.Parameters.AddWithValue("@p8", cmbIlce.Text);
                cmd.Parameters.AddWithValue("@p9", rtbAdres.Text);
                cmd.Parameters.AddWithValue("@p10", txtVergiD.Text);
                cmd.ExecuteNonQuery();
                cnSql.connMSSQL().Close();
                MessageBox.Show("Müşteri sisteme eklendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                lst();
                drop();

            
        }
        private void btnSil_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("Delete From TBL_MUSTERILER where ID=@p1", cnSql.connMSSQL());
            cmd.Parameters.AddWithValue("@p1", txtId.Text);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Müşteri silindi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            lst();
            drop();
        }
        private void btnGuncel_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("Update TBL_MUSTERILER SET AD=@P1,SOYAD=@P2,TELEFON=@P3,TELEFON2=@P4,TC=@P5,MAIL=@P6,IL=@P7,ILCE=@P8,ADRES=@P9,VERGIDAIRE=@P10 Where ID = @P11", cnSql.connMSSQL());
            cmd.Parameters.AddWithValue("@P1", txtAd.Text);
            cmd.Parameters.AddWithValue("@P2", txtSoyad.Text);
            cmd.Parameters.AddWithValue("@P3", mtbTel.Text);
            cmd.Parameters.AddWithValue("@P4", mtbTel2.Text);
            cmd.Parameters.AddWithValue("@P5", mtbTC.Text);
            cmd.Parameters.AddWithValue("@P6", txtMail.Text);
            cmd.Parameters.AddWithValue("@P7", cmbIl.SelectedItem);
            cmd.Parameters.AddWithValue("@P8", cmbIlce.SelectedItem);
            cmd.Parameters.AddWithValue("@P9", rtbAdres.Text);
            cmd.Parameters.AddWithValue("@P10", txtVergiD.Text);
            cmd.Parameters.AddWithValue("@P11",txtId.Text);
            cmd.ExecuteNonQuery();
            cnSql.connMSSQL().Close();
            MessageBox.Show("Müşteri güncellendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            lst();
            drop();
        }

        
    }
}
