using Core.Utilities.Results;
using Entities.Concrete;
using Entities.Concrete.Dtos.Roles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IRoleService
    {
        IResult AddRole(RoleCreateDto roleCreateDto);

        IResult UpdateRole(RoleUpdateDto roleUpdateDto);

        IDataResult<List<RoleListDto>> GetAllRoles();
        IDataResult<RoleDetailDto> GetRoleDetails(int id);
        IDataResult<List<Role>> GetAll();
        IDataResult<Role> GetById(int id);
        IResult Add(Role role);
        IResult Update(Role role);
        IResult Delete(Role role);
        IResult DeleteRole(int id);
    }
}
