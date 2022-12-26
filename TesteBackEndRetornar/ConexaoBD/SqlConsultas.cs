using System.Data;
using System.Data.SQLite;

namespace TesteBackEndRetornar.ConexaoBD;

public class SqlConsultas
{
    public static DataTable strSQL(string sql)
    {
        try
        {
            DataTable dt = new DataTable();
            ConexaoSQLite conexaoSQLite = new ConexaoSQLite();
            conexaoSQLite.AbrirCon();
            var cmd = conexaoSQLite.con.CreateCommand();
            cmd.CommandText = sql;
            SQLiteDataAdapter dados = new SQLiteDataAdapter(sql, conexaoSQLite.con.ConnectionString);
            dados.Fill(dt);
            return dt;
        }
        catch (Exception)
        {

            throw;
        }

    }
}
