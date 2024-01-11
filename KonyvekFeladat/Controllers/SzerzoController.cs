using static KonyvekFeladat.Models.Dtos.Dtos;
using KonyvekFeladat.Models;
using KonyvekFeladat.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KonyvekFeladat.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SzerzoController : ControllerBase
    {
        private readonly ISzerzoInterface szerzoInterface;

        public SzerzoController(ISzerzoInterface szerzoInterface)
        {
            this.szerzoInterface = szerzoInterface;
        }
        [HttpPost]
        public async Task<ActionResult<Szerzo>> Post(CreateSzerzoDto createSzerzoDto)
        {
            return StatusCode(201, await szerzoInterface.Post(createSzerzoDto));
        }
        [HttpGet]
        public async Task<ActionResult<Szerzo>> Get()
        {
            return StatusCode(201, await szerzoInterface.Get());
        }
        [HttpGet("id")]
        public async Task<ActionResult<Szerzo>> GetById(Guid Id)
        {
            return await szerzoInterface.GetById(Id);
        }
        [HttpPut]
        public async Task<ActionResult<Szerzo>> Put(Guid Id, UpdateSzerzoDto updateSzerzoDto)
        {
            var result = await szerzoInterface.Put(Id, updateSzerzoDto);
            return StatusCode(201, result);
        }
        [HttpDelete]
        public async Task<ActionResult> Delete(Guid Id)
        {
            await szerzoInterface.Delete(Id);
            return Ok();
        }
    }
}
