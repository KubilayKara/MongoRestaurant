using Duende.IdentityServer;
using Duende.IdentityServer.Models;
using System.Collections.Generic;

namespace Mongo.Services.Identity
{
    public static class StaticDictionary
    {
        public const string Admin = "Admin";
        public const string Customer = "Customer";

        public static IEnumerable<IdentityResource> IdentityResources =>
            new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Email(),
                new IdentityResources.Profile()
            };
        public static IEnumerable<ApiScope> ApiScopes =>
            new List<ApiScope>
            {
                new ApiScope("Mango", "Mango Server"),
                new ApiScope("read", "Read data"),
                new ApiScope("write", "write data"),
                new ApiScope("delete", "delete data")
            };
        public static IEnumerable<Client> Clients =>
            new List<Client> { 
                new Client
                {
                    ClientId="client",
                    ClientSecrets={new Secret("secretKey".Sha256())},
                    AllowedGrantTypes= GrantTypes.ClientCredentials,
                    AllowedScopes={"read", "write","profile"}
                },
                 new Client
                {
                    ClientId="mango",
                    ClientSecrets={new Secret("secretKey".Sha256())},
                    AllowedGrantTypes= GrantTypes.Code,
                    RedirectUris={"https://localhost:44359/signin-oidc"},
                    PostLogoutRedirectUris={"https://localhost:44359/signout-callback-oidc"},
                    AllowedScopes={
                         IdentityServerConstants.StandardScopes.OpenId,
                         IdentityServerConstants.StandardScopes.Profile,
                         IdentityServerConstants.StandardScopes.Email,
                         "Mango"
                         }
                }
            };
    }
}

