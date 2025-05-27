using MeuPonto.Domain.Core.Commands;

namespace MeuPonto.Domain.Commands.RegistroPonto
{
    public abstract class RegistroPontoCommand : Command
    {
        public Guid Id { get; protected set; }
        public Guid UsuarioId { get; set; }
        public Guid TipoPontoId { get; set; }
        public DateTime? Saida { get; set; }
        public bool Ajustado { get; set; }
        public string Observacao { get; set; }
        public bool Ativo { get; set; }
    }
}