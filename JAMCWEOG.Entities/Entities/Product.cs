using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace JAMCWEOG.Entities.Entities
{
    public class Product
    {
        public long Id { get; set; }

        [Display(Name = "Fabricante")]
        public int ManufacturerId { get; set; }

        [Display(Name = "Nombre del Producto")]
        public string? ModelName { get; set; }

        [Display(Name = "Precio")]
        public decimal Price { get; set; }

        [Display(Name = "Cantidad en Stock")]
        public int StockQuantity { get; set; }

    }
}
