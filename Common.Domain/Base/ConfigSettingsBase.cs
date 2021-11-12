using System.Collections.Generic;

namespace Common.Domain.Base
{
    public class ConfigSettingsBase
    {
        public string AuthorityEndPoint { get; set; }

        public IEnumerable<string> ClientAuthorityEndPoint { get; set; }

        public IEnumerable<string> RedirectUris { get; set; }

        public IEnumerable<string> PostLogoutRedirectUris { get; set; }

    }
}
