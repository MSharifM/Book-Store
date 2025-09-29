using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Core.DTOs.Account
{
    public class LoginViewModel
    {
        [Display(Name = "نام کاربری")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید.")]
        [MaxLength(200, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد.")]
        public required string UserName { get; set; }

        [Display(Name = "کلمه عبور")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید.")]
        [MaxLength(200, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد.")]
        public required string Password { get; set; }

        [Display(Name = "مرا به خاطر بسپار")]
        public bool RememberMe { get; set; }
    }

    public class RegisterViewModel
    {
        [Display(Name = "نام کاربری")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید.")]
        [MaxLength(200, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد.")]
        [Remote("IsUserNameInUse", "Account", HttpMethod = "POST",
            AdditionalFields = "__RequestVerificationToken")]
        public required string UserName { get; set; }

        [Display(Name = "نام و نام خانوادگی")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید.")]
        [MaxLength(200, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد.")]
        public required string FullName { get; set; }

        [Display(Name = "ایمیل")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید.")]
        [MaxLength(200, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد.")]
        [EmailAddress(ErrorMessage = "ایمیل نامعتبر")]
        [Remote("IsEmailInUse", "Account", HttpMethod = "POST",
            AdditionalFields = "__RequestVerificationToken")]
        public required string Email { get; set; }

        [Required(ErrorMessage = "لطفا {0} را وارد کنید.")]
        [Display(Name = "شماره موبایل")]
        [Phone(ErrorMessage ="شماره موبایل معتبر نیست")]
        public required string Phone { get; set; }

        [Display(Name = "شهر")]
        [MaxLength(70, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد.")]
        public string? City { get; set; }

        [Display(Name = "کلمه عبور")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید.")]
        [MaxLength(200, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد.")]
        [DataType(DataType.Password)]
        public required string Password { get; set; }

        [Display(Name = "تکرار رمزعبور")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید.")]
        [Compare("Password", ErrorMessage = "کلمه عبور  با تکرار آن برابر نیست")]
        [DataType(DataType.Password)]
        public required string ConfirmPassword { get; set; }
    }
}
