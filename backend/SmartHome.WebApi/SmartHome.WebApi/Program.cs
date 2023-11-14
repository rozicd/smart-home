using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using SmartHome.Application.Services;
using SmartHome.Data;
using SmartHome.Data.Repositories;
using SmartHome.Domain.Repositories;
using SmartHome.Domain.Services;
using SmartHome.WebApi.Middlewares;
using System.Text;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<ICountryRepository, CountryRepository>();
builder.Services.AddScoped<ICityRepository, CityRepository>();
builder.Services.AddScoped<IPropertyRepository, PropertyRepository>();
builder.Services.AddScoped<ICountryService, CountryService>();
builder.Services.AddScoped<ICityService, CityService>();
builder.Services.AddScoped<IPropertyService, PropertyService>();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("smarthomesmarthomesmarthome"))
        };


        options.Events = new JwtBearerEvents
        {
            OnMessageReceived = context =>
            {
                context.Token = context.Request.Cookies["jwtToken"];
                return Task.CompletedTask;
            }
        };
    });

builder.Services.AddAuthorization(o =>
{
    o.AddPolicy("AuthorizedOnly", p => p.RequireRole("Admin", "Worker"));
    o.AddPolicy("AdminOnly", p => p.RequireRole("Admin"));
});


builder.Services.AddDbContext<DatabaseContext>(options =>
{
    options.UseNpgsql("Server=localhost;Port=5432;Database=nvt;User Id=postgres;Password=admin;");
}, ServiceLifetime.Transient);
AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();

app.UseMiddleware<ExceptionHandlingMiddleware>();

app.UseAuthentication();

app.UseAuthorization();

app.UseMiddleware<ClaimsMiddleware>();

app.MapControllers();

app.Run();
