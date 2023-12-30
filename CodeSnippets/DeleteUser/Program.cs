using Azure.Identity;

using DeleteUser.Configuration;

using Microsoft.Extensions.Configuration;
using Microsoft.Graph;

using System.Runtime;

namespace DeleteB2CUser
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var builder = new ConfigurationBuilder()
                      .SetBasePath(Directory.GetCurrentDirectory())
                      .AddJsonFile("appsettings.json", optional: false);

            IConfiguration config = builder.Build();

            var entraIdSettings = config.GetSection("EntraIdSettings") as EntraIdSettings;

            if(entraIdSettings == null )
            {
                Console.WriteLine("No valid entra id settings!");
                return;
            }

            var scopes = new[] { "https://graph.microsoft.com/.default" };

            var options = new TokenCredentialOptions
            {
                AuthorityHost = AzureAuthorityHosts.AzurePublicCloud
            };

            var clientSecretCredential = new ClientSecretCredential(entraIdSettings.TennantId, entraIdSettings.ClientId, entraIdSettings.ClientSecret, options);
            var graphClient = new GraphServiceClient(clientSecretCredential, scopes);

            var users = await graphClient.Users.GetAsync((requestConfiguration) =>
            {
                requestConfiguration.QueryParameters.Select = new string[] { "id", "identities" };
            });

            if (users != null && users.Value != null)
            {
                var userFound = false;
                while (!userFound)
                {
                    Console.WriteLine("Enter email:");
                    var email = Console.ReadLine();

                    var user = users.Value.FirstOrDefault(x => x.Identities.Any(x => x.IssuerAssignedId == email));

                    if (user == null)
                    {
                        Console.WriteLine($"User with email {email} not found");
                    }
                    else
                    {
                        userFound = true;

                        try
                        {
                            await graphClient.Users[user.Id].DeleteAsync();
                            Console.WriteLine($"User with email {email} deleted successfully");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Failed to delete user. " + ex.Message);
                        }

                        return;
                    }
                }
            }
        }
    }
}