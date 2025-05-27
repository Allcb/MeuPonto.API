namespace MeuPonto.Domain.Commands.RegistroPonto
{
    public class RegistroPontoCriarCommand : RegistroPontoCommand
    {
        #region Construtores Publicos

        public RegistroPontoCriarCommand()
        {
        }

        #endregion Construtores Publicos

        public override bool EValido()
        {
            // TODO adicionar validações de campos
            //ValidationResult = new RegistroPontoCriarCommandValidation().Validate(this);
            //return ValidationResult.IsValid;
            return true;
        }
    }
}