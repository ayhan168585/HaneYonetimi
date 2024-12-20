using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.Dtos.Categories
{
    public class CategoryUpdateDto:IDto
    {
        public int Id { get; set; } // Güncellenecek kategori ID'si
        public string Name { get; set; } // Yeni kategori adı
    }
}
