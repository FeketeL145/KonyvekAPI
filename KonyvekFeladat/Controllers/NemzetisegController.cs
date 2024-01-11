using static KonyvekFeladat.Models.Dtos.Dtos;
using KonyvekFeladat.Models;
using KonyvekFeladat.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KonyvekFeladat.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NemzetisegController : ControllerBase
    {
        private readonly ISzerzoNemzetisegInterface nemzetisegInterface;

        public NemzetisegController(ISzerzoNemzetisegInterface nemzetisegInterface)
        {
            this.nemzetisegInterface = nemzetisegInterface;
        }
        [HttpPost]
        public async Task<ActionResult<Nemzetiseg>> Post(CreateNemzetisegDto createNemzetisegDto)
        {
            return StatusCode(201, await nemzetisegInterface.Post(createNemzetisegDto));
        }
        [HttpGet]
        public async Task<ActionResult<Nemzetiseg>> Get()
        {
            return StatusCode(201, await nemzetisegInterface.Get());
        }
        [HttpGet("id")]
        public async Task<ActionResult<Nemzetiseg>> GetById(Guid Id)
        {
            return await nemzetisegInterface.GetById(Id);
        }
        [HttpPut]
        public async Task<ActionResult<Nemzetiseg>> Put(Guid Id, UpdateNemzetisegDto updateNemzetisegDto)
        {
            var result = await nemzetisegInterface.Put(Id, updateNemzetisegDto);
            return StatusCode(201, result);
        }
        [HttpDelete]
        public async Task<ActionResult> Delete(Guid Id)
        {
            await nemzetisegInterface.Delete(Id);
            return Ok();
        }
    }
}
