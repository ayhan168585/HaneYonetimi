using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Role:IEntity
    {
        public int Id { get; set; } // Rolün benzersiz kimliği
        public string Name { get; set; } // Rol adı
        public ICollection<FamilyPerson> FamilyPersons { get; set; } // Kullanıcıların rol ile ilişkisi
    }
}
