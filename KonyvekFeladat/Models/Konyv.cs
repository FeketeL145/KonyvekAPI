using System;
using System.Collections.Generic;

namespace KonyvekFeladat.Models;

public partial class Konyv
{
    public Guid Id { get; set; }

    public string Cim { get; set; } = null!;

    public int Oldalszam { get; set; }

    public string Szerzo { get; set; } = null!;

    public DateTime Kiadev { get; set; }
}
