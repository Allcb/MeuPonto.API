using MeuPonto.Domain.Core.Models;

namespace MeuPonto.Domain.Models
{
    public class StatusJustificativa : Entity
    {
        #region Construtores Publicos

        public StatusJustificativa()
        {
        }

        public StatusJustificativa(string descricao,
                                   string codigo,
                                   int ordem)
        {
            Descricao = descricao;
            Codigo = codigo;
            Ordem = ordem;
        }

        #endregion Construtores Publicos

        #region Propriedades Publicas

        public string Descricao { get; set; }
        public string Codigo { get; set; }
        public int Ordem { get; set; }

        public virtual ICollection<Usuario> Usuarios { get; set; }

        #endregion Propriedades Publicas
    }
}