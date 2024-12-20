using Core.Entities.Abstract;
using Entities.Concrete.Dtos.MarketItems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.Dtos.Units
{
    public class UnitDetailDto:IDto
    {
        public int Id { get; set; } // Birim ID'si
        public string Name { get; set; } // Birim adı
        public List<MarketItemDto> MarketItems { get; set; } // Bu birime bağlı market item'lar
    }
}
