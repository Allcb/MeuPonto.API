using MeuPonto.Domain.Interfaces.Repositories;
using MeuPonto.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace MeuPonto.Infra.Data.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        #region Campos Protegidos

        protected readonly MeuPontoContext _context;

        #endregion Campos Protegidos

        #region Construtores Publicos

        public Repository(MeuPontoContext context)
        {
            _context = context;
        }

        #endregion Construtores Publicos

        #region Propriedades Publicas

        public DbSet<TEntity> DbSet
        {
            get
            {
                return _context.Set<TEntity>();
            }
        }

        #endregion Propriedades Publicas

        #region Metodos Publicos

        #region Metodos Busca

        public TEntity Find(params object[] Keys)
        {
            try
            {
                return DbSet.Find(Keys);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public TEntity Find(Expression<Func<TEntity, bool>> where)
        {
            try
            {
                return DbSet.SingleOrDefault(where);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IQueryable<TEntity> Query()
        {
            return DbSet;
        }

        public IQueryable<TEntity> Query(Expression<Func<TEntity, bool>> where)
        {
            try
            {
                return DbSet.Where(where);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IQueryable<TEntity> Query(Expression<Func<TEntity, bool>> predicate, Func<IQueryable<TEntity>, object> includes)
        {
            try
            {
                IQueryable<TEntity> _query = DbSet;

                if (includes != null)
                    _query = includes(_query) as IQueryable<TEntity>; ;

                return _query.Where(predicate).AsQueryable();
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion Metodos Busca

        #region Metodos Criar

        public async Task<TEntity> CreateAsync(TEntity model)
        {
            try
            {
                await DbSet.AddAsync(model);

                return model;
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion Metodos Criar

        public void SetCommandTimeout(int commandTimeout) => _context.Database.SetCommandTimeout(commandTimeout);

        public void Dispose()
        {
            try
            {
                if (_context != null)
                    _context.Dispose();

                GC.SuppressFinalize(this);
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion Metodos Publicos
    }
}