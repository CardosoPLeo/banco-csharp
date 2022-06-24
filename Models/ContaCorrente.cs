namespace BancoCSharp.Models
{
    public class ContaCorrente : ContaBancaria
    {
        public ContaCorrente(Titular titular, double saldoDeAbertura, double chequeEspecial) 
            : base(titular, saldoDeAbertura, chequeEspecial)
        {
            
        }

        public override void ImpprimirExtrato()
        {
            Console.WriteLine("*************************************");
            Console.WriteLine("****** Extrato Conta Corretnte ******");
            Console.WriteLine("*************************************");
            Console.WriteLine();

            Console.WriteLine($"Gerado em {DateTime.Now}");
            Console.WriteLine();

            foreach(var movimentacao in MovimentacoesDeContas)
            {
                Console.WriteLine(movimentacao.ToString());
            }

            Console.WriteLine();
            Console.WriteLine($"Saldo atual da conta: R${Saldo}");
            Console.WriteLine($"Saldo Cheque Especial: R${ChequeEspecial}");


            Console.WriteLine();
            Console.WriteLine("*************************************");
            Console.WriteLine("************ Fim do Extrato *********");
            Console.WriteLine("*************************************");
            Console.WriteLine();
        }
    }
}