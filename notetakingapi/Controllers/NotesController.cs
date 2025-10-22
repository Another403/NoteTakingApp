using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using notetakingapi.Data;
using notetakingapi.Models;
using System.Threading.Tasks;

namespace notetakingapi.Controllers {
	[Route("api/[controller]")]
	[ApiController]
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

		[HttpGet]
		public async Task<ActionResult<List<Note>>> Get()
		{
			return Ok(await _context.Notes.ToListAsync());
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
		public async Task<ActionResult<Note>> AddNote(Note newNote)
		{
			if (newNote == null)
				return BadRequest();

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
			note.LastUpdate = DateTime.Now.Date.ToString();

			await _context.SaveChangesAsync();

			return Ok(note);
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteNote(int id) {
			var note = await _context.Notes.FindAsync(id);
			if (note == null)
				return NotFound();

			_context.Notes.Remove(note);
			await _context.SaveChangesAsync();

			return Ok(note);
		}
	}
}
