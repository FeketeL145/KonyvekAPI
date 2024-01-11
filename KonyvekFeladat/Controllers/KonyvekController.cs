using static KonyvekFeladat.Models.Dtos.Dtos;
using KonyvekFeladat.Models;
using KonyvekFeladat.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KonyvekFeladat.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KonyvekController : ControllerBase
    {
        private readonly IKonyvInterface konyvInterface;

        public KonyvekController(IKonyvInterface konyvInterface)
        {
            this.konyvInterface = konyvInterface;
        }
        [HttpPost]
        public async Task<ActionResult<Konyv>> Post(CreateKonyvDto createKonyvDto)
        {
            return StatusCode(201, await konyvInterface.Post(createKonyvDto));
        }
        [HttpGet]
        public async Task<ActionResult<Konyv>> Get()
        {
            return StatusCode(201, await konyvInterface.Get());
        }
        [HttpGet("id")]
        public async Task<ActionResult<Konyv>> GetById(Guid Id)
        {
            return await konyvInterface.GetById(Id);
        }
        [HttpPut]
        public async Task<ActionResult<Konyv>> Put(Guid Id, UpdateKonyvDto updateKonyvDto)
        {
            var result = await konyvInterface.Put(Id, updateKonyvDto);
            return StatusCode(201, result);
        }
        [HttpDelete]
        public async Task<ActionResult> Delete(Guid Id)
        {
            await konyvInterface.Delete(Id);
            return Ok();
        }
    }
}
