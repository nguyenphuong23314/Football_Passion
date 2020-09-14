using Application.Interfaces.Repositories;
using Application.Wrappers;
using AutoMapper;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Leagues.Queries.GetAllLeagues
{
	public class GetAllLeaguesQuery : IRequest<PagedResponse<IEnumerable<GetAllLeaguesViewModel>>>
	{
		public int PageNumber { get; set; }
		public int PageSize { get; set; }
	}

	public class GetAllLeaguesQueryHandler : IRequestHandler<GetAllLeaguesQuery, PagedResponse<IEnumerable<GetAllLeaguesViewModel>>>
	{
		private readonly ILeagueRepositoryAsync _leagueRepository;
		private readonly IMapper _mapper;

		public GetAllLeaguesQueryHandler(ILeagueRepositoryAsync leagueRepository, IMapper mapper)
		{
			_leagueRepository = leagueRepository;
			_mapper = mapper;
		}

		public async Task<PagedResponse<IEnumerable<GetAllLeaguesViewModel>>> Handle(GetAllLeaguesQuery request, CancellationToken cancellationToken)
		{
			var validFilter = _mapper.Map<GetAllLeaguesParameter>(request);
			var league = await _leagueRepository.GetPagedReponseAsync(validFilter.PageNumber, validFilter.PageSize);
			var leagueViewModel = _mapper.Map<IEnumerable<GetAllLeaguesViewModel>>(league);
			return new PagedResponse<IEnumerable<GetAllLeaguesViewModel>>(leagueViewModel, validFilter.PageNumber, validFilter.PageSize);
		}
	}
}