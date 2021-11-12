using Common.API.Extensions;
using Common.Domain.Base;
using Common.Domain.Helpers;
using Common.Domain.Model;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Common.API.CrossCutting
{
    public class RequestTokenMiddleware
    {
        private readonly RequestDelegate _next;

        public RequestTokenMiddleware(RequestDelegate next)
        {
            this._next = next;
        }

        public async Task Invoke(HttpContext context, CurrentUser currentUser)
        {
            var token = context.Request.Headers["Authorization"];
            if (!token.IsNullOrEmpty())
            {
                var tokenClear = token.ToString().Replace("Bearer", "").Replace(" ","");
                var jwt = new JwtSecurityTokenHandler();
                var canRead = jwt.CanReadToken(tokenClear);
                if (canRead)
                {
                    var claims = GetClaimsFromUserPrincipal(context);
                    this.ConfigClaims(currentUser, tokenClear, claims.ConvertToDictionary());
                }
            }
            else
            {
                var claims = GetClaimsFromUserPrincipal(context);
                ConfigClaims(currentUser, string.Empty, claims.ConvertToDictionary());
            }
            await this._next.Invoke(context);
        }

        protected virtual void ConfigClaims(CurrentUser currentUser, string tokenClear, IDictionary<string, object> claimsDictonary)
        {
            currentUser.Init(tokenClear, claimsDictonary);
        }

        private static IEnumerable<Claim> GetClaimsFromUserPrincipal(HttpContext context)
        {
            var caller = context.User;
            var claims = caller.Claims;
            return claims;
        }
    }

    public static class RequestTokenMiddlewareExtension
    {
        public static IApplicationBuilder AddTokenMiddleware(this IApplicationBuilder app)
        {
            return app.UseMiddleware<RequestTokenMiddleware>();
        }
    }
}
