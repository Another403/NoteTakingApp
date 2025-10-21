using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using notetakingapi.Models;

namespace notetakingapi.Controllers {
	[Route("api/[controller]")]
	[ApiController]
	public class NotesController : ControllerBase
	{
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

		[HttpGet]
		public ActionResult<List<Note>> Get()
		{
			return Ok(notes);
		}

		[HttpGet("{id}")]
		public ActionResult<Note> GetNoteById(int id)
		{
			var note = notes.FirstOrDefault(x => x.Id == id);

			if (note == null)
				return NotFound();
			return Ok(note);
		}

		[HttpPost]
		public ActionResult<Note> AddNote(Note newNote)
		{
			if (newNote == null)
				return BadRequest();

			notes.Add(newNote);
			return CreatedAtAction(nameof(GetNoteById), new { id = newNote.Id }, newNote);
		}

		[HttpPut("{id}")]
		public IActionResult UpdateNote(int id, Note updatedNote)
		{
			var note = notes.FirstOrDefault(x => x.Id == id);
			if (note == null)
				return NotFound();

			note.Id = updatedNote.Id;
			note.Content = updatedNote.Content;
			note.LastUpdate = DateTime.Now.ToString();

			return NoContent();
		}

		[HttpDelete("{id}")]
		public IActionResult DeleteNote(int id) {
			var note = notes.FirstOrDefault(x => x.Id == id);
			if (note == null)
				return NotFound();

			notes.Remove(note);
			return NoContent(); 
		}
	}
}
