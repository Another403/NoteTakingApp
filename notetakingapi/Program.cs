using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using notetakingapi.Data;
using notetakingapi.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
#region builder.Services
builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddAuthentication(x =>
{
	x.DefaultAuthenticateScheme =
	x.DefaultChallengeScheme =
	x.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(y =>
{
	y.SaveToken = false;
	y.TokenValidationParameters = new TokenValidationParameters
	{
		ValidateIssuerSigningKey = true,
		ValidateAudience = false,
		ValidateIssuer = false,
		ValidateLifetime = true,
		IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["AppSettings:JWTSecret"]!))
	};
});

builder.Services.Configure<IdentityOptions>(options =>
{
	options.Password.RequireNonAlphanumeric = false;
	options.Password.RequireUppercase = false;
	options.Password.RequiredLength = 0;
	options.Password.RequireUppercase = false;
	options.Password.RequireLowercase = false;
	options.User.RequireUniqueEmail = true;
});

builder.Services
    .AddIdentityApiEndpoints<AppUser>()
    .AddEntityFrameworkStores<NoteTakingContext>();

builder.Services.AddDbContext<NoteTakingContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddCors(options =>
{
	options.AddPolicy("AllowFrontend", policy =>
	{
		policy.WithOrigins("http://localhost:3000")
			  .AllowAnyHeader()
			  .AllowAnyMethod();
	});
});
#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

#region app.Use
app.UseCors("AllowFrontend");
app.UseRouting();
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.MapGroup("/api")
   .MapIdentityApi<IdentityUser>();
#endregion

#region Endpoints
app.MapPost("/api/signup", async (
	UserManager<AppUser> userManager,
	[FromBody] UserRegistrationModel userRegistrationModel
	) =>
	{
		AppUser user = new AppUser()
		{
		UserName = userRegistrationModel.Email,
		Email = userRegistrationModel.Email,
		FullName = userRegistrationModel.FullName,
		};
		var result = await userManager.CreateAsync(
			user,
			userRegistrationModel.Password);

		if (result.Succeeded)
		return Results.Ok(result);
		else
		return Results.BadRequest(result);
	});

app.MapPost("api/signin", async (
	UserManager<AppUser> userManager,
	[FromBody] LoginModel loginModel
	) =>
	{
		AppUser user = await userManager.FindByEmailAsync(loginModel.Email);
		if (user != null && await userManager.CheckPasswordAsync(user, loginModel.Password))
		{
			var signInKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["AppSettings:JWTSecret"]!));
			var tokenDescriptor = new SecurityTokenDescriptor
			{
				Subject = new ClaimsIdentity(new Claim[]
				{
					new Claim("UserID", user.Id.ToString())
				}),
				Expires = DateTime.UtcNow.AddMinutes(15),
				SigningCredentials = new SigningCredentials(
					signInKey,
					SecurityAlgorithms.HmacSha256Signature
					)
			};

			var tokenHandler = new JwtSecurityTokenHandler();
			var securityToken = tokenHandler.CreateToken(tokenDescriptor);
			var token = tokenHandler.WriteToken(securityToken);

			var refreshToken = Guid.NewGuid().ToString();
			user.RefreshToken = refreshToken;
			user.RefreshTokenExpiry = DateTime.UtcNow.AddDays(7);
			await userManager.UpdateAsync(user);

			return Results.Ok(new { token, refreshToken });
		} 
		else
		{
			return Results.BadRequest(new { message = "username or password is incorrect" });
		}
	});

app.MapPost("api/refreshToken", async (
	UserManager<AppUser> userManager,
	[FromBody] RefreshModel refreshModel
	) => 
	{
		AppUser user = await userManager.Users.FirstOrDefaultAsync(x => x.RefreshToken == refreshModel.RefreshToken);

		if (user == null || user.RefreshTokenExpiry <= DateTime.UtcNow)
		{
			return Results.Unauthorized();
		}

		var signInKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["AppSettings:JWTSecret"]!));
		var tokenDescriptor = new SecurityTokenDescriptor
		{
			Subject = new ClaimsIdentity(new Claim[]
			{
					new Claim("UserID", user.Id.ToString())
			}),
			Expires = DateTime.UtcNow.AddMinutes(15),
			SigningCredentials = new SigningCredentials(
				signInKey,
				SecurityAlgorithms.HmacSha256Signature
				)
		};

		var tokenHandler = new JwtSecurityTokenHandler();
		var securityToken = tokenHandler.CreateToken(tokenDescriptor);
		var token = tokenHandler.WriteToken(securityToken);

		return Results.Ok(new { token });
	});

app.MapPost("api/logout", async (
	UserManager<AppUser> userManager,
	ClaimsPrincipal currentUser
	) =>
	{
		var user = await userManager.FindByIdAsync(
					currentUser.FindFirstValue("UserID"));

		if (user == null) return Results.NotFound();

		user.RefreshToken = null;
		user.RefreshTokenExpiry = DateTime.MinValue;
		await userManager.UpdateAsync(user);

		return Results.Ok(new { message = "logged out succesfully" });
	});
#endregion

app.Run();

public class UserRegistrationModel
{
	public string Email { get; set; } = null!;
	public string Password { get; set; } = null!;
	public string FullName { get; set; } = null!;
}

public class LoginModel
{
	public string Email { get; set; } = null!;
	public string Password { get; set; } = null!;
}

public class RefreshModel
{
	public string RefreshToken { get; set; } = null!;
}
