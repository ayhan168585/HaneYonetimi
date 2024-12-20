using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.Dtos.Users
{
    public class FamilyPersonListDto : IDto
    {
        public int Id { get; set; } // Kullanıcının kimliği
        public string FullName { get; set; } // Kullanıcının tam adı
        public string Email { get; set; } // Kullanıcının e-posta adresi
        public string RoleName { get; set; } // Kullanıcının rol adı
    }
}
