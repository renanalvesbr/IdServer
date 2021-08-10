using Skoruba.IdentityServer4.Shared.Configuration.Configuration.Identity;
using Senff.IdServer.STS.Identity.Configuration.Interfaces;

namespace Senff.IdServer.STS.Identity.Configuration
{
    public class RootConfiguration : IRootConfiguration
    {      
        public AdminConfiguration AdminConfiguration { get; } = new AdminConfiguration();
        public RegisterConfiguration RegisterConfiguration { get; } = new RegisterConfiguration();
    }
}







