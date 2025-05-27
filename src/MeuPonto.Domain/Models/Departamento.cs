using MeuPonto.Domain.Core.Models;

namespace MeuPonto.Domain.Models
{
    public class Departamento : Entity
    {
        #region Construtores Publicos

        public Departamento()
        {
            Usuarios = new List<Usuario>();
        }

        public Departamento(string nome,
                            string codigo,
                            string descricao,
                            Guid? responsavelId)
        {
            Nome = nome;
            Codigo = codigo;
            Descricao = descricao;
            ResponsavelId = responsavelId;
        }

        #endregion Construtores Publicos

        #region Propriedades Publicas

        public string Nome { get; set; }
        public string Codigo { get; set; }
        public string Descricao { get; set; }
        public Guid? ResponsavelId { get; set; }

        public virtual Usuario Responsavel { get; set; }
        public virtual ICollection<Usuario> Usuarios { get; set; }

        #endregion Propriedades Publicas
    }
}