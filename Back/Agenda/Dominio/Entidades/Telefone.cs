using System;

namespace Dominio.Entidades
{
    public class Telefone
    {
        public int TelefoneId { get; set; }
        public string TelefoneContato { get; set; }
        public int ContatoId { get; set; }
        public virtual Contato Contato { get; set; } 
        public bool Ativo { get; set; }
        public DateTime DataCadastro { get; set; } 
    }
}
