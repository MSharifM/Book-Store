using BookStore.Core.DTOs.Account;
using BookStore.Core.DTOs.UserPanel;
using BookStore.DataLayer.Entities;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace BookStore.Core.Services.Interfaces
{
    public interface IUserService
    {
        #region Account

        Task<IdentityResult> RegisterAsync(RegisterViewModel user);
        Task<SignInResult> SignInAsync(LoginViewModel model);
        Task LogOutAsync();
        bool IsUserSignIn(ClaimsPrincipal user);
        Task<bool> IsExistUserNameAsync(string userName);
        Task<bool> IsExistEmailAsync(string email);

        #endregion

        #region UserPanel

        Task<IdentityResult> ChangePasswordAsync(ChangePasswordViewModel model);
        Task<User?> FindUserByUserNameAsync(string name);

        #endregion
    }
}
