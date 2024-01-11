using KonyvekFeladat.Models;
using static KonyvekFeladat.Models.Dtos.Dtos;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace KonyvekFeladat.Repositories
{
    public class SzerzoService : ISzerzoInterface
    {
        private readonly KonyvekContext dbContext;

        public SzerzoService(KonyvekContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task Delete(Guid Id)
        {
            await dbContext.Szerzos.Where(x => x.Id == Id).ExecuteDeleteAsync();
            await dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Szerzo>> Get()
        {
            return dbContext.Szerzos.ToList();
        }

        public async Task<Szerzo> GetById(Guid Id)
        {
            return dbContext.Szerzos.SingleOrDefault(x => x.Id.Equals(Id));
        }

        public async Task<Szerzo> Post(CreateSzerzoDto createSzerzoDto)
        {
            var szerzo = new Szerzo
            {
                Id = Guid.NewGuid(),
                Nev = createSzerzoDto.Nev,
                Nem = createSzerzoDto.Nem,
            };
            await dbContext.Szerzos.AddAsync(szerzo);
            await dbContext.SaveChangesAsync();

            return szerzo;
        }

        public async Task<Szerzo> Put(Guid Id, UpdateSzerzoDto updateSzerzoDto)
        {
            var findid = dbContext.Szerzos.FirstOrDefault(x => x.Id.Equals(Id));

            findid.Nev = updateSzerzoDto.Nev;
            findid.Nem = updateSzerzoDto.Nem;

            await dbContext.SaveChangesAsync();

            return findid;
        }
    }
}
