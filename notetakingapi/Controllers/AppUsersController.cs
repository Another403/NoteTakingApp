using notetakingapi.Data;
using notetakingapi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace notetakingapi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AppUsersController : ControllerBase
	{
		/*
		static private List<User> users = new List<User>
		{
			new User
			{
				Id = 1,
				Username = "Akito",
				Password = "admin"
			},
			new User
			{
				Id = 2,
				Username = "Yusa",
				Password = "princess"
			},
			new User
			{
				Id = 3,
				Username = "Seven",
				Password = "alternative"
			}
		};
		*/

		private readonly NoteTakingContext _context;

		public AppUsersController(NoteTakingContext context)
		{
			_context = context;
		}

		[AllowAnonymous]
		[HttpGet]
		public async Task<ActionResult<List<AppUser>>> GetUsers() {
			return Ok(await _context.AppUsers.ToListAsync());
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<AppUser>> GetUserById(string id)
		{
			var user = await _context.AppUsers.FindAsync(id);

			if (user == null)
			{
				return NotFound();
			}

			return Ok(user);
		}
		
		[HttpPost]
		public async Task<ActionResult<Note>> AddUser(AppUser user)
		{
			if (user == null)
			{
				return BadRequest();
			}

			_context.AppUsers.Add(user);
			await _context.SaveChangesAsync();

			return CreatedAtAction(nameof(GetUserById), new { id = user.Id }, user);
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> UpdateUser(string id, AppUser updateUser)
		{
			var user = await _context.AppUsers.FindAsync(id);

			if (user == null)
			{
				return NotFound();
			}

			user.Email = updateUser.Email;

			await _context.SaveChangesAsync();

			return Ok(user);
		}
		
		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteUser(string id)
		{
			var user = await _context.AppUsers.FindAsync(id);

			if (user == null)
			{
				return NotFound();
			}

			_context.AppUsers.Remove(user);
			await _context.SaveChangesAsync();

			return Ok(user);
		}
		
	}
}
