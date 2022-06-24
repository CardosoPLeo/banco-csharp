namespace BancoCSharp.Models
{
    public class Titular
    {
        #region Atributos
        public string Nome { get; set; } 
        public string CPF { get; set; }
        public string Telefone { get; set; }    
        public Endereco Endereco { get; set; }
        #endregion

        #region Construtores
        public Titular(string nome, string cpf, string telefone)
        {
            Nome = nome;
            CPF = cpf;
            Telefone = telefone;
        }

        public Titular(string nome, string cpf, string telefone, Endereco endereco)
        {
            Nome = nome;
            CPF = cpf;
            Telefone = telefone;
            Endereco = endereco;
        }
        #endregion

    }
}