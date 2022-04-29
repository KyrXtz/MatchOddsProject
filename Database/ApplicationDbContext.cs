using System.Reflection;
using MatchOddsProject.Entities;
using Microsoft.EntityFrameworkCore;

namespace MatchOddsProject.Database
{
	public class ApplicationDbContext : DbContext
	{
		public DbSet<Match> Matches { get; set; }
		public DbSet<MatchOdds> MatchesOdds { get; set; }

		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
		{
		}

		protected override void OnModelCreating(ModelBuilder builder)
		{
			builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
			base.OnModelCreating(builder);			
		}
	}
}