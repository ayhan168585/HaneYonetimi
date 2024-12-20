using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.Dtos.Users
{
    public class FamilyPersonCreateDto : IDto
    {
        public string FullName { get; set; } // Kullanıcının tam adı
        public string Email { get; set; } // Kullanıcının e-posta adresi
        public string Password { get; set; } // Kullanıcının şifre bilgisi
        public string? ProfilePicture { get; set; } // Kullanıcının opsiyonel profil resmi
        public int RoleId { get; set; } // Kullanıcının rolü
    }
}
