using Dominio.Interfaces.Repositorios;
using Infra.Contexto;
using System.Data.Entity;
using System.Linq;

namespace Infra.Repositorios
{
    public class RepositorioBase<TEntity> : IRepositorioBase<TEntity> where TEntity : class
    {
        protected AgendaContexto Db = new AgendaContexto();

        public void Adicionar(TEntity obj)
        {
            Db.Set<TEntity>().Add(obj);
            Db.SaveChanges();
        }

        public void Atualizar(TEntity obj)
        {
            Db.Set<TEntity>().Attach(obj);
            Db.Entry(obj).State = EntityState.Modified;
            Db.SaveChanges();
        }

        public TEntity ObterPorId(int id)
        {
            return Db.Set<TEntity>().Find(id);
        }

        public System.Collections.Generic.IEnumerable<TEntity> ObterTudo()
        {
            return Db.Set<TEntity>().ToList();
        }

        public void Remover(TEntity obj)
        {
            Db.Set<TEntity>().Remove(obj);
            Db.SaveChanges();
        }
    }
}
