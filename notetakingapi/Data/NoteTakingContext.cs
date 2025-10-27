using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using notetakingapi.Models;

namespace notetakingapi.Data
{
	public class NoteTakingContext : IdentityDbContext
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

			/*
			modelBuilder.Entity<AppUser>().HasData(
				new AppUser
				{
					UserName = "Akito",
					Password = "admin"
				},
				new AppUser
				{
					UserName = "Yusa",
					Password = "princess"
				},
				new AppUser
				{
					UserName = "Seven",
					Password = "alternative"
				}
			);
			*/
		}

		public DbSet<Note> Notes { get; set; }
		public DbSet<AppUser> AppUsers { get; set; }
	}
}
