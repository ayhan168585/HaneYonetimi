using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.Dtos.Categories
{
    public class CategoryCreateDto:IDto
    {
        public string Name { get; set; } // Kategori adı
    }
}
