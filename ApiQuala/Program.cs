using ApiQuala.Core.Interfaces;
using ApiQuala.Core.Services;
using ApiQuala.Infraestructure;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Text;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowLocalhost", policy =>
    {
        policy.WithOrigins("http://localhost:4200") 
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});


// Registra IConfiguration para acceder a la configuración
IConfiguration configuration = builder.Configuration;

// Registra la conexión IDbConnection utilizando la cadena de conexión
builder.Services.AddScoped<IDbConnection>(sp =>
    new SqlConnection(configuration.GetConnectionString("DefaultConnection"))
);

builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<ISucursalesService, SucursalService>();
builder.Services.AddScoped<IMonedaService, MonedaService>();
builder.Services.AddScoped<IDataBaseService, DatabaseService>();

// Configuración de la cadena de conexión
builder.Services.AddSingleton<IConfiguration>(builder.Configuration);


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = new Microsoft.IdentityModel.Tokens.SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
        };
    });

builder.Services.AddAuthorization();



var app = builder.Build();

app.UseCors("AllowLocalhost"); // Habilita CORS

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Activar la autenticación y autorización
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
