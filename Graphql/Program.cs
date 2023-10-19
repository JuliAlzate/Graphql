using Graphql.Data;
using Graphql.GraphQL;
using Graphql.GraphQL.Platforms;
using GraphQL.Server.Ui.Voyager;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using System.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();


builder.Services.AddPooledDbContextFactory <AppDbContext>(opt => opt.UseSqlServer
(builder.Configuration.GetConnectionString
("DefaultConnection")));

builder.Services.
    AddGraphQLServer()
    .AddQueryType<Query>()
    .AddMutationType<Mutation>()
    .AddSubscriptionType<Subcription>()
    .AddType<CommandType>()
    .AddType<PlatformType>()
    .AddFiltering()
    .AddSorting();


builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

    app.MapGraphQL();
    //https://localhost:7207/graphql/
    app.MapGraphQLVoyager("ui/voyager");
    //https://localhost:7207/ui/voyager
}

app.UseRouting();
app.UseWebSockets();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
