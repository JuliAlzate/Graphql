using Graphql.Data;
using Graphql.Models;

namespace Graphql.GraphQL.Platforms
{
    public class PlatformType : ObjectType<Platform>
    {

        protected override void Configure(IObjectTypeDescriptor<Platform> descriptor)
        {
            descriptor
              .Field(c => c.LicenseKey).Ignore();


            descriptor
              .Field(c => c.Commands)
              .ResolveWith<Resolvers>(c => c.GetCommands(default!, default!))
              .UseDbContext<AppDbContext>();
              
            
        }
        private class Resolvers
        {

           
                public IQueryable<Command> GetCommands(Platform platform, [ScopedService] AppDbContext context)
            {
                return context.Command.Where(x => x.PlatformId == platform.Id);
            }

            
        }
    }
}
