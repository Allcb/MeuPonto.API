using MeuPonto.Domain.Core.Models;

namespace MeuPonto.Domain.Models
{
    public class Cargo : Entity
    {
        #region Construtores Publicos

        public Cargo()
        {
            Usuarios = new List<Usuario>();
        }

        public Cargo(string nome,
                     string codigo,
                     string descricao)
        {
            Nome = nome;
            Codigo = codigo;
            Descricao = descricao;
        }

        #endregion Construtores Publicos

        #region Propriedades Publicas

        public string Nome { get; set; }
        public string Codigo { get; set; }
        public string Descricao { get; set; }

        public virtual ICollection<Usuario> Usuarios { get; set; }

        #endregion Propriedades Publicas
    }
}