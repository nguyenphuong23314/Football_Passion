using Domain.Common;
using System;

namespace Domain.Entities
{
	public class UserLeague : BaseEntity
	{
		public string AppUserId { get; set; }
		public virtual AppUser AppUser { get; set; }
		public Guid LeagueId { get; set; }
		public virtual League League { get; set; }
	}
}