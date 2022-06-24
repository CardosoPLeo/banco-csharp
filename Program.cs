using BancoCSharp.Models;

Console.WriteLine("*************************************");
Console.WriteLine("*********** Banco CSharp ************");
Console.WriteLine("*************************************");
Console.WriteLine();

var endereco = new Endereco()
{
    Cep = "25975-750",
    Rua = "XYZ",
    Bairro = "Teste"
};

var titular01 = new Titular("Leo","000.000.000-00","(21)99999-9999", endereco);
var conta01 = new ContaCorrente(titular01, 100.00, 1000.00);
//var conta02 = new ContaPoupanca(titular01, 0.00);
//var conta03 = new ContaInvestimento(titular01, 500.00);

conta01.Depositar(50.00);
//conta02.Depositar(500.00);
//conta03.Depositar(1000.00);

//conta02.Transferir(conta01,100.00);
//conta01.Sacar(200.00);
conta01.Sacar(50.00);
//conta03.Transferir(conta01, 200.00);

conta01.ImpprimirExtrato();
//conta02.ImpprimirExtrato();
//conta03.ImpprimirExtrato();
