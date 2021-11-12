using Common.API.CrossCutting;
using Common.Domain.Model;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace FinanceControl.CrossCutting.Auth
{
    public class RequestTokenMiddlewareCustom : RequestTokenMiddleware
    {
        public RequestTokenMiddlewareCustom(RequestDelegate next) : base(next)
        {

        }


        protected override void ConfigClaims(CurrentUser currentUser, string tokenClear, IDictionary<string, object> claimsDictonary)
        {
            base.ConfigClaims(currentUser, tokenClear, claimsDictonary);
            ProfileCustom.Define(currentUser);
        }


    }

    public static class RequestTokenMiddlewareExtensionCustom
    {
        public static IApplicationBuilder AddTokenMiddlewareCustom(this IApplicationBuilder app)
        {
            return app.UseMiddleware<RequestTokenMiddlewareCustom>();
        }
    }

}
