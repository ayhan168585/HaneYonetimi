using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.Dtos.Users
{
    public class FamilyPersonUpdateDto : IDto
    {
        public int Id { get; set; } // Güncellenmek istenen kullanıcının kimliği
        public string FullName { get; set; } // Kullanıcının güncellenmiş tam adı
        public string Email { get; set; } // Kullanıcının güncellenmiş e-posta adresi
        public string? ProfilePicture { get; set; } // Kullanıcının opsiyonel olarak güncellenmiş profil resmi
        public int RoleId { get; set; } // Kullanıcının güncellenmiş rolü
    }
}
