using KonyvekFeladat.Models;
using static KonyvekFeladat.Models.Dtos.Dtos;

namespace KonyvekFeladat.Repositories
{
    public interface ISzerzoNemzetisegInterface
    {
        Task<IEnumerable<Nemzetiseg>> Get();
        Task<Nemzetiseg> GetById(Guid Id);
        Task<Nemzetiseg> Post(CreateNemzetisegDto createNemzetisegDto);
        Task<Nemzetiseg> Put(Guid Id, UpdateNemzetisegDto updateNemzetisegDto);
        Task Delete(Guid Id);
    }
}
