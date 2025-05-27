using MeuPonto.Domain.Core.Models;

namespace MeuPonto.Domain.Models
{
    public class Perfil : Entity
    {
        #region Construtores Publicos

        public Perfil()
        {
        }

        public Perfil(string nome,
                      string descricao,
                      string codigo)
        {
            Nome = nome;
            Descricao = descricao;
            Codigo = codigo;
        }

        #endregion Construtores Publicos

        #region Propriedades Publicas

        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string Codigo { get; set; }

        public virtual ICollection<Usuario> Usuarios { get; set; }

        #endregion Propriedades Publicas
    }
}