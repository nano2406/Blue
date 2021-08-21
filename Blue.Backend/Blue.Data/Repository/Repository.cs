using Blue.Domain.Interface;
using Blue.Domain.Modelos;
using Blue.Infra.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Blue.Infra.Repository
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity, new()
    {
        protected readonly BlueContext _Db;
        protected readonly DbSet<TEntity> _DbSet;

        protected Repository(BlueContext db)
        {
            _Db = db;
            _DbSet = db.Set<TEntity>();
        }

        public virtual async Task<TEntity> ObterPorId(Guid id)
        {
            return await _DbSet.FindAsync(id);
        }

        public virtual async Task<List<TEntity>> ObterTodos()
        {
            return await _DbSet.ToListAsync();
        }

        public virtual async Task Adicionar(TEntity entity)
        {
            _DbSet.Add(entity);
            await SaveChanges();
        }

        public virtual async Task<TEntity> Atualizar(TEntity entity)
        {
            _DbSet.Update(entity);
             await SaveChanges();
            return entity;
        }

        public virtual async Task Remover(Guid id)
        {
            _DbSet.Remove(new TEntity { Id = id });
            await SaveChanges();
        }

        public async Task<int> SaveChanges()
        {
            return await _Db.SaveChangesAsync();
        }

        public void Dispose()
        {
            _Db?.Dispose();
        }
    }
}
