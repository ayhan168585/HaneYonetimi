using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Unit : IEntity
    {
        public int Id { get; set; } // Birim ID'si
        public string Name { get; set; } // Birim adı (örneğin: "kg", "adet")

        // Navigation Property
        public ICollection<MarketItem> MarketItems { get; set; } // Bu birimi kullanan market item'lar
    }
}
