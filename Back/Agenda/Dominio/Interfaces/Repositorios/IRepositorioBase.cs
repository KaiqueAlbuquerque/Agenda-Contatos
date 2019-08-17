﻿using System.Collections.Generic;

namespace Dominio.Interfaces.Repositorios
{
    public interface IRepositorioBase<TEntity> where TEntity : class
    {
        void Adicionar(TEntity obj);
        TEntity ObterPorId(int id);
        IEnumerable<TEntity> ObterTudo();
        void Atualizar(TEntity obj);
        void Remover(TEntity obj);
    }
}
