using Common.Domain.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace Common.Domain.Model
{

    public class CurrentUser
    {


        private string _token;
        private IDictionary<string, object> _claims;

        public CurrentUser()
        {
            this._claims = new Dictionary<string, object>();
        }

        public CurrentUser Init(string token, IDictionary<string, object> claims)
        {
            this._token = token;
            this._claims = claims;
            return this;
        }

        public string GetToken()
        {
            return this._token;
        }

        public IDictionary<string, object> GetClaims()
        {
            return this._claims;
        }

        public string GetRole()
        {
            var typeRole = this._claims.Where(_ => _.Key == "role" || _.Key == ClaimTypes.Role);
            if (typeRole.IsAny())
                return typeRole.SingleOrDefault().Value.ToString();
            return string.Empty;
        }

        public bool IsAdmin()
        {
            if (this._claims.IsNotNull())
            {
                return this._claims
                    .Where(_ => _.Key.ToLower() == "typerole")
                    .Where(_ => _.Value.ToString() == "admin").IsAny();
            }
            return false;
        }

        public TS GetClaimByName<TS>(string name)
        {
            var claim_ = this._claims
                .Where(_ => _.Key.ToLower() == name.ToLower());

            if (claim_.IsNotAny())
                return default(TS);

            var claim = claim_.SingleOrDefault().Value;
            return (TS)Convert.ChangeType(claim, typeof(TS));
        }

    }
}
