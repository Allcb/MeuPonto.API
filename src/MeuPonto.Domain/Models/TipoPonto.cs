using MeuPonto.Domain.Core.Models;

namespace MeuPonto.Domain.Models
{
    public class TipoPonto : Entity
    {
        #region Construtores Publicos

        public TipoPonto()
        {
        }

        #endregion Construtores Publicos

        #region Propriedades Publicas

        public string Descricao { get; set; }
        public string Codigo { get; set; }
        public int Ordem { get; set; }

        public virtual ICollection<RegistroPonto> RegistrosPonto { get; set; }

        #endregion Propriedades Publicas
    }
}