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
    [Route("api/savings")]
    [ApiController]
    public class SavingsController : ControllerBase
    {
        private readonly ISlaSavingsService _service;

        public SavingsController(ISlaSavingsService service)
        {
            _service = service;
        }
        // GET: api/Savings
        // [HttpGet]
        // public IEnumerable<string> Get()
        // {
        //     return new string[] { "value1", "value2" };
        // }
        //
        // // GET: api/Savings/5
        // [HttpGet("{id}", Name = "Get")]
        // public string Get(int id)
        // {
        //     return "value";
        // }

        // POST: api/Savings
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces(typeof(CreateSavingsResponse))]
        public async Task<ActionResult<CreateSavingsResponse>> CreateSavings([FromBody] CreateSavingsInputModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Your request is in an inconsistent state!");
            }

            try
            {
                var result = await _service.CreateSavings(model).ConfigureAwait(false);
                return Ok(result);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        // PUT: api/Savings/5
        // [HttpPut("{id}")]
        // public void Put(int id, [FromBody] string value)
        // {
        // }
        //
        // // DELETE: api/Savings/5
        // [HttpDelete("{id}")]
        // public void Delete(int id)
        // {
        // }
    }
}
