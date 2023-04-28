using Microsoft.EntityFrameworkCore;
using WebApi.Contexts;
using WebApi.Models.Identity;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


// Contexts
builder.Services.AddDbContext<IdentityContext>(x => x.UseSqlServer(builder.Configuration["ManeroG4Sql"]));

// Repositories


// Services


// Auth/Identity
builder.Services.AddDefaultIdentity<CustomIdentityUser>(x =>
{
	x.User.RequireUniqueEmail = true;
	x.SignIn.RequireConfirmedAccount = false;
	x.Password.RequiredLength = 8;
}).AddEntityFrameworkStores<IdentityContext>();

var app = builder.Build();
app.UseCors(x => x.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod());
app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
