using System;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace ProAgil.API.Data
{
    public abstract class Repository<TEntity, TDbContext> where TEntity : class
                                                        where TDbContext : DbContext
    {
        protected TEntity _entity;

        protected TDbContext _dbContext;

        public Repository(TEntity entity, TDbContext dbContext)
        {
            _entity = entity;
            _dbContext = dbContext; //barril
        }
        public static void Delete(Expression<Func<TEntity, bool>> expression)
        {
            //var primaryKey = _entity.GetType().GetProperties().First(x => x.GetCustomAttributes(false).Any(a => a.GetType() == typeof(KeyAttribute)));
            //_dbContext.Set<TEntity>().Where(expression).Select(a => new { primaryKey }).Cast<TEntity>();
        }
    }
} 