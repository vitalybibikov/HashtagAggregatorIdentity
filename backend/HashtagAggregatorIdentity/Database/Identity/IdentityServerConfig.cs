using System.Collections.Generic;
using IdentityServer4;
using IdentityServer4.Models;
using Microsoft.Extensions.Configuration;

namespace HashtagAggregator.IdentityServer.Database.Identity
{
    public static class IdentityServerConfig
    {
        private const string StatisticsApiName = "statisticsapi";
        private const string TwitterApiService = "twitterapiservice";
        private const string VkApiService = "vkapiservice";
        private const string ConsumerApiService = "consumerapiservice";

        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            return new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
                new IdentityResources.Email()
            };
        }

        public static IEnumerable<ApiResource> GetApiResources()
        {
            return new List<ApiResource>
            {
                new ApiResource(StatisticsApiName, "Statistics API"),
                new ApiResource(TwitterApiService, "Twitter Service API"),
                new ApiResource(VkApiService, "VK service API"),
                new ApiResource(ConsumerApiService, "Consumer API")
            };
        }

        public static IEnumerable<Client> GetClients(IConfigurationRoot configuration)
        {
            return new List<Client>
            {
                new Client
                {
                    ClientId = "statisticsapiclient",
                    ClientName = "Statistics API Client",
                    AllowedGrantTypes = GrantTypes.Implicit,

                    RedirectUris = {configuration.GetSection("StatisticsApiClient:RedirectURI").Value},
                    PostLogoutRedirectUris = {configuration.GetSection("statisticsApiClient:LogoutURI").Value},
                    AllowedCorsOrigins = {configuration.GetSection("StatisticsApiClient:AllowedCorsOriginsURI").Value},

                    AllowedScopes =
                    {
                        StatisticsApiName,
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        IdentityServerConstants.StandardScopes.Email
                    },
                    AllowAccessTokensViaBrowser = true,
                    AllowRememberConsent = false,
                    RequireConsent = false
                },
                new Client
                {
                    ClientId = "statisticsapi",
                    ClientName = "Statistics API",
                    ClientSecrets = {new Secret("hashtagaggreggatorsapiservice".Sha256())},
                    
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    AllowedScopes = {TwitterApiService, VkApiService}
                }
            };
        }
    }
}