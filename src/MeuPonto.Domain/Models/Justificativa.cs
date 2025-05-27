using MeuPonto.Domain.Core.Models;

namespace MeuPonto.Domain.Models
{
    public class Justificativa : Entity
    {
        #region Construtores Publicos

        public Justificativa()
        {
        }

        public Justificativa(Guid usuarioId,
                             Guid tipoJustificativaId,
                             Guid statusJustificativaId,
                             string motivo,
                             string respostaGestor,
                             DateTime? dataResposta,
                             TipoJustificativa tipo,
                             StatusJustificativa status)
        {
            UsuarioId = usuarioId;
            TipoJustificativaId = tipoJustificativaId;
            StatusJustificativaId = statusJustificativaId;
            Motivo = motivo;
            RespostaGestor = respostaGestor;
            DataResposta = dataResposta;
        }

        #endregion Construtores Publicos

        #region Propriedades Publicas

        public Guid UsuarioId { get; set; }
        public Guid RegistroPontoId { get; set; }
        public Guid TipoJustificativaId { get; set; }
        public Guid StatusJustificativaId { get; set; }
        public string Motivo { get; set; }
        public string RespostaGestor { get; set; }
        public DateTime? DataResposta { get; set; }

        public virtual Usuario Usuario { get; set; }
        public virtual RegistroPonto RegistroPonto { get; set; }
        public virtual TipoJustificativa TipoJustificativa { get; set; }
        public virtual StatusJustificativa StatusJustificativa { get; set; }

        #endregion Propriedades Publicas
    }
}