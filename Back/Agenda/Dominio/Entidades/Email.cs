using System;

namespace Dominio.Entidades
{
    public class Email
    {
        public int EmailId { get; set; }
        public string EmailContato { get; set; }
        public int ContatoId { get; set; }
        public virtual Contato Contato { get; set; }
        public bool Ativo { get; set; }
        public DateTime DataCadastro { get; set; }
    }
}
