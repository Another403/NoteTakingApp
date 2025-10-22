namespace notetakingapi.Models;

public class Note
{
	public int Id { get; set; }
	public string Content { get; set; } = null!;
	public string CreatedAt { get; set; } = DateTime.Now.Date.ToString();
	public string LastUpdate { get; set; } = DateTime.Now.Date.ToString();
}
