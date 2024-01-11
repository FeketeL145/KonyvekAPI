using KonyvekFeladat.Models;
using static KonyvekFeladat.Models.Dtos.Dtos;


namespace KonyvekFeladat.Repositories
{
    public interface IKonyvInterface
    {
        Task<IEnumerable<Konyv>> Get();
        Task<Konyv> GetById(Guid Id);
        Task<Konyv> Post(CreateKonyvDto createKonyvekDto);
        Task<Konyv> Put(Guid Id, UpdateKonyvDto updateKonyvDto);
        Task Delete(Guid Id);
    }
}
