using MeuPonto.Domain.Core.Models;

namespace MeuPonto.Domain.Models
{
    public class RegistroPonto : Entity
    {
        #region Construtores Publicos

        public RegistroPonto()
        {
            Justificativas = new List<Justificativa>();
        }

        public RegistroPonto(Guid usuarioId,
                             Guid tipoPontoId,
                             DateTime? saida,
                             string observacao,
                             bool ajustado = default)
        {
            UsuarioId = usuarioId;
            TipoPontoId = tipoPontoId;
            Saida = saida;
            Observacao = observacao;
            Ajustado = ajustado;
        }

        #endregion Construtores Publicos

        #region Propriedades Publicas

        public Guid UsuarioId { get; set; }
        public Guid TipoPontoId { get; set; }
        public DateTime? Saida { get; set; }
        public bool Ajustado { get; set; }
        public string Observacao { get; set; }

        public virtual TipoPonto TipoPonto { get; set; }
        public virtual Usuario Usuario { get; set; }
        public virtual ICollection<Justificativa> Justificativas { get; set; }

        #endregion Propriedades Publicas
    }
}