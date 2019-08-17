using Dominio.Entidades;
using System.Collections.Generic;

namespace Aplicacao.Interfaces
{
    public interface IContatoAppServico : IAppServicoBase<Contato>
    {
        void CadastrarContato(Contato contato);

        Contato ObterContato(int idContato);

        void AtualizarContato(Contato contato);

        void ExcluirContato(int idContato);
    }
}
