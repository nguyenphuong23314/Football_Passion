using Application.Interfaces.Repositories;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Leagues.Commands.CreateLeague
{
	public partial class CreateLeagueCommand : IRequest<Response<Guid>>
	{
		public string Name { get; set; }
		public string Country { get; set; }
		public string CountryCode { get; set; }
		public DateTime SeasonStart { get; set; }
		public DateTime SeasonEnd { get; set; }
	}

	public class CreateLeagueCommandHandler : IRequestHandler<CreateLeagueCommand, Response<Guid>>
	{
		private readonly ILeagueRepositoryAsync _leagueRepository;
		private readonly IMapper _mapper;

		public CreateLeagueCommandHandler(ILeagueRepositoryAsync leagueRepository, IMapper mapper)
		{
			_leagueRepository = leagueRepository;
			_mapper = mapper;
		}

		public async Task<Response<Guid>> Handle(CreateLeagueCommand request, CancellationToken cancellationToken)
		{
			var league = _mapper.Map<League>(request);
			await _leagueRepository.AddAsync(league);
			return new Response<Guid>(league.Id);
		}
	}
}