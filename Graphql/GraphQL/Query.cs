using Graphql.Data;
using Graphql.Models;

namespace Graphql.GraphQL
{
    public class Query
    {
        [UseDbContext(typeof(AppDbContext))]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Platform> GetPlatforms([ScopedService] AppDbContext context)
        {

            return context.Platforms;
                
        }



        [UseDbContext(typeof(AppDbContext))]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Command> GetCommands([ScopedService] AppDbContext context)
        {

            return context.Command;
        }

    }


}

