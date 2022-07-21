using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gplus.Dao
{
    public class ConexaoSql
    {

        SqlConnection conn = new SqlConnection();
        public ConexaoSql(string instancia,string usuario,string nomeBanco,string senha)
        {
            conn.ConnectionString = @"Data Source = " + instancia + "; Initial Catalog =" + nomeBanco + "; User ID =" + usuario + "; pwd =" + senha + ";";
        }


        public SqlConnection conectarBancoSQL()
        {
            if(conn.State == System.Data.ConnectionState.Closed)
            {
                conn.Open();
            }
            return conn;
        }

        public void desconectarBancoSQL()
        {
            if (conn.State == System.Data.ConnectionState.Open)
            {
                conn.Close();
            }
        }
    }


}
