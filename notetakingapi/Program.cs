using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using notetakingapi.Data;
using notetakingapi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddAuthentication();

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

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapGroup("/api")
   .MapIdentityApi<IdentityUser>();

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

app.Run();

public class UserRegistrationModel
{
	public string Email { get; set; } = null!;
	public string Password { get; set; } = null!;
	public string FullName { get; set; } = null!;
}
