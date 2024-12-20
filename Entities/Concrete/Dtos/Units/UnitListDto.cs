using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.Dtos.Units
{
    public class UnitListDto:IDto
    {
        public int Id { get; set; } // Birim ID'si
        public string Name { get; set; } // Birim adı
    }
}
