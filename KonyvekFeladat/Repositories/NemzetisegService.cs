using KonyvekFeladat.Models;
using static KonyvekFeladat.Models.Dtos.Dtos;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace KonyvekFeladat.Repositories
{
    public class NemzetisegService : ISzerzoNemzetisegInterface
    {
        private readonly KonyvekContext dbContext;

        public NemzetisegService(KonyvekContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task Delete(Guid Id)
        {
            await dbContext.Nemzetisegs.Where(x => x.Id == Id).ExecuteDeleteAsync();
            await dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Nemzetiseg>> Get()
        {
            return dbContext.Nemzetisegs.ToList();
        }

        public async Task<Nemzetiseg> GetById(Guid Id)
        {
            return dbContext.Nemzetisegs.SingleOrDefault(x => x.Id.Equals(Id));
        }

        public async Task<Nemzetiseg> Post(CreateNemzetisegDto createNemzetisegDto)
        {
            var nemzetiseg = new Nemzetiseg
            {
                Id = Guid.NewGuid(),
                SzerzoNemzetiseg = createNemzetisegDto.SzerzoNemzetiseg,
            };
            await dbContext.Nemzetisegs.AddAsync(nemzetiseg);
            await dbContext.SaveChangesAsync();

            return nemzetiseg;
        }

        public async Task<Nemzetiseg> Put(Guid Id, UpdateNemzetisegDto updateNemzetisegDto)
        {
            var findid = dbContext.Nemzetisegs.FirstOrDefault(x => x.Id.Equals(Id));

            findid.SzerzoNemzetiseg = updateNemzetisegDto.SzerzoNemzetiseg;

            await dbContext.SaveChangesAsync();

            return findid;
        }
    }
}
