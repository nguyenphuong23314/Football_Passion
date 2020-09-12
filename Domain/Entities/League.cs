using Domain.Common;
using System;
using System.Collections.Generic;

namespace Domain.Entities
{
	public class League : BaseEntity
	{
		public string Name { get; set; }
		public string Country { get; set; }
		public string CountryCode { get; set; }
		public DateTime SeasonStart { get; set; }
		public DateTime SeasonEnd { get; set; }
		public virtual ICollection<UserLeague> UserLeagues { get; set; }
	}
}