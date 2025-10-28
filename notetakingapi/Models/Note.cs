namespace notetakingapi.Models;

public class Note
{
	public int Id { get; set; }
	public string UserId { get; set; } = "";
	public string Title { get; set; } = "";
	public string Content { get; set; } = null!;
	public string CreatedAt { get; set; } = DateOnly.FromDateTime(DateTime.Now).ToString();
	public string LastUpdate { get; set; } = DateOnly.FromDateTime(DateTime.Now).ToString();
}
