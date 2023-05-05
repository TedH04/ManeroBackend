using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using WebApi.Contexts;
using WebApi.Helpers.Jwt;
using WebApi.Models.Identity;
using WebApi.Repositories;
using WebApi.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Azure keyvault
builder.Configuration.AddAzureKeyVault(new Uri($"{builder.Configuration["KeyVault"]}"), new DefaultAzureCredential());

// Contexts
builder.Services.AddDbContext<IdentityContext>(x => x.UseSqlServer(builder.Configuration["ManeroG4Sql"]));

// Repositories
builder.Services.AddScoped<UserRepository>();

// Services
builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<JwtToken>();


// Auth/Identity
builder.Services.AddDefaultIdentity<CustomIdentityUser>(x =>
{
	x.User.RequireUniqueEmail = true;
	x.SignIn.RequireConfirmedAccount = false;
	x.Password.RequiredLength = 8;
}).AddEntityFrameworkStores<IdentityContext>();

// JWT
builder.Services.AddAuthentication(x =>
{
	x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
	x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(x =>
{
	x.Events = new JwtBearerEvents
	{
		OnTokenValidated = context =>
		{
			if (string.IsNullOrEmpty(context?.Principal?.FindFirst("id")?.Value) || string.IsNullOrEmpty(context?.Principal?.Identity?.Name))
				context?.Fail("Unauthorized");

			return Task.CompletedTask;
		}
	};

	x.RequireHttpsMetadata = true;
	x.SaveToken = true;
	x.TokenValidationParameters = new TokenValidationParameters
	{
		ValidateIssuer = true,
		ValidIssuer = builder.Configuration.GetSection("TokenValidation").GetValue<string>("Issuer")!,
		ValidateAudience = true,
		ValidAudience = builder.Configuration.GetSection("TokenValidation").GetValue<string>("Audience")!,
		ValidateLifetime = true,
		ValidateIssuerSigningKey = true,
		IssuerSigningKey = new SymmetricSecurityKey(
			Encoding.UTF8.GetBytes(builder.Configuration.GetSection("TokenValidation").GetValue<string>("SecretKey")!))
	};
});

var app = builder.Build();
app.UseCors(x => x.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod());
app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
