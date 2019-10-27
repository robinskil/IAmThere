using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using IAmThereApi.DAO;
using IAmThereApi.Helpers;
using IAmThereApi.Models;
using IAmThereApi.Repository;
using IAmThereApi.RequestModels;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace IAmThereApi.Services
{
    public interface IAuthService
    {
        ClaimsPrincipal LoginUser(LoginModel loginModel);

    }
    public class AuthService
    {
        public IRepository<User> Repository { get; }
        public AuthService(DataContext context)
        {
            Repository = new Repository<User>(context);
        }


        public ClaimsPrincipal LoginUser(LoginModel loginModel)
        {
            User user = Repository.GetEntity(u => u.Email == loginModel.Email);
            if (user == null || !Hasher.VerifyHash(loginModel.Password, user.Password))
            {
                return null;
            }
            return GetClaimsPrincipal(user);
        }

        private ClaimsPrincipal GetClaimsPrincipal(User user)
        {
            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Email,user.Email),
            };
            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            return new ClaimsPrincipal(identity);
        }
    }
}
