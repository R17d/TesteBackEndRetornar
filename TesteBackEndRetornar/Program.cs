using Microsoft.AspNetCore.Mvc;
using TesteBackEndRetornar;
using TesteBackEndRetornar.ConexaoBD;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/sortear/{nome}/{telefone}/{cpf}/{email}", ([FromRoute] string nome, string telefone, string cpf, string email) =>
{

    Random rand = new Random();
    int numSorteado = rand.Next(0, 99999);

    Cliente cliente = new Cliente()
    {
        nome = nome,
        telefone = telefone,
        cpf = cpf,
        email = email,
        numSorteado = numSorteado
    };

    cliente.IsNumberExists();

    if (cliente.IsEmailExists())
        return Results.Conflict("E-mail: " + cliente.email + " já existe!");

    cliente.SaveClient();

    cliente.SaveFile();

    return Results.Ok("Sucesso!");
});

app.Run();

