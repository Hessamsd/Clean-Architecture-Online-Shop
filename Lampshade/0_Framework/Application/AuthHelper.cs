﻿using _0_Framework.Infrastructure;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.Security.Claims;
using System.Text.Json.Serialization;

namespace _0_Framework.Application
{
    public class AuthHelper : IAuthHelper
    {

        private readonly IHttpContextAccessor _contextAccessor;

        public AuthHelper(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
        }

        public string CurrenrAccountRole()
        {
            if (IsAuthenticated())
                return _contextAccessor.HttpContext.User.Claims
                    .FirstOrDefault(x => x.Type == ClaimTypes.Role).Value;

            return null;
        }

        public AuthViewModel CurrentAcountInfo()
        {
            var result = new AuthViewModel();

            if (!IsAuthenticated())
                return result;


            var claims = _contextAccessor.HttpContext.User.Claims.ToList();

            result.Id = int.Parse(claims.FirstOrDefault(x => x.Type == "AccountId").Value);
            result.UserName = claims.FirstOrDefault(x => x.Type == "Username").Value;
            result.RoleId = int.Parse(claims.FirstOrDefault(x => x.Type == ClaimTypes.Role).Value);
            result.FullName = claims.FirstOrDefault(x => x.Type == ClaimTypes.Name).Value;
            result.Role = Roles.GetRoleBy(result.RoleId);

            return result;


        }

        public List<int> GetPermissions()
        {
            if(!IsAuthenticated())
                return new List<int>();

            var permissions = _contextAccessor.HttpContext.User.Claims
                .FirstOrDefault(x => x.Type == "permissions")?.Value;

            return JsonConvert.DeserializeObject<List<int>>(permissions);
        }

        public bool IsAuthenticated()
        {

            return _contextAccessor.HttpContext.User.Identity.IsAuthenticated;

            //var Claim = _contextAccessor.HttpContext.User.Claims.ToList();
            ////if(Claim.Count > 0)
            ////    return true;
            ////return false;
            //return Claim.Count > 0;
        }

        public void Signin(AuthViewModel account)
        {

            var permissions = JsonConvert.SerializeObject(account.Permissions);

            var claims = new List<Claim>
            {
                new Claim("AccountId",account.Id.ToString()),
                new Claim(ClaimTypes.Name,account.FullName),
                new Claim(ClaimTypes.Role,account.RoleId.ToString()),
                new Claim("Username",account.UserName),//  Or use ClaimTypes.NameIdentifier
                new Claim("permissions",permissions)
            };

            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            var authProperties = new AuthenticationProperties
            {
                ExpiresUtc = DateTimeOffset.UtcNow.AddDays(1)
            };


            _contextAccessor.HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity), authProperties);

        }

        public void SignOut()
        {
            _contextAccessor.HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        }
    }
}
