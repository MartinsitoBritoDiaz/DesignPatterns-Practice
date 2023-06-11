using DesignPatterns.Models.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private DesignPatternDbContext _context;
        private DbSet<TEntity> _dbSet;

        public Repository(DesignPatternDbContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }

        void IRepository<TEntity>.Add(TEntity entity) => _dbSet.Add(entity);

        void IRepository<TEntity>.Delete(int id)
        {
            var dbEntity = _dbSet.Find(id);
            _dbSet.Remove(dbEntity);
        }

        IEnumerable<TEntity> IRepository<TEntity>.GetAll() => _dbSet.ToList();

        TEntity IRepository<TEntity>.GetById(int id) => _dbSet.Find(id);

        void IRepository<TEntity>.Save()
        {
            _context.SaveChanges();
        }

        void IRepository<TEntity>.Update(TEntity entity)
        {
            _dbSet.Attach(entity);
            _dbSet.Update(entity);
        }
    }
}
