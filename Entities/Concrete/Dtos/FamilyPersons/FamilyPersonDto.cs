using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.Dtos.Users
{
    public class FamilyPersonDto:IDto
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
    }
}
