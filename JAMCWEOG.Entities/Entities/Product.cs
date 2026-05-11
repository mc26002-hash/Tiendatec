using System;
using System.Collections.Generic;
using System.Text;

namespace JAMCWEOG.Entities.Entities
{
    public class Product
    {
        public long Id { get; set; }

        public int ManufacturerId { get; set; }

        public string ModelName { get; set; }

        public decimal Price { get; set; }

        public int StockQuantity { get; set; }

        public Manufacturer Manufacturer { get; set; }
    }
}
