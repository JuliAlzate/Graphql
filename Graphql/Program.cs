using Graphql.Data;
using Graphql.GraphQL;
using GraphQL.Server.Ui.Voyager;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;

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
    .AddProjections(); 

builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

    app.MapGraphQL();
    app.MapGraphQLVoyager("ui/voyager");

    //https://localhost:7207/ui/voyager




}


app.UseRouting();



app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
