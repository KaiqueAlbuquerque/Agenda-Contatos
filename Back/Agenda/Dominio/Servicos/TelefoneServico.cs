using System.Collections.Generic;
using System.Linq;
using Dominio.Entidades;
using Dominio.Interfaces.Repositorios;
using Dominio.Interfaces.Servicos;

namespace Dominio.Servicos
{
    public class TelefoneServico : ServicoBase<Telefone>, ITelefoneServico
    {
        private readonly ITelefoneRepositorio _telefoneRepositorio;

        public TelefoneServico(ITelefoneRepositorio telefoneRepositorio)
            : base(telefoneRepositorio)
        {
            _telefoneRepositorio = telefoneRepositorio;
        }
    }
}
