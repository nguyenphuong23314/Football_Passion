using System;

namespace Application.Features.Leagues.Queries.GetAllLeagues
{
	public class GetAllLeaguesViewModel
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Country { get; set; }
		public string CountryCode { get; set; }
		public DateTime SeasonStart { get; set; }
		public DateTime SeasonEnd { get; set; }
	}
}