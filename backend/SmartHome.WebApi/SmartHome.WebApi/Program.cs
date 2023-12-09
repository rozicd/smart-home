using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting.Internal;
using Microsoft.IdentityModel.Tokens;
using MQTTnet.Client;
using SmartHome.Application.Services;
using SmartHome.Application.Services.SmartDevices;
using SmartHome.Data;
using SmartHome.Data.Repositories;
using SmartHome.Data.Repositories.SmartDevices;
using SmartHome.Domain.Repositories;
using SmartHome.Domain.Repositories.SmartDevices;
using SmartHome.Domain.Services;
using SmartHome.Domain.Services.SmartDevices;
using SmartHome.WebApi.Middlewares;
using System.Text;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IEmailService, EmailService>();
builder.Services.AddScoped<IActivationTokenRepository, ActivationTokenRepository>();
builder.Services.AddScoped<IActivationTokenService, ActivationTokenService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<ICountryRepository, CountryRepository>();
builder.Services.AddScoped<ICityRepository, CityRepository>();
builder.Services.AddScoped<IPropertyRepository, PropertyRepository>();
builder.Services.AddScoped<IFileService, FileService>();
builder.Services.AddScoped<ICityService, CityService>();
builder.Services.AddScoped<IPropertyService, PropertyService>();
builder.Services.AddScoped<ISmartDeviceRepository, SmartDeviceRepository>();
builder.Services.AddScoped<ISmartDeviceService, SmartDeviceService>();
builder.Services.AddScoped<IWashingMachineRepository, WashingMachineRepository>();
builder.Services.AddScoped<IWashingMachineService, WashingMachineService>();

builder.Services.AddScoped<IEnvironmentalConditionsSensorRepository, EnvironmentalConditionsSensorRepository>();
builder.Services.AddScoped<IEnvironmentalConditionsSensorService, EnvironmentalConditionsSensorService>();
builder.Services.AddScoped<IAirConditionerService, AirConditionerService>();
builder.Services.AddScoped<IAirConditionerRepository, AirConditionerRepository>();
builder.Services.AddScoped<ILampRepository, LampRepository>();
builder.Services.AddScoped<ILampService, LampService>();
builder.Services.AddScoped<IMqttClientService, MqttClientService>();

builder.Services.AddScoped<ICarGateRepository, CarGateRepository>();
builder.Services.AddScoped<ICarGateService, CarGateService>();
builder.Services.AddScoped<ISprinklerRepository, SprinklerRepository>();
builder.Services.AddScoped<ISprinklerService, SprinklerService>();

builder.Services.AddScoped<ISolarPanelSystemRepository, SolarPanelSystemRepository>();
builder.Services.AddScoped<ISolarPanelSystemService, SolarPanelSystemService>();

builder.Services.AddScoped<IHomeBatteryRepository, HomeBatteryRepository>();
builder.Services.AddScoped<IHomeBatteryService, HomeBatteryService>();

builder.Services.AddScoped<ICarChargerRepository, CarChargerRepository>();
builder.Services.AddScoped<ICarChargerService, CarChargerService>();

builder.Services.AddSingleton<IInfluxClientService>(provider =>
{
    var influxDbUrl = "http://localhost:8086";
    var token = "5Nqh-5gis9t8Sn8RDou4BxXLpzENxLadcrdKCjr5_wcb9z5zFI31lEBw2NZ_4ziNRTzEMN_zEIp6FGG_iQSvUA==";
    var bucket = "bucket";
    var organization = "organization";

    return new InfluxClientService(influxDbUrl, token, bucket, organization);
});



builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", builder =>
    {

        builder.WithOrigins("http://localhost:3000")  
                  .AllowAnyMethod()
                  .AllowAnyHeader()
                  .AllowCredentials();
    });
});

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
    options.UseNpgsql(Environment.GetEnvironmentVariable("ConnectionStrings__DefaultConnection"));
}, ServiceLifetime.Transient);

AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

var app = builder.Build();


app.UseSwagger();
app.UseSwaggerUI();


app.UseCors("AllowAll");
app.UseHttpsRedirection();

app.UseMiddleware<ExceptionHandlingMiddleware>();

app.UseAuthentication();

app.UseAuthorization();

app.UseMiddleware<ClaimsMiddleware>();

app.MapControllers();


using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    var context = services.GetRequiredService<DatabaseContext>();
    if (context.Database.GetPendingMigrations().Any())
    {
        await context.Database.MigrateAsync();
    }

    var userService = services.GetRequiredService<IUserService>();

    await userService.GenerateSuperAdmin();
}

app.UseStaticFiles();

app.Run();
