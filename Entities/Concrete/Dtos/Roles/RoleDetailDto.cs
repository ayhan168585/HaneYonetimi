using Core.Entities.Abstract;
using Entities.Concrete.Dtos.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.Dtos.Roles
{
    public class RoleDetailDto:IDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<FamilyPersonDto> FamilyPersons { get; set; } = new();
    }
}
