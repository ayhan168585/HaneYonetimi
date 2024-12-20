using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.Dtos.Units
{
    public class UnitCreateDto:IDto
    {
        public string Name { get; set; } // Eklenecek birim adı
    }
}
