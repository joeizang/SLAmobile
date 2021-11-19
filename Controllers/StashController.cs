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
    [Route("api/stash")]
    [ApiController]
    public class StashController : ControllerBase
    {
        private readonly IStashService _service;

        public StashController(IStashService service)
        {
            _service = service;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces(typeof(CreateStashResponse))]
        public async Task<ActionResult<CreateStashResponse>> CreateStash(CreateStashInputModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Your request is not in a consistent state!");
            }

            try
            {
                var result = await _service.CreateStash(model).ConfigureAwait(false);
                return Ok(result);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}