using Application.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Persistence.Contexts
{
	public class ApplicationDbContext : DbContext, IApplicationDbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
			: base(options)
		{
		}

		public DbSet<AppUser> AppUsers { get; set; }
		public DbSet<League> Leagues { get; set; }
		public DbSet<UserLeague> UserLeagues { get; set; }

		public async Task<int> SaveChanges()
		{
			return await base.SaveChangesAsync();
		}
	}
}