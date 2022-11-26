using FluentValidation;
using FreshShop.Model.ComplexTypes.Yonetim.User;
using System.Linq;

namespace FreshShop.Business.ValidationRules.FluentValidation
{
    public class NewUserVmValidator:AbstractValidator<NewUserVm>
    {
        public NewUserVmValidator()
        {
            RuleFor(x => x.FullName)
                .NotEmpty()
                .WithMessage("Ad Soyad Boş Bırakılamaz")
                .MinimumLength(2)
                .WithMessage("Ad Soyad en az 2 karakter olmalıdır");

            RuleFor(x => x.Email)
                .NotEmpty()
                .WithMessage("Email Boş Bırakılamaz")
                .EmailAddress()
                .WithMessage("Email geçelerli formatta değil");

            RuleFor(x => x.Password)
                .NotEmpty()
                .WithMessage("Şifre boş bırakılamaz")
                .MinimumLength(5)
                .WithMessage("Şifre en az 5 karakter olmalşıdır")
                .Must(IsPasswordValid)
                .WithMessage("Şifrede en az 1 rakam en az 1 küçük harf olmalıdır");

            RuleFor(x => x.RePassword)
               .NotEmpty()
               .WithMessage("Şifre boş bırakılamaz")
               .MinimumLength(5)
               .WithMessage("Şifre en az 5 karakter olmalşıdır")
               .Equal(x => x.Password)
               .WithMessage("Şifre ile tekrarı aynı olmalıdır");
        }

        private bool IsPasswordValid(string password)
        {
            password = password != null ? password : "";

            string lower = "abcdefghijklmnoprstuvyz";
            string digits = "0123456789";

            bool isValidForLower = false;
            bool isValidForDigit = false;

            for (int i = 0; i < password.Length; i++)
            {
                if (lower.Contains(password[i]))
                {
                    isValidForLower = true;
                }

                if (digits.Contains(password[i]))
                {
                    isValidForDigit = true;
                }

            }

            if (isValidForLower && isValidForDigit)
                return true;

            return false;
        }
    }
}
