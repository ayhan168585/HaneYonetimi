using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.Dtos.MarketItems
{
    public class MarketItemUpdateDto:IDto
    {
        public int CategoryId { get; set; }
        public int MarketItemId { get; set; } // Ürünün ID'si
        public int Quantity { get; set; } // Ürün miktarı
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int UnitId { get; set; } // Yeni birim ID'si

    }
}
