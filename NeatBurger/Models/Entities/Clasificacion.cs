using System;
using System.Collections.Generic;

namespace NeatBurger.Models.Entities;

public partial class Clasificacion
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public virtual ICollection<Menu> Menu { get; } = new List<Menu>();
}
