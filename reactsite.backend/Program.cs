using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using NLog.Web;
using reactsite.DAL;
using reactsite.DAL.Interfaces;
using reactsite.DAL.Repositories;
using reactsite.Domain.Entity;
using reactsite.Domain.Helpers;
using reactsite.Service.Implementations;
using reactsite.Service.Interfaces;

var builder = WebApplication.CreateBuilder(args);



builder.Logging.ClearProviders();
builder.Logging.SetMinimumLevel(Microsoft.Extensions.Logging.LogLevel.Trace);
builder.Host.UseNLog();



var con = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(x => x.UseSqlServer(con));

//AUTH
var auth = builder.Configuration.GetSection("Auth");
builder.Services.Configure<AuthOptions>(auth);
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
        builderr =>
        {
            builderr.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader();
        }
        );
});
var authOptions = auth.Get<AuthOptions>();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.RequireHttpsMetadata = false;
        options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidIssuer=authOptions.Issuer,
            
            ValidateAudience=true,
            ValidAudience=authOptions.Audience,

            ValidateLifetime=true,

            IssuerSigningKey=authOptions.GetSemmetricSecurityKey(),
            ValidateIssuerSigningKey=true

        };
    });


builder.Services.AddScoped<IBaseRepository<User>, UserRepository>();
builder.Services.AddScoped<IAccountService, AccountService>();

builder.Services.AddScoped<IBaseRepository<Profile>, ProfileRepository>();
builder.Services.AddScoped<IProfileService, ProfileService>();

builder.Services.AddScoped<IBaseRepository<DailyTasks>, DailyTasksRepository>();
builder.Services.AddScoped<IDailyTasksService, DailyTasksService>();

/*builder.Services.AddScoped<IBaseRepository<Activity>, ActivityRepository>();
builder.Services.AddScoped<IActivityService, ActivityService>();*/

builder.Services.AddControllers();


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSwaggerGen(c => {
    c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
    c.IgnoreObsoleteActions();
    c.IgnoreObsoleteProperties();
    c.CustomSchemaIds(type => type.FullName);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseCors();

app.UseAuthentication();
app.UseAuthorization();


app.MapControllers();

app.Run();
