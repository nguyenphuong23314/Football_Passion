using Application.Exceptions;
using Application.Interfaces.Repositories;
using Application.Wrappers;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Leagues.Commands.UpdateLeague
{
	public class UpdateLeagueCommand : IRequest<Response<Guid>>
	{
		public Guid Id { get; set; }
		public string Name { get; set; }
		public string Country { get; set; }
		public string CountryCode { get; set; }
		public DateTime SeasonStart { get; set; }
		public DateTime SeasonEnd { get; set; }

		public class UpdateLeagueCommandHandler : IRequestHandler<UpdateLeagueCommand, Response<Guid>>
		{
			private readonly ILeagueRepositoryAsync _leagueRepository;

			public UpdateLeagueCommandHandler(ILeagueRepositoryAsync leagueRepository)
			{
				_leagueRepository = leagueRepository;
			}

			public async Task<Response<Guid>> Handle(UpdateLeagueCommand command, CancellationToken cancellationToken)
			{
				var league = await _leagueRepository.GetByIdAsync(command.Id);

				if (league == null)
				{
					throw new ApiException($"League Not Found.");
				}
				else
				{
					league.Country = command.Country;
					league.CountryCode = command.CountryCode;
					league.Name = command.Name;
					league.SeasonStart = command.SeasonStart;
					league.SeasonEnd = command.SeasonEnd;
					await _leagueRepository.UpdateAsync(league);
					return new Response<Guid>(league.Id);
				}
			}
		}
	}
}