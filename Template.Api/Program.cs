using Microsoft.EntityFrameworkCore;
using Template.Data;
using Template.Data.Models;
using Template.Data.UnitsOfWork;
using Template.Services;
using Template.Services.Interfaces;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<TemplateDbContext>(options => options.UseInMemoryDatabase(databaseName: "TemplateDb"));

BaseData.Initialize(builder.Services.BuildServiceProvider());

builder.Services.AddScoped<ITemplateUnitOfWork, TemplateUnitOfWork>();

builder.Services.AddTransient<ITeamsService, TeamsService>();
builder.Services.AddTransient<IProjectsService, ProjectsService>();
builder.Services.AddTransient<IDevelopersService, DevelopersService>();
builder.Services.AddControllers()
                .AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    // add other options if needed
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add CORS policy
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAnyOrigin",
        builder => builder
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors("AllowAnyOrigin");

app.MapControllers();

app.Run();
