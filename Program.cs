using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using Newtonsoft.Json.Serialization;
using OpticartWebAPI.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//hello add the github
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<OptiCartDbContext>(c=>c.UseSqlServer(builder.Configuration.GetConnectionString("DBConnection")));

builder.Services.AddCors(c =>
{
    c.AddPolicy("AllowedOrigin",options => options.AllowAnyOrigin().AllowAnyHeader().
    AllowAnyMethod());
});

builder.Services.AddControllersWithViews().AddNewtonsoftJson(options =>
options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore)
    .AddNewtonsoftJson(option => option.SerializerSettings.ContractResolver
    = new DefaultContractResolver());

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseCors(option=>option.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(
        Path.Combine(Directory.GetCurrentDirectory(),"Images")),
    RequestPath = "/Images"
});

app.MapControllers();

app.Run();
