using Application.Features.Leagues.Commands.CreateLeague;
using Application.Features.Leagues.Queries.GetAllLeagues;
using AutoMapper;
using Domain.Entities;

namespace Application.Mappings
{
	public class GeneralProfile : Profile
	{
		public GeneralProfile()
		{
			CreateMap<League, GetAllLeaguesViewModel>().ReverseMap();
			CreateMap<CreateLeagueCommand, League>();
			CreateMap<GetAllLeaguesQuery, GetAllLeaguesParameter>();
		}
	}
}