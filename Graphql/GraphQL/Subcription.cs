using Graphql.Models;

namespace Graphql.GraphQL
{
  
    public class Subcription
    {
        [Subscribe]
        [Topic]
        public Platform OnPlatformAdded([EventMessage] Platform platform) => platform;
    }
}
