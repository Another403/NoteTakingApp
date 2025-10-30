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
		}

		public DbSet<Note> Notes { get; set; }
		public DbSet<AppUser> AppUsers { get; set; }
	}
}
