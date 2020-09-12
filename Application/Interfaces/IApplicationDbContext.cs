using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Application.Interfaces
{
	public interface IApplicationDbContext
	{
		DbSet<AppUser> AppUsers { get; set; }
		DbSet<League> Leagues { get; set; }
		DbSet<UserLeague> UserLeagues { get; set; }

		Task<int> SaveChanges();
	}
}