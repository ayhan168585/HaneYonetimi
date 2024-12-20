using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.Dtos.MarketItems
{
    public class MarketItemPhotoDto : IDto
    {
        public int Id { get; set; }
        public string FilePath { get; set; } // Fotoğrafın yolu
    }
}
