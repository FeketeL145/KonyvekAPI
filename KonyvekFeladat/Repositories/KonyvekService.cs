using KonyvekFeladat.Models;
using static KonyvekFeladat.Models.Dtos.Dtos;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace KonyvekFeladat.Repositories
{
    public class KonyvekService : IKonyvInterface
    {
        private readonly KonyvekContext dbContext;

        public KonyvekService(KonyvekContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task Delete(Guid Id)
        {
            await dbContext.Konyvs.Where(x => x.Id == Id).ExecuteDeleteAsync();
            await dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Konyv>> Get()
        {
            return dbContext.Konyvs.ToList();
        }

        public async Task<Konyv> GetById(Guid Id)
        {
            return dbContext.Konyvs.SingleOrDefault(x => x.Id.Equals(Id));
        }

        public async Task<Konyv> Post(CreateKonyvDto createKonyvekDto)
        {
            var konyv = new Konyv
            {
                Id = Guid.NewGuid(),
                Cim = createKonyvekDto.Cim,
                Oldalszam = createKonyvekDto.Oldalszam,
                Szerzo = createKonyvekDto.Szerzo,
                Kiadev = createKonyvekDto.Kiadev
            };
            await dbContext.Konyvs.AddAsync(konyv);
            await dbContext.SaveChangesAsync();

            return konyv;
        }

        public async Task<Konyv> Put(Guid Id, UpdateKonyvDto updateKonyvDto)
        {
            var findid = dbContext.Konyvs.FirstOrDefault(x => x.Id.Equals(Id));

            findid.Cim = updateKonyvDto.Cim;
            findid.Oldalszam = updateKonyvDto.Oldalszam;
            findid.Szerzo = updateKonyvDto.Szerzo;
            findid.Kiadev = updateKonyvDto.Kiadev;

            await dbContext.SaveChangesAsync();

            return findid;
        }
    }
}
