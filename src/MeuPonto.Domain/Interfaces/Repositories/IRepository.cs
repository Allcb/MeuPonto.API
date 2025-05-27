using System.Linq.Expressions;

namespace MeuPonto.Domain.Interfaces.Repositories
{
    public interface IRepository<TEntity> : IDisposable where TEntity : class
    {
        #region Metodos Busca

        TEntity Find(params object[] Keys);

        TEntity Find(Expression<Func<TEntity, bool>> where);

        IQueryable<TEntity> Query();

        IQueryable<TEntity> Query(Expression<Func<TEntity, bool>> where);

        IQueryable<TEntity> Query(Expression<Func<TEntity, bool>> predicate, Func<IQueryable<TEntity>, object> includes);

        Task<TEntity> CreateAsync(TEntity model);

        #endregion Metodos Busca
    }
}