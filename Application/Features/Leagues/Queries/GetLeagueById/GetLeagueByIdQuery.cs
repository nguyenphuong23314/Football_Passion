using Application.Exceptions;
using Application.Interfaces.Repositories;
using Application.Wrappers;
using Domain.Entities;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Leagues.Queries.GetLeagueById
{
	public class GetLeagueByIdQuery : IRequest<Response<League>>
	{
		public Guid Id { get; set; }

		public class GetProductByIdQueryHandler : IRequestHandler<GetLeagueByIdQuery, Response<League>>
		{
			private readonly ILeagueRepositoryAsync _leagueRepository;

			public GetProductByIdQueryHandler(ILeagueRepositoryAsync leagueRepository)
			{
				_leagueRepository = leagueRepository;
			}

			public async Task<Response<League>> Handle(GetLeagueByIdQuery query, CancellationToken cancellationToken)
			{
				var league = await _leagueRepository.GetByIdAsync(query.Id);
				if (league == null) throw new ApiException($"Product Not Found.");
				return new Response<League>(league);
			}
		}
	}
}