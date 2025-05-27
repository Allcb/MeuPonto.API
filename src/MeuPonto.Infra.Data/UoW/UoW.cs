using MeuPonto.Domain.Interfaces.UoW;
using MeuPonto.Infra.Data.Context;

namespace MeuPonto.Infra.Data.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        #region Campos Privados

        private readonly MeuPontoContext _MeuPontoContext;
        private Exception _exception;

        #endregion Campos Privados

        #region Construtores Publicos

        public UnitOfWork(MeuPontoContext MeuPontoContext)
        {
            _MeuPontoContext = MeuPontoContext;
        }

        #endregion Construtores Publicos

        #region Metodos Publicos

        public bool Commit()
        {
            try
            {
                int _commited = _MeuPontoContext.SaveChanges();

                return _commited > 0;
            }
            catch (Exception ex)
            {
                SetCommitException(ex.InnerException ?? ex);

                return false;
            }
        }

        public string GetCommitExceptionMessage()
        {
            return _exception?.Message;
        }

        public void Dispose()
        {
            _MeuPontoContext.Dispose();
        }

        #endregion Metodos Publicos

        #region Metodos Privados

        private void SetCommitException(Exception exception)
        {
            _exception = exception;
        }

        #endregion Metodos Privados
    }
}