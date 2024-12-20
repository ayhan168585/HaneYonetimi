using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Concrete.Dtos.Roles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class RoleManager : IRoleService
    {
        IRoleDal _roleDal;

        public RoleManager(IRoleDal roleDal)
        {
            _roleDal = roleDal;
        }


        public IResult Add(Role role)
        {
            _roleDal.Add(role);
            return new SuccessResult(Messages.RoleAdded);
        }

        public IResult AddRole(RoleCreateDto roleCreateDto)
        {
            _roleDal.AddRole(roleCreateDto);
            return new SuccessResult(Messages.RoleAdded);
        }

        public IResult Delete(Role role)
        {
            _roleDal.Delete(role);
            return new SuccessResult(Messages.RoleDeleted);
        }

        public IResult DeleteRole(int id)
        {
            _roleDal.DeleteRole(id);
            return new SuccessResult(Messages.RoleDeleted);
        }

        public IDataResult<List<Role>> GetAll()
        {
            return new SuccessDataResult<List<Role>>(_roleDal.GetAll(),Messages.RolesListed);
        }

        public IDataResult<List<RoleListDto>> GetAllRoles()
        {
            return new SuccessDataResult<List<RoleListDto>>(_roleDal.GetAllRoles(),Messages.RolesListed);
        }

        public IDataResult<Role> GetById(int id)
        {
            return new SuccessDataResult<Role>(_roleDal.Get(p=>p.Id == id),Messages.RoleDetailListed);
        }

        public IDataResult<RoleDetailDto> GetRoleDetails(int id)
        {
            return new SuccessDataResult<RoleDetailDto>(_roleDal.GetRoleDetails(id),Messages.RoleDetailListed);
        }

        public IResult Update(Role role)
        {
           _roleDal.Update(role);
            return new SuccessResult(Messages.RoleUpdated);
        }

        public IResult UpdateRole(RoleUpdateDto roleUpdateDto)
        {
            _roleDal.UpdateRole(roleUpdateDto);
            return new SuccessResult(Messages.RoleUpdated);
        }
    }
}
