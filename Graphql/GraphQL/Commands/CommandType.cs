using Graphql.Data;
using Graphql.Models;
using Microsoft.EntityFrameworkCore;

namespace Graphql.GraphQL.Commands
{
    public class CommandType :ObjectType<Command>
    {
        protected override void Configure(IObjectTypeDescriptor<Command> descriptor)
        {
            descriptor.Description("Representa comandos ejecutables");
            descriptor
                .Field(c=> c.Platform)
                .ResolveWith<Resolvers>(c=>c.GetPlatform(default!,default!))
                .UseDbContext<AppDbContext>();
                
        }

       private class Resolvers
        {

            public Platform GetPlatform(Command command,[ScopedService] AppDbContext context) 
            { 
            return  context.Platforms.FirstOrDefault(p=>p.Id== command.PlatformId);
            
            }
        }


    }

   
}
