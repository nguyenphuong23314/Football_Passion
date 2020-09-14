using Application.Features.Leagues.Commands.CreateLeague;
using Application.Features.Leagues.Commands.DeleteLeagueById;
using Application.Features.Leagues.Commands.UpdateLeague;
using Application.Features.Leagues.Queries.GetAllLeagues;
using Application.Features.Leagues.Queries.GetLeagueById;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace FootballAPI.Controllers.v1
{
	[ApiVersion("1.0")]
	public class LeagueController : BaseApiController
	{
		// GET: api/<controller>
		[HttpGet]
		public async Task<IActionResult> Get([FromQuery] GetAllLeaguesParameter filter)
		{
			return Ok(await Mediator.Send(new GetAllLeaguesQuery() { PageSize = filter.PageSize, PageNumber = filter.PageNumber }));
		}

		// GET api/<controller>/5
		[HttpGet("{id}")]
		public async Task<IActionResult> Get(Guid id)
		{
			return Ok(await Mediator.Send(new GetLeagueByIdQuery { Id = id }));
		}

		// POST api/<controller>
		[HttpPost]
		[Authorize]
		public async Task<IActionResult> Post(CreateLeagueCommand command)
		{
			return Ok(await Mediator.Send(command));
		}

		// PUT api/<controller>/5
		[HttpPut("{id}")]
		[Authorize]
		public async Task<IActionResult> Put(Guid id, UpdateLeagueCommand command)
		{
			if (id != command.Id)
			{
				return BadRequest();
			}
			return Ok(await Mediator.Send(command));
		}

		// DELETE api/<controller>/5
		[HttpDelete("{id}")]
		[Authorize]
		public async Task<IActionResult> Delete(Guid id)
		{
			return Ok(await Mediator.Send(new DeleteLeagueByIdCommand { Id = id }));
		}
	}
}