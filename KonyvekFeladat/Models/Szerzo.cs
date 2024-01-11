using System;
using System.Collections.Generic;

namespace KonyvekFeladat.Models;

public partial class Szerzo
{
    public Guid Id { get; set; }

    public string Nev { get; set; } = null!;

    public bool Nem { get; set; }
}
