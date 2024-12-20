using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.Dtos.MarketItems
{
    public class MarketItemDto:IDto
    {
       
            public int Id { get; set; }
            public string Name { get; set; }
            public decimal Price { get; set; }
        public int UnitId { get; set; }

        public string CategoryName { get; set; } // Kategori adı

        
    }
}
