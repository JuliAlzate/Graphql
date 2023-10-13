using Graphql.Data;
using Graphql.Models;

namespace Graphql.GraphQL
{
    public class Query
    {
        List<Platform> platformList = new List<Platform>
        {
            new Platform { Id = 1, Name = "Windows", LicenseKey = "WXYZ-1234" },
            new Platform { Id = 2, Name = "macOS", LicenseKey = "ABCD-5678" },
            new Platform { Id = 3, Name = "Linux", LicenseKey = "EFGH-9012" },
            new Platform { Id = 4, Name = "iOS", LicenseKey = "IJKL-3456" },
            new Platform { Id = 5, Name = "Android", LicenseKey = "MNOP-7890" },
            new Platform { Id = 6, Name = "PlayStation", LicenseKey = "QRST-2345" },
            new Platform { Id = 7, Name = "Xbox", LicenseKey = "UVWX-6789" }
        };
        public List<Platform> GetPlatforms([Service] AppDbContext context)
        {

            return platformList;
        }

    }


}

