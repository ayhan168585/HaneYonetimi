using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.Dtos.Units
{
    public class UnitUpdateDto:IDto
    {
        public int Id { get; set; } // Güncellenecek birimin ID'si
        public string Name { get; set; } // Yeni birim adı
    }
}
