using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Database işlemleri için gerekli namespace.
using System.Data.SqlClient;

namespace Ticari_Otomasyon
{
    class ConSQL
    {
        //Geriye değer döndüren metodumuz.
        public SqlConnection connMSSQL()
        {
            //Sql bağlantı komutları.
            SqlConnection conn = new SqlConnection(@"Data Source=DATABASENAME;Initial Catalog=DboTicariOtomasyon;Integrated Security=True");
            conn.Open();
            return conn;
        }
    }
}
