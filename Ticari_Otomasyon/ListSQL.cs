using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using DevExpress.XtraGrid;
using System.Data;
using System.Collections;

namespace Ticari_Otomasyon
{
    class ListSQL
    {
        //Bağlantımız için sınıfımızı tanımlıyoruz.
        ConSQL cnSql = new ConSQL();

        //Ürünler için listeleme.
        public object lstUrunler()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * From TBL_URUNLER", cnSql.connMSSQL());
            da.Fill(dt);
            return dt;
        }
        public object lstUrun()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select URUNAD,MODEL From TBL_URUNLER", cnSql.connMSSQL());
            da.Fill(dt);
            return dt;
        }
        
        //Müşteriler için listeleme.
        public object lstMusteriler()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * From TBL_MUSTERILER", cnSql.connMSSQL());
            da.Fill(dt);
            return dt;
        }
        public object lstMusterilerRehber()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select AD,SOYAD,TELEFON,TELEFON2,MAIL From TBL_MUSTERILER", cnSql.connMSSQL());
            da.Fill(dt);
            return dt;
        }
        

        //Firmalar için listeleme.
        public object lstFirmalar()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * From TBL_FIRMALAR", cnSql.connMSSQL());
            da.Fill(dt);
            return dt;
        }
        public object lstFirmaAd()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select ID,AD From TBL_FIRMALAR", cnSql.connMSSQL());
            da.Fill(dt);
            return dt;
        }
        public object lstFirmalarRehber()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select AD,SEKTOR,YETKILISTATU,YETKILIADSOYAD,TELEFON1,TELEFON2,TELEFON3,MAIL,FAX From TBL_FIRMALAR", cnSql.connMSSQL());
            da.Fill(dt);
            return dt;
        }

        //Personeller için listeleme.
        public object lstPersoneller()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * From TBL_PERSONELLER", cnSql.connMSSQL());
            da.Fill(dt);
            return dt;
        }

        //Giderler için listeleme
        public object lstGiderler()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * From TBL_GIDERLER", cnSql.connMSSQL());
            da.Fill(dt);
            return dt;
        }

        //Bankalar için listeleme
        public object lstBankalar()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("EXEC BANKABILGILERI", cnSql.connMSSQL());
            da.Fill(dt);
            return dt;
        }

        //Fatura Bilgi için listeleme
        public object lstFaturaB()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * From TBL_FATURABILGI", cnSql.connMSSQL());
            da.Fill(dt);
            return dt;
        }
        //Fatura Detay için listeleme
        public object lstFaturaD(int id)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("SELECT FATURAURUNID,URUNAD,MODEL,MIKTAR,FIYAT,TUTAR,FATURAID FROM TBL_FATURADETAY Where FATURAID = '"+id+"'", cnSql.connMSSQL());
            da.Fill(dt);
            return dt;
        }

        string fiyat;
        public string lstFiyat(string model)
        {     
            SqlCommand cmd = new SqlCommand("SELECT SATISFIYAT FROM TBL_URUNLER WHERE MODEL=@P1", cnSql.connMSSQL());
            cmd.Parameters.AddWithValue("@P1", model);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                fiyat = dr[0].ToString();
            }   
            return fiyat;
        }

        //Notlar Bilgi için listeleme
        public object lstNotlar()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * From TBL_NOTLAR", cnSql.connMSSQL());
            da.Fill(dt);
            return dt;
        }

        //FirmaHareketler listeleme
        public object lstFirmaHareketler()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("EXEC FIRMAHAREKETLER", cnSql.connMSSQL());
            da.Fill(dt);
            return dt;
        }

        //MusteriHareketler listeleme
        public object lstMusteriHareketler()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("EXEC MUSTERIHAREKETLER", cnSql.connMSSQL());
            da.Fill(dt);
            return dt;
        }

        //Stok listeleme
        public object lstStok()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("SELECT URUNAD,SUM(ADET) AS ADET FROM TBL_URUNLER GROUP BY URUNAD", cnSql.connMSSQL());
            da.Fill(dt);
            return dt;
        }

        //Kullanıcı listeleme
        public object lstKullaniciGiris()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * From TBL_KULLANICIGIRIS", cnSql.connMSSQL());
            da.Fill(dt);
            return dt;
        }
        public object lstStoklarYirmi()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("SELECT URUNAD,SUM(ADET) AS 'ADET' FROM TBL_URUNLER GROUP BY URUNAD HAVING SUM(ADET)<=20 ORDER BY SUM(ADET)", cnSql.connMSSQL());
            da.Fill(dt);
            return dt;
        }
        public object lstAjanda()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("SELECT TOP 5 TARIH,SAAT,BASLIK,DETAY FROM TBL_NOTLAR ORDER BY ID DESC", cnSql.connMSSQL());
            da.Fill(dt);
            return dt;
        }
        public object lstSonOn()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("EXEC FIRMASONON", cnSql.connMSSQL());
            da.Fill(dt);
            return dt;
        }
        public object lstFihrist()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("SELECT DISTINCT AD,TELEFON1 FROM TBL_FIRMALAR", cnSql.connMSSQL());
            da.Fill(dt);
            return dt;
        }

        

    }
 }

