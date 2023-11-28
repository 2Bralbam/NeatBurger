using System;
using System.Collections.Generic;

namespace NeatBurger.Models.Entities;

public partial class Menu
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string Descripción { get; set; } = null!;

    public double Precio { get; set; }

    public int IdClasificacion { get; set; }

    public double? PrecioPromocion { get; set; }

    public virtual Clasificacion IdClasificacionNavigation { get; set; } = null!;
}
