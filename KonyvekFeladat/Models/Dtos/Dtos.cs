namespace KonyvekFeladat.Models.Dtos
{
    public class Dtos
    {
        //KonyvekDtos
        public record KonyvekDto(Guid Id, string Cim, int Oldalszam, string Szerzo, DateTime Kiadev);
        public record CreateKonyvDto(Guid Id, string Cim, int Oldalszam, string Szerzo,DateTime Kiadev);
        public record UpdateKonyvDto(string Cim, int Oldalszam, string Szerzo, DateTime Kiadev);
        //SzerzoDtos
        public record SzerzoDto(Guid Id, string Nev, bool Nem);
        public record CreateSzerzoDto(Guid Id, string Nev, bool Nem);
        public record UpdateSzerzoDto(string Nev, bool Nem);
        //NemzetisegDtos
        public record NemzetisegDto(Guid Id, string SzerzoNemzetiseg);
        public record CreateNemzetisegDto(Guid Id, string SzerzoNemzetiseg);
        public record UpdateNemzetisegDto(string SzerzoNemzetiseg);
    }
}
