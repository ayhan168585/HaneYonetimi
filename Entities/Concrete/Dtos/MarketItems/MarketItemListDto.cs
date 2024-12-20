using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.Dtos.MarketItems
{
    public class MarketItemListDto:IDto
    {
        public int Id { get; set; }
        public string Name { get; set; } // Ürün adı
        public decimal Price { get; set; } // Ürün fiyatı
        public decimal Quantity { get; set; } // Miktar
        public string UnitName { get; set; }
        public string CategoryName { get; set; } // Kategori adı

    }
}
