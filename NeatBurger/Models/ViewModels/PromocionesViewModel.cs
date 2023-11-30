﻿using NeatBurger.Models.MyEntities;

namespace NeatBurger.Models.ViewModels
{
    public class PromocionesViewModel
    {
        public PromocionModel Promocion { get; set; } = null!;
        public string PromocionSiguiente { get; set; } = null!;
        public string PromocionAnterior { get; set; } = null!;
    }
}
