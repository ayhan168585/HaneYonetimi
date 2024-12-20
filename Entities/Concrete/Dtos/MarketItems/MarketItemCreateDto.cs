using Core.Entities.Abstract;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.Dtos.MarketItems
{
    public class MarketItemCreateDto:IDto
    {
       public int CategoryId { get; set; }
        public int Quantity { get; set; } // Ürün miktarı
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int UnitId { get; set; } // Birim ID'si
        public List<IFormFile>? Photos { get; set; } // Fotoğraflar opsiyonel


    }
}
