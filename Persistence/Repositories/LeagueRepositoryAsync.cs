using Application.Interfaces.Repositories;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Contexts;

namespace Persistence.Repositories
{
	public class LeagueRepositoryAsync : GenericRepositoryAsync<League>, ILeagueRepositoryAsync
	{
		private readonly DbSet<League> _leagues;

		public LeagueRepositoryAsync(ApplicationDbContext dbContext) : base(dbContext)
		{
			_leagues = dbContext.Set<League>();
		}
	}
}