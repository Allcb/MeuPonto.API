using AutoMapper;

namespace MeuPonto.Application.AutoMapper
{
    public abstract class ProfileBase : Profile
    {
        #region Metodos Protegidos

        protected T ObterItemDoContexto<T>(ResolutionContext contexto, string chave)
        {
            if (contexto.Items is null || !contexto.Items.Any() || !contexto.Items.ContainsKey(key: chave))
                return default(T);

            return (T)contexto.Items[chave];
        }

        #endregion Metodos Protegidos
    }
}