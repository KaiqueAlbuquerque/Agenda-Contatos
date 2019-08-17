using System.Collections.Generic;
using Dominio.Interfaces.Repositorios;
using Dominio.Interfaces.Servicos;

namespace Dominio.Servicos
{ 
    public class ServicoBase<TEntity> : IServicoBase<TEntity> where TEntity : class
    {
        private readonly IRepositorioBase<TEntity> _repositorio;

        public ServicoBase(IRepositorioBase<TEntity> repositorio)
        {
            _repositorio = repositorio;
        }

        public void Adicionar(TEntity obj)
        {
            _repositorio.Adicionar(obj);
        }

        public void Atualizar(TEntity obj)
        {
            _repositorio.Atualizar(obj);
        }

        public TEntity ObterPorId(int id)
        {
            return _repositorio.ObterPorId(id);
        }

        public IEnumerable<TEntity> ObterTudo()
        {
            return _repositorio.ObterTudo();
        }

        public void Remover(TEntity obj)
        {
            _repositorio.Remover(obj);
        }
    }
}
