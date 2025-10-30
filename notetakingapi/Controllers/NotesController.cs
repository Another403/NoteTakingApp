using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using notetakingapi.Data;
using notetakingapi.Models;
using System.Security.Claims;
using System.Threading.Tasks;

namespace notetakingapi.Controllers {
	[Route("api/[controller]")]
	[ApiController]
	[Authorize]
	public class NotesController : ControllerBase
	{
		/*
		static private List<Note> notes = new List<Note>
		{
			new Note
			{
				Id = 1,
				Content = "Hello, World!",
			},
			new Note
			{
				Id = 2,
				Content = "Hello, Akito!",
			},
			new Note
			{
				Id = 3,
				Content = "Hello, Seven!",
			},
			new Note
			{
				Id = 4,
				Content = "Hello!",
			},
			new Note
			{
				Id = 5,
				Content = "Hello, just Hello!",
			}
		};
		*/

		private readonly NoteTakingContext _context;

		public NotesController(NoteTakingContext context)
		{
			_context = context;
		}

		[AllowAnonymous]
		[HttpGet("all")]
		public async Task<ActionResult<List<Note>>> Get()
		{
			return Ok(await _context.Notes.ToListAsync());
		}

		[HttpGet]
		public async Task<ActionResult<List<Note>>> GetUserNotes()
		{
			var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
			var notes = await _context.Notes.Where(x => x.UserId == userId).ToListAsync();

			return Ok(notes);
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<Note>> GetNoteById(int id)
		{
			var note = await _context.Notes.FindAsync(id);

			if (note == null)
				return NotFound();
			return Ok(note);
		}

		[HttpPost]
		public async Task<ActionResult<Note>> AddNote([FromBody] Note newNote)
		{
			var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
			if (userId == null) return Unauthorized();

			if (newNote == null)
				return BadRequest();
			newNote.UserId = userId;

			_context.Notes.Add(newNote);
			await _context.SaveChangesAsync();

			return CreatedAtAction(nameof(GetNoteById), new { id = newNote.Id }, newNote);
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> UpdateNote(int id, Note updatedNote)
		{
			var note = await _context.Notes.FindAsync(id);
			if (note == null)
				return NotFound();

			note.Id = updatedNote.Id;
			note.Content = updatedNote.Content;
			note.LastUpdate = DateOnly.FromDateTime(DateTime.Now).ToString();

			await _context.SaveChangesAsync();

			return Ok(note);
		}

		[HttpPut("favorite/{id}")]
		public async Task<IActionResult> ToggleFavoriteStatus(int id)
		{
			var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
			if (userId == null)
				return Unauthorized();

			var note = await _context.Notes.FindAsync(id);
			if (note == null)
				return NotFound();
			
			if (note.UserId != userId)
				return BadRequest();

			note.IsFavorite = !note.IsFavorite;
			note.LastUpdate = DateOnly.FromDateTime(DateTime.Now).ToString(); 
			await _context.SaveChangesAsync();

			return Ok(note);
		}

		[HttpPut("restore/{id}")]
		public async Task<IActionResult> RestoreNote(int id)
		{
			var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
			if (userId == null)
				return Unauthorized();

			var note = await _context.Notes.FindAsync(id);
			if (note == null)
				return NotFound();

			if (note.UserId != userId)
				return BadRequest();

			note.IsTrash = false;
			await _context.SaveChangesAsync();

			return Ok(note);
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteNote(int id) {
			var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
			if (userId == null) 
				return Unauthorized();

			var note = await _context.Notes.FindAsync(id);
			if (note == null)
				return NotFound();

			if (note.UserId != userId)
				return BadRequest();

			if (note.IsTrash)
			{
				_context.Notes.Remove(note);
			}
			else
			{
				note.IsTrash = true;
			}
			await _context.SaveChangesAsync();

			return Ok(note);
		}
	}
}
