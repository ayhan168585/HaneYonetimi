using Core.Entities.Abstract;
using Entities.Concrete.Dtos.MarketItems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.Dtos.Categories
{
    public class CategoryWithMarketItemsDto:IDto
    {
        public int Id { get; set; } // Kategori ID
        public string Name { get; set; } // Kategori Adı
        public List<MarketItemDto> MarketItems { get; set; } // Kategoriye ait Market Ürünleri
    }
}
