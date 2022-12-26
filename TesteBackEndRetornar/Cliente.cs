using System.Data;
using TesteBackEndRetornar.ConexaoBD;

namespace TesteBackEndRetornar;

public class Cliente
{
    public void SaveClient()
    {
        var query = string.Format(@"
                INSERT INTO
                       clientes
                       (nome, telefone, cpf, email, numSorteado)
                VALUES ('{0}','{1}','{2}','{3}','{4}')", nome, telefone, cpf, email, numSorteado);

        SqlInsert.Insert(query);
        return;
    }
    public void SaveFile()
    {
        StreamWriter sw = new StreamWriter(Globais.caminhoFile);
        sw.WriteLine("Nome:            " + nome);
        sw.WriteLine("Telefone:        " + telefone);
        sw.WriteLine("CPF:             " + cpf);
        sw.WriteLine("E-mail:          " + email);
        sw.WriteLine("Num Sorteado:    " + numSorteado);
        sw.Close();
    }
    public bool IsEmailExists()
    {
        var query = string.Format(@"SELECT *FROM clientes WHERE email = '{0}'", email);
        DataTable dt;
        dt = SqlConsultas.strSQL(query);

        if(dt.Rows.Count > 0)
        {
            return true;
        }

        return false;
    }
    public void IsNumberExists()
    {
        var query = string.Format(@"SELECT *FROM clientes WHERE numSorteado = '{0}'", numSorteado);
        DataTable dt;
        dt = SqlConsultas.strSQL(query);

        if (dt.Rows.Count > 0)
        {
            Random rand = new Random();
            numSorteado = rand.Next(0, 99999);

        }
    }


    public string? nome { get; set; }
    public string? telefone { get; set; }
    public string? cpf { get; set; }
    public string? email { get; set; }
    public int? numSorteado { get; set; } 
}

