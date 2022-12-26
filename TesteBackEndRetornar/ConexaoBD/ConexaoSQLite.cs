using System.Data.SQLite;

namespace TesteBackEndRetornar.ConexaoBD;

class ConexaoSQLite
{
    public SQLiteConnection con = new SQLiteConnection("Data Source=" + Globais.caminhoBanco + Globais.nomeBanco);
    public void AbrirCon()
    {
		try
		{
			con.Open();

		}
		catch (Exception)
		{

			throw;
		}
    }
    public void FecharCon()
    {
        try
        {
            con.Close();
            con.Dispose();

        }
        catch (Exception)
        {

            throw;
        }
    }
}
