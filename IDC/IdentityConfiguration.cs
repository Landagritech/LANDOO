
using System.Collections.Generic;
using System.Security.Claims;
using IdentityModel;
using IdentityServer4.Models;
using IdentityServer4.Test;

namespace IDC
{
    public class IdentityConfiguration
    {
        public static List<TestUser> TestUsers =>
        new List<TestUser>
         {
            new TestUser
            {
                SubjectId = "00001",
                Username = "admin",
                Password = "admin",
                Claims =
                {
                    new Claim(JwtClaimTypes.Name, "Houssemeddine HENCHIR"),
                    new Claim(JwtClaimTypes.GivenName, "Houssem"),
                    new Claim(JwtClaimTypes.FamilyName, "HENCHIR"),
                }
            }
         };

        public static IEnumerable<IdentityResource> IdentityResources =>
        new IdentityResource[]
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
            };


        public static IEnumerable<ApiScope> ApiScopes =>
            new ApiScope[]
            {
                new ApiScope("LANDO.SuperAdmin"),
                new ApiScope("LANDO.Customer"),
                new ApiScope("LANDO.Partner"),
                new ApiScope("LANDO.Internal"),
                new ApiScope("LANDO.SuperInternal"),
            };

        public static IEnumerable<ApiResource> ApiResources =>
            new ApiResource[]
            {
                new ApiResource(Constants.APIName)
                {
                    Scopes = new List<string>{ Constants.Role1, Constants.Role2,Constants.Role3,Constants.Role4,Constants.Role5},
                    ApiSecrets = new List<Secret>{ new Secret(Constants.SecretKey.Sha256()) }
                }
            };

        public static IEnumerable<Client> Clients =>
            new Client[]
            {
                new Client
                {
                    ClientId = "cwm.client",
                    ClientName = "Client Credentials Client",
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    ClientSecrets = { new Secret(Constants.SecretKey.Sha256()) },
                    AllowedScopes = { Constants.Role1 }
                },
            };  
    }


    
}
