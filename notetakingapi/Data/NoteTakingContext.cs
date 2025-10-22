using Microsoft.EntityFrameworkCore;
using notetakingapi.Models;

namespace notetakingapi.Data
{
	public class NoteTakingContext : DbContext
	{
		public NoteTakingContext(DbContextOptions<NoteTakingContext> options) : base(options) { }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			modelBuilder.Entity<Note>().HasData(
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
			);
		}

		public DbSet<Note> Notes { get; set; }
	}
}
