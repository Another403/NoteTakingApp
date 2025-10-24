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

			modelBuilder.Entity<User>().HasData(
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
			);
		}

		public DbSet<Note> Notes { get; set; }
		public DbSet<User> Users { get; set; }
	}
}
