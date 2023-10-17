using Graphql.Data;
using Graphql.Models;

namespace Graphql.GraphQL
{
    public class Query
    {
        [UseDbContext(typeof(AppDbContext))]
        [UseProjection]
        public IQueryable<Platform> GetPlatforms([ScopedService] AppDbContext context)
        {

            return context.Platforms;
                
        }



        [UseDbContext(typeof(AppDbContext))]
        [UseProjection]
        public IQueryable<Command> GetCommands([ScopedService] AppDbContext context)
        {

            return context.Command;
        }

    }


}

