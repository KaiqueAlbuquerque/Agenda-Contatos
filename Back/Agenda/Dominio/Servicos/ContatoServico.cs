using Dominio.Entidades;
using Dominio.Interfaces.Repositorios;
using Dominio.Interfaces.Servicos;

namespace Dominio.Servicos
{
    public class ContatoServico : ServicoBase<Contato>, IContatoServico
    {
        private readonly IContatoRepositorio _contatoRepositorio;

        public ContatoServico(IContatoRepositorio contatoRepositorio)
            :base(contatoRepositorio)
        {
            _contatoRepositorio = contatoRepositorio;
        }
    }
}
