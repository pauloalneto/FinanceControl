using FinanceControl.Domain.Entity;
using FinanceControl.Sso.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinanceControl.Sso.Api.Interfaces
{
    public interface IAuthenticationService
    {
        Task<UserCredential> Auth(string userName, string password);
    }
}
