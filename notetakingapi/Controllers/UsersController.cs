using notetakingapi.Data;
using notetakingapi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace notetakingapi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class UsersController : ControllerBase
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

		public UsersController(NoteTakingContext context)
		{
			_context = context;
		}

		
		[HttpGet]
		public async Task<ActionResult<List<User>>> GetUsers() {
			return Ok(await _context.Users.ToListAsync());
		}

		/*
		[HttpGet("{id}")]
		public ActionResult<User> GetUserById(int id)
		{
			var user = users.FirstOrDefault(x => x.Id == id);

			if (user == null)
			{
				return NotFound();
			}

			return Ok(user);
		}

		[HttpPost]
		public ActionResult<Note> AddUser(User user)
		{
			if (user == null)
			{
				return BadRequest();
			}

			users.Add(user);

			return CreatedAtAction(nameof(GetUserById), new { id = user.Id }, user);
		}

		[HttpPut("{id}")]
		public IActionResult UpdateUser(int id, User updateUser)
		{
			var user = users.FirstOrDefault(x => x.Id == id);

			if (user == null)
			{
				return NotFound();
			}

			user.Password = updateUser.Password;
			user.Email = updateUser.Email;

			return Ok(user);
		}

		[HttpDelete("{id}")]
		public IActionResult DeleteUser(int id)
		{
			var user = users.FirstOrDefault(x => x.Id == id);

			if (user == null)
			{
				return NotFound();
			}

			users.Remove(user);

			return Ok(user);
		}
		*/
	}
}
