using System.Collections.Generic;

namespace Dominio.Interfaces.Servicos
{
    public interface IServicoBase<TEntity> where TEntity : class
    {
        void Adicionar(TEntity obj);
        TEntity ObterPorId(int id);
        IEnumerable<TEntity> ObterTudo();
        void Atualizar(TEntity obj);
        void Remover(TEntity obj);
    }
}
