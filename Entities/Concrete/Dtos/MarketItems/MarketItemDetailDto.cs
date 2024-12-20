using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.Dtos.MarketItems
{
    public class MarketItemDetailDto:IDto
    {
        public int Id { get; set; } // Market item ID'si
        public string Name { get; set; } // Adı
        public decimal Price { get; set; } // Fiyat
        public int Quantity { get; set; } // Miktar
        public string CategoryName { get; set; } // Kategori adı
        public string UnitName { get; set; } // Birim adı

    }
}
