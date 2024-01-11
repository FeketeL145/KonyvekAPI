using KonyvekFeladat.Models;
using static KonyvekFeladat.Models.Dtos.Dtos;

namespace KonyvekFeladat.Repositories
{
    public interface ISzerzoInterface
    {
        Task<IEnumerable<Szerzo>> Get();
        Task<Szerzo> GetById(Guid Id);
        Task<Szerzo> Post(CreateSzerzoDto createSzerzoDto);
        Task<Szerzo> Put(Guid Id, UpdateSzerzoDto updateSzerzoDto);
        Task Delete(Guid Id);
    }
}
