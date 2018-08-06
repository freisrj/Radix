using Microsoft.EntityFrameworkCore;
using Radix.Domain.Services.Contracts.Infra.Data.Repositories.Base;
using Radix.Infra.Data.Imp.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Radix.Infra.Data.Imp.Repositories.Base
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly DbContextRadix Context;

        public Repository(DbContextRadix context) { Context = context; }

        public Task Add(TEntity entity) => Context.Set<TEntity>().AddAsync(entity);

        public async Task<List<TEntity>> Find(Expression<Func<TEntity, bool>> predicate) =>
               await Context.Set<TEntity>().Where(predicate).ToListAsync();

        public async Task<TEntity> Get(int id) => await Context.Set<TEntity>().FindAsync(id);

        public async Task<List<TEntity>> GetAll() => await Context.Set<TEntity>().ToListAsync();
    }
}
