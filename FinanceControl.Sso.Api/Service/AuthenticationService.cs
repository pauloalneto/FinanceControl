using Common.Domain.Helpers;
using FinanceControl.CrossCutting.Auth;
using FinanceControl.Domain.Entity;
using FinanceControl.Domain.Interface.Repository;
using FinanceControl.Sso.Api.Interfaces;
using FinanceControl.Sso.Api.Models;
using IdentityModel;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace FinanceControl.Sso.Api.Service
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IUserRepository userRepository;

        public AuthenticationService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public async Task<UserCredential> Auth(string userName, string password)
        {
            return await Task.Run(() =>
            {
                var userCredential = default(UserCredential);

                var cripto = new CriptoHelper();

                var passwordDecrypt = cripto.TripleDESCripto(password, SecurityConfig.GetSecret());

                var user = this.userRepository.GetAll().Include(_ => _.CollectionUserRole)
                                                       .ThenInclude(_ => _.Role)
                                                       .Where(_ => _.Login == userName && _.Password == passwordDecrypt)
                                                       .FirstOrDefault();

                if (user.IsNull())
                    return userCredential;

                var result = new UserCredential
                {
                    UserName = user.Login,
                    SubjectId = user.UserId.ToString(),
                    Claims = new List<Claim>
                    {
                        new Claim("name", user.Name),
                        new Claim("email", user.Email),
                        new Claim("role", GetRoles(user.CollectionUserRole)),

                    }
                };

                return result;

            });
        }

        private static string GetRoles(IEnumerable<UserRole> collection)
        {
            var roles = new List<string>();
            if (collection.IsNotNull())
            {
                foreach (var item in collection)
                {
                    roles.Add(item.Role?.Name);
                }
            }
            var jsonRoles = System.Text.Json.JsonSerializer.Serialize(roles);

            return jsonRoles;
        }

    }
}
