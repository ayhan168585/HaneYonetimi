using Core.DataAccess.Abstract;
using Entities.Concrete;
using Entities.Concrete.Dtos.Roles;
using Entities.Concrete.Dtos.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IRoleDal:IEntityRepository<Role>
    {
        public void AddRole(RoleCreateDto roleCreateDto);
        public void UpdateRole(RoleUpdateDto roleUpdateDto);
        public bool DeleteRole(int roleId);        
        public List<RoleListDto> GetAllRoles();
        public RoleDetailDto GetRoleDetails(int id);
    }
}
