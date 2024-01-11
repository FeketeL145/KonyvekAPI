using KonyvekFeladat.Models;
using static KonyvekFeladat.Models.Dtos.Dtos;
using System.Diagnostics;

namespace KonyvekFeladat
{
    public static class Extensions
    {
        public static KonyvekDto AsDto(this Konyv konyv)
        {
            return new(konyv.Id, konyv.Cim, konyv.Oldalszam, konyv.Szerzo, konyv.Kiadev);
        }
        public static SzerzoDto AsDto(this Szerzo szerzo)
        {
            return new(szerzo.Id, szerzo.Nev, szerzo.Nem);
        }
        public static NemzetisegDto AsDto(this Nemzetiseg nemzetiseg)
        {
            return new(nemzetiseg.Id, nemzetiseg.SzerzoNemzetiseg);
        }
    }
}
