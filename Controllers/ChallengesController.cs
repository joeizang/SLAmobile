using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SLAMobileApi.Dtos;
using SLAMobileApi.Services;

namespace SLAMobileApi.Controllers
{
    [Route("api/challenges")]
    [ApiController]
    public class ChallengesController : ControllerBase
    {
        private readonly IChallengeService _service;

        public ChallengesController(IChallengeService service)
        {
            _service = service;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces(typeof(CreateChallengeResponse))]
        public async Task<ActionResult<CreateChallengeResponse>> CreateChallenge(CreateChallengeInputModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Your request is in an inconsistent state!");
            }

            try
            {
                var result = await _service.CreateChallenge(model).ConfigureAwait(false);
                return Ok(result);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Produces(typeof(ChallengeDashboardViewModel))]
        public async Task<ActionResult<ChallengeDashboardViewModel>> GetChallenges()
        {
            return await _service.GetAllChallengesPerUser("1");
        }
    }
}