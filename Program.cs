using System.Text;
using ApiBalada;
using ApiBalada.Services;
using JtTcc;
// using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);
var key = Encoding.ASCII.GetBytes(Settings.Secret);
// builder.Services.AddAuthentication(x =>
// {
//     x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
//     x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
// }).AddJwtBearer(x =>
// {
//     x.TokenValidationParameters = new TokenValidationParameters
//     {
//         ValidateIssuerSigningKey = true,
//         IssuerSigningKey = new SymmetricSecurityKey(key),
//         ValidateIssuer = false,
//         ValidateAudience = false
//     };
// });

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins",
        builder => builder.AllowAnyOrigin()
                          .AllowAnyMethod()
                          .AllowAnyHeader());
});

builder.Services.AddDbContext<Context>();
builder.Services.AddControllers();
builder.Services.AddScoped<Context>();
builder.Services.AddTransient<TokenService>();
builder.Services.AddSwaggerGen(c =>
    {
        c.SwaggerDoc("v1", new OpenApiInfo { Title = "Nome da Sua API", Version = "v1" });
    });

var app = builder.Build();
app.UseCors("AllowAllOrigins");
app.MapControllers();
app.UseSwagger();
app.UseSwaggerUI();
// app.UseAuthentication();
// app.UseAuthorization();

app.Run();