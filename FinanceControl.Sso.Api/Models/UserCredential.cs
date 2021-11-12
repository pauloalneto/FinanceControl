using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace FinanceControl.Sso.Api.Models
{
    public class UserCredential
    {
        public string SubjectId { get; internal set; }
        public string UserName { get; internal set; }
        public string Password { get; internal set; }
        public bool Active { get; set; }
        public List<Claim> Claims { get; internal set; }
    }
}
