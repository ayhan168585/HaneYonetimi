using Core.DataAccess.Concrete.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Concrete.Dtos.Roles;
using Entities.Concrete.Dtos.Users;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRoleDal : EfEntityRepositoryBase<Role, HaneYonetimiContext>, IRoleDal
    {

        public void AddRole(RoleCreateDto roleCreateDto)
        {
            using (HaneYonetimiContext context = new HaneYonetimiContext())
            {
                var role = new Role
                {
                    Name = roleCreateDto.Name
                };

                context.Roles.Add(role);
                context.SaveChanges();

            }
        }

        public bool DeleteRole(int roleId)
        {
            using (HaneYonetimiContext context=new HaneYonetimiContext())
            {
                var role = context.Roles.Find(roleId);

                if (role == null) return false;

                context.Roles.Remove(role);
                context.SaveChangesAsync();
                return true;
            }
        }

        public List<RoleListDto> GetAllRoles()
        {
            using (HaneYonetimiContext context = new HaneYonetimiContext())
            {
                var roles = context.Roles
                .Select(r => new RoleListDto
                    {
                        Id = r.Id,
                        Name = r.Name
                    })
                    .ToList();
                return roles;

            }
           
        }

        public RoleDetailDto GetRoleDetails(int roleId)
        {
            using (HaneYonetimiContext context=new HaneYonetimiContext())
            {
                var roleDetail = context.Roles
                .Where(r => r.Id == roleId)
                .Include(r => r.FamilyPersons)
                .Select(r => new RoleDetailDto
                {
                    Id = r.Id,
                    Name = r.Name,
                    FamilyPersons = r.FamilyPersons.Select(u => new FamilyPersonDto
                    {
                        Id = u.Id,
                        FullName = u.FullName,
                        Email = u.Email
                    }).ToList()
                })
                .SingleOrDefault();
                return roleDetail;

            }
        }

        public void UpdateRole(RoleUpdateDto roleUpdateDto)
        {
            using (HaneYonetimiContext context=new HaneYonetimiContext())
            {
                var role = context.Roles.Find(roleUpdateDto.Id);
                if (role != null)
                {
                    role.Name = roleUpdateDto.Name;
                    context.Roles.Update(role);
                    context.SaveChanges();
                }

            }
        }
    }
}
