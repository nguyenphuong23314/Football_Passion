using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace Domain.Entities
{
	public class AppUser : IdentityUser
	{
		public string DisplayName { get; set; }
		public virtual ICollection<UserLeague> UserLeagues { get; set; }
	}
}