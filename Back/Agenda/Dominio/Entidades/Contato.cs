using System;
using System.Collections.Generic;

namespace Dominio.Entidades
{
    public class Contato
    {
        public int ContatoId { get; set; }
        public string Nome { get; set; }
        public virtual IEnumerable<Telefone> Telefones { get; set; }
        public virtual IEnumerable<Email> Emails { get; set; }
        public bool Ativo { get; set; }
        public DateTime DataCadastro { get; set; }
    }
}
