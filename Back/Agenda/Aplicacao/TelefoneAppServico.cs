using Aplicacao.Interfaces;
using Dominio.Entidades;
using Dominio.Interfaces.Servicos;

namespace Aplicacao
{
    public class TelefoneAppServico : AppServicoBase<Telefone>, ITelefoneAppServico
    {
        private readonly ITelefoneServico _telefoneServico;

        public TelefoneAppServico(ITelefoneServico telefoneServico)
            : base(telefoneServico)
        {
            _telefoneServico = telefoneServico;
        }
    }
}
