using Aplicacao.Interfaces;
using Dominio.Interfaces.Servicos;
using System.Collections.Generic;

namespace Aplicacao
{
    public class AppServicoBase<TEntity> : IAppServicoBase<TEntity> where TEntity : class
    {
        private readonly IServicoBase<TEntity> _servicoBase;

        public AppServicoBase(IServicoBase<TEntity> servicoBase)
        {
            _servicoBase = servicoBase;
        }

        public void Adicionar(TEntity obj)
        {
            _servicoBase.Adicionar(obj);
        }

        public void Atualizar(TEntity obj)
        {
            _servicoBase.Atualizar(obj);
        }

        public TEntity ObterPorId(int id)
        {
            return _servicoBase.ObterPorId(id);
        }

        public IEnumerable<TEntity> ObterTudo()
        {
            return _servicoBase.ObterTudo();
        }

        public void Remover(TEntity obj)
        {
            _servicoBase.Remover(obj);
        }
    }
}
