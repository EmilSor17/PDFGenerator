using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using PDFGenerator.Core.Interfaces;
using PDFGenerator.Core.Services;
using PDFGenerator.Infraestructure.Data;
using PDFGenerator.Infraestructure.Interfaces;
using PDFGenerator.Infraestructure.Options;
using PDFGenerator.Infraestructure.Persistence;
using PDFGenerator.Infraestructure.Repositories;
using PDFGenerator.Infraestructure.Services;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var configuration = builder.Configuration;

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//PasswordHash
builder.Services.Configure<PasswordOption>(configuration.GetSection("PasswordOptions"));

//db connection
builder.Services.AddDbContext<PDFGeneratorContext>(options =>
  options.UseSqlServer(configuration.GetConnectionString("PDFGeneratorConnection")));

//AuthorizationJWT
builder.Services.AddAuthentication(options =>
{
  options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
  options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
  options.TokenValidationParameters = new TokenValidationParameters
  {
    ValidateIssuer = true,
    ValidateAudience = true,
    ValidateLifetime = true,
    ValidateIssuerSigningKey = true,
    ValidIssuer = configuration["Authentication:Issuer"],
    ValidAudience = configuration["Authentication:Audience"],
    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Authentication:SecretKey"]))
  };
});

//repositories
builder.Services.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<ITemplateRepository, TemplateRepository>();
builder.Services.AddScoped<ISecurityRepository, SecurityRepository>();
builder.Services.AddScoped<IBoardRepository, BoardRepository>();

//Services
builder.Services.AddTransient<ISecurityService, SecurityService>();
builder.Services.AddSingleton<IPasswordService, PasswordService>();

//adding cors policy
builder.Services.AddCors(options =>
{
  options.AddPolicy("AllowAll",
      builder =>
      {
        builder.AllowAnyOrigin()
                     .AllowAnyMethod()
                     .AllowAnyHeader();
      });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
  app.UseSwagger();
  app.UseSwaggerUI();
}
app.UseCors("AllowAll");
app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
