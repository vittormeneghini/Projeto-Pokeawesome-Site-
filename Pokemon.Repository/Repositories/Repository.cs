using Microsoft.EntityFrameworkCore;
using Pokemon.Models.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pokemon.Repository.Repositories
{
    public class Repository<TEntity> : IDisposable, IRepository<TEntity> where TEntity : class
    {
        public PokemonContext _context = new PokemonContext();

        public virtual void Insert(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
        }

        public virtual void Update(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }

        public void SaveAll()
        {
            _context.SaveChanges();
        }

        public void Delete(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
        }

        public IEnumerable<TEntity> ListByParameter(Func<TEntity, bool> predicate)
        {
            return ListAll().Where(predicate);
        }

        public IEnumerable<TEntity> ListAll()
        {
            return _context.Set<TEntity>();
        }

        public TEntity FindById(object id)
        {
            return _context.Set<TEntity>().Find(id);
        }

        public TEntity FindByParameter(Func<TEntity, bool> predicate)
        {
            return _context.Set<TEntity>().Where(predicate).FirstOrDefault();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
