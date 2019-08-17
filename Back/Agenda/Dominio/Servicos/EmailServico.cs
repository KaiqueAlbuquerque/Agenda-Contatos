using System.Collections.Generic;
using System.Linq;
using Dominio.Entidades;
using Dominio.Interfaces.Repositorios;
using Dominio.Interfaces.Servicos;

namespace Dominio.Servicos
{
    public class EmailServico : ServicoBase<Email>, IEmailServico
    {
        private readonly IEmailRepositorio _emailRepositorio;

        public EmailServico(IEmailRepositorio emailRepositorio)
            : base(emailRepositorio)
        {
            _emailRepositorio = emailRepositorio;
        }
    }
}
