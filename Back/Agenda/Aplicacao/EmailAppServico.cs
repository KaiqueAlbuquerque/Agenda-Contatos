using Aplicacao.Interfaces;
using Dominio.Entidades;
using Dominio.Interfaces.Servicos;

namespace Aplicacao
{
    public class EmailAppServico : AppServicoBase<Email>, IEmailAppServico
    {
        private readonly IEmailServico _emailServico;

        public EmailAppServico(IEmailServico emailServico)
            : base(emailServico)
        {
            _emailServico = emailServico;
        }
    }
}
