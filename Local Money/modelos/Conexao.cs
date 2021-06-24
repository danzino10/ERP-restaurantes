using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;


namespace Local_Money
{
    class Conexao
    {
        const string conexao_string = @"Data Source=DANZ;Initial Catalog=local_money;Persist Security Info=True;User ID=sa;Password=MestreFigas12";
        //  Data Source=DANZ;Initial Catalog=local_money;Persist Security Info=True;User ID=sa;Password=***********
        //  DESKTOP-99UBTBS
        SqlConnection conn;
 
        public Conexao() => conn = new SqlConnection(conexao_string);

        public void abrir() => conn.Open();
        public void fechar() => conn.Close();

        public SqlConnection SaberConexao() => conn;
    }
    
}
