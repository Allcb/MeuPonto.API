using MeuPonto.Domain.Core.Models;

namespace MeuPonto.Domain.Models
{
    public class Usuario : Entity
    {
        #region Construtores Publicos

        public Usuario()
        {
            RegistrosPonto = new List<RegistroPonto>();
        }

        public Usuario(string nome,
                       string email,
                       Guid departamentoId,
                       Guid cargoId,
                       Guid perfilId)
        {
            Nome = nome;
            Email = email;
            DepartamentoId = departamentoId;
            CargoId = cargoId;
            PerfilId = perfilId;
            RegistrosPonto = new List<RegistroPonto>();
        }

        #endregion Construtores Publicos

        #region Propriedades Publicas

        public string Nome { get; set; }
        public string Email { get; set; }
        public Guid DepartamentoId { get; set; }
        public Guid CargoId { get; set; }
        public Guid PerfilId { get; set; }

        public virtual Cargo Cargo { get; set; }
        public virtual Departamento Departamento { get; set; }
        public virtual Perfil Perfil { get; set; }
        public virtual ICollection<RegistroPonto> RegistrosPonto { get; set; }
        public virtual ICollection<Justificativa> Justificativas { get; set; }

        #endregion Propriedades Publicas
    }
}