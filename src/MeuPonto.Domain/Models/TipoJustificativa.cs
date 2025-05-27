using MeuPonto.Domain.Core.Models;

namespace MeuPonto.Domain.Models
{
    public class TipoJustificativa : Entity
    {
        #region Construtores Publicos

        public TipoJustificativa()
        {
        }

        public TipoJustificativa(string descricao,
                                 string codigo)
        {
            Descricao = descricao;
            Codigo = codigo;
        }

        #endregion Construtores Publicos

        #region Propriedades Publicas

        public string Descricao { get; set; }
        public string Codigo { get; set; }

        public virtual ICollection<Justificativa> Justificativas { get; set; }

        #endregion Propriedades Publicas
    }
}