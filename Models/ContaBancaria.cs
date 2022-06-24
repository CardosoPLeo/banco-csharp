using BancoCSharp.Enums;

namespace BancoCSharp.Models
{
    public abstract class ContaBancaria
    {   
        #region Atributos     
        public Titular Titular { get; set; }
        public double Saldo { get; private set; }
        public DateTime DataAbertura { get; private set; }
        protected List<Movimentacao> MovimentacoesDeContas{get; set;}
        private readonly double VALOR_MINIMO = 10.00;        
        public double ChequeEspecial {get; private set;}

        #endregion
        
        #region Construtores
        public ContaBancaria(Titular titular, double saldoDeAbertura, double chequeEspecial)
        {
            Titular = titular;
            Saldo = saldoDeAbertura;
            DataAbertura = DateTime.Now;
            MovimentacoesDeContas = new List<Movimentacao>()
            {
                new Movimentacao(TipoMovimentacao.ABERTURA_CONTA, saldoDeAbertura)
            };
            ChequeEspecial = chequeEspecial;
            //var movimentacao = new Movimentacao(TipoMovimentacao.ABERTURA_CONTA, Saldo);
            // /Movimentacoes.Add(new Movimentacao(TipoMovimentacao.ABERTURA_CONTA, Saldo));
        }

        public ContaBancaria(Titular titular, double chequeEspecial)
        {
            Titular = titular;
            Saldo = 0;
            DataAbertura = DateTime.Now;
            MovimentacoesDeContas = new List<Movimentacao>()
            {
                new Movimentacao(TipoMovimentacao.ABERTURA_CONTA, Saldo)
            };
            ChequeEspecial = chequeEspecial;
        }
        #endregion

        #region Metodos
        public void Depositar(double valor)
        {
            if (valor < VALOR_MINIMO)
            {
                throw new Exception($"O Valor mínimo para depósito é R$ {VALOR_MINIMO}");                
            }

            Saldo += valor;
            MovimentacoesDeContas.Add(new Movimentacao(TipoMovimentacao.DEPOSITO, valor));
        }


        public double Sacar(double valor)
        {

            if (valor < VALOR_MINIMO)
            {
                throw new Exception($"O saque não pode ser efetuado pois o saldo é R$ {Saldo}");                
            }
            else if(valor > Saldo)
            {
                if (ChequeEspecial > 0.00 && valor <= ChequeEspecial)
                {
                    Saldo -= valor;
                    ChequeEspecial += Saldo;
                }
                //throw new Exception($"Saldo insuficiente o seu saldo é R$ {Saldo}");
            }else
            {
                Saldo -= valor;
            }

            MovimentacoesDeContas.Add(new Movimentacao(TipoMovimentacao.SAQUE, valor));
            return valor;
        }

        public void Transferir(ContaBancaria contaDestino, double valor)
        {
            if (valor < VALOR_MINIMO)
            {
                throw new Exception($"O seu saldo é insuficiente para realizar a trânsferencia {Saldo}");
            }
            else if(valor > Saldo)
            {
                throw new Exception($"Saldo insuficiente para realizar a trânsferencia o seu saldo é R$ {Saldo}");                
            }

            contaDestino.Depositar(valor);
            Saldo -= valor;
            MovimentacoesDeContas.Add(new Movimentacao(TipoMovimentacao.TRASNFERENCIA, valor));

        }
        public abstract void ImpprimirExtrato();
        
        #endregion

    }
}