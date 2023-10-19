
using Graphql.Data;
using Graphql.GraphQL.Commands;
using Graphql.GraphQL.Platforms;
using Graphql.Models;
using HotChocolate.Subscriptions;

namespace Graphql.GraphQL
{
    public class Mutation
    {
        [UseDbContext(typeof(AppDbContext))]
        public async Task<AddPlatformPayload> AddPlatformAsync(AddPlayFormImput input, [ScopedService] AppDbContext context, [Service] ITopicEventSender eventSender, CancellationToken cancellationToken)
        {
            var platform = new Platform
            {
                Name = input.Name
            };

            context.Platforms.Add(platform);
            await context.SaveChangesAsync();

            await eventSender.SendAsync(nameof(Subcription.OnPlatformAdded), platform,cancellationToken);

            return new AddPlatformPayload(platform);
        }

        [UseDbContext(typeof(AppDbContext))]
        public async Task<AddCommandPayload> AddCommandAsync(AddCommandInput  input, [ScopedService] AppDbContext context)
        {
            var command = new Command
            {
               HowTo= input.HowTo,
               CommandLine = input.CommandLine,
               PlatformId = input.PlatformId
               
            };

            context.Command.Add(command);
            await context.SaveChangesAsync();

            return new AddCommandPayload(command);
        }
    }
}
