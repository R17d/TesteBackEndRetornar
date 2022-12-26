namespace TesteBackEndRetornar.ConexaoBD;

public class SqlInsert
{
    public static void Insert(string query)
    {
		try
		{
			ConexaoSQLite conexaoSQLite = new ConexaoSQLite();
			conexaoSQLite.AbrirCon();
			var cmd = conexaoSQLite.con.CreateCommand();
			cmd.CommandText = query;
			cmd.ExecuteNonQuery();
			conexaoSQLite.FecharCon();
		}
		catch (Exception)
		{

			throw;
		}
    }
}
