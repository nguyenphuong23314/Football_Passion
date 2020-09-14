using Application.Exceptions;
using Application.Interfaces.Repositories;
using Application.Wrappers;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Leagues.Commands.DeleteLeagueById
{
	public class DeleteLeagueByIdCommand : IRequest<Response<Guid>>
	{
		public Guid Id { get; set; }

		public class DeleteLeagueByIdCommandHandler : IRequestHandler<DeleteLeagueByIdCommand, Response<Guid>>
		{
			private readonly ILeagueRepositoryAsync _leagueRepository;

			public DeleteLeagueByIdCommandHandler(ILeagueRepositoryAsync leagueRepository)
			{
				_leagueRepository = leagueRepository;
			}

			public async Task<Response<Guid>> Handle(DeleteLeagueByIdCommand command, CancellationToken cancellationToken)
			{
				var league = await _leagueRepository.GetByIdAsync(command.Id);
				if (league == null) throw new ApiException($"League Not Found.");
				await _leagueRepository.DeleteAsync(league);
				return new Response<Guid>(league.Id);
			}
		}
	}
}