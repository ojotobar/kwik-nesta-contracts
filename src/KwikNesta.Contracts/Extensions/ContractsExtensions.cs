using KwikNesta.Contracts.Enums;

namespace KwikNesta.Contracts.Extensions
{
    public static class ContractsExtensions
    {
        public static EmailType ToEmailType(this OtpType type)
        {
            return type switch
            {
                OtpType.AccountVerification => EmailType.AccountActivation,
                OtpType.ResetPassword => EmailType.PasswordReset,
                OtpType.AccountReactivation => EmailType.AccountReactivation,
                _ => throw new NotImplementedException(),
            };
        }
    }
}
