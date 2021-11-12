using Common.Domain.Model;
using Common.API.Extensions;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using FinanceControl.Domain.Enum;
using Common.Domain.Helpers;
using Common.Domain.Enums;

namespace FinanceControl.CrossCutting.Auth
{
    public class ProfileCustom
    {
        public static IDictionary<string, object> Define(IEnumerable<Claim> _claims)
        {
            var user = new CurrentUser().Init(Guid.NewGuid().ToString(), _claims.ConvertToDictionary());
            return Define(user);
        }

        public static IDictionary<string, object> Define(CurrentUser user)
        {
            var _claims = user.GetClaims();
            var roles = user.GetRole();

            if (roles.Contains(ERole.Administrator.ToString().ToLower()))
                _claims.AddRange(ClaimsForAdmin());
            if (roles.Contains(ERole.Reader.ToString().ToLower()))
                _claims.AddRange(ClaimsForReader());

            return _claims;
        }

        public static Dictionary<string, object> ClaimsForAdmin()
        {
            var tools = new List<Tool>
            {
                new Tool { Icon = "fa fa-edit", Name = "WeatherForecast", Route = "/weatherForecast", Key = "WeatherForecast" , Type = ETypeTools.Menu, CanReadAll = true },
            };

            var adminTools = System.Text.Json.JsonSerializer.Serialize(tools);
            return new Dictionary<string, object>
            {
                { "tools", adminTools }
            };
        }

        public static Dictionary<string, object> ClaimsForReader()
        {

            return new Dictionary<string, object>();
        }
    }
}
