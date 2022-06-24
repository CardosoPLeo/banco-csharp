namespace BancoCSharp.Models
{
    public class ContaInvestimento : ContaBancaria
    {
        public ContaInvestimento(Titular titular, double saldoDeAbertura) : base(titular, saldoDeAbertura)
        {
        }

        public override void ImpprimirExtrato()
        {
            Console.WriteLine("*************************************");
            Console.WriteLine("***** Extrato Conta Investmento *****");
            Console.WriteLine("*************************************");
            Console.WriteLine();

            Console.WriteLine($"Gerado em {DateTime.Now}");
            Console.WriteLine();

            foreach(var movimentacao in MovimentacoesDeContas)
            {
                Console.WriteLine(movimentacao.ToString());
            }

            Console.WriteLine();
            Console.WriteLine($"Saldo atual: R${Saldo}");

            Console.WriteLine();
            Console.WriteLine("*************************************");
            Console.WriteLine("************ Fim do Extrato *********");
            Console.WriteLine("*************************************");
            Console.WriteLine();
        }
    }
}