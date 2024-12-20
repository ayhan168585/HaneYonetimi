using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class MarketItemPhoto : IEntity
    {
        public int Id { get; set; }
        public int MarketItemId { get; set; }
        public MarketItem MarketItem { get; set; }
        public string FilePath { get; set; } // Fotoğraf dosya yolu
        public DateTime UploadedAt { get; set; } = DateTime.UtcNow; // Yüklenme tarihi
    }
}
