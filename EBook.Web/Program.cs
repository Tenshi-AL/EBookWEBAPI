using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.EntityFrameworkCore;
using EBook.Persistence;
using MediatR;
using AutoMapper;
using EBook.Infrastructure.Behavior.Commands;
using EBook.Infrastructure;
using Microsoft.Extensions.FileProviders;

var builder = WebApplication.CreateBuilder(args);

//configure sql db
//builder.Services.AddCors();
builder.Services.AddDbContext<EBookContext>(p=>p.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddMediatR(prop => prop.RegisterServicesFromAssembly(typeof(InsertAuthorCommand).Assembly));
builder.Services.AddAutoMapper(typeof(MapperProfile));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
app.UseCors(builder => builder
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader());


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(
        Path.Combine(builder.Environment.ContentRootPath, "wwwroot/Books")),
    RequestPath = "/Books"
}); 

app.UseAuthorization();

app.MapControllers();

app.Run();
