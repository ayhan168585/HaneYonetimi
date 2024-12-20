using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Concrete.Dtos.Users;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class FamilyPersonManager : IFamilyPersonService
    {
        IFamilyPersonDal _familyPersonDal;

        public FamilyPersonManager(IFamilyPersonDal familyPersonDal)
        {
            _familyPersonDal = familyPersonDal;
        }

        public IResult Add(FamilyPerson user)
        {
            _familyPersonDal.Add(user);
            return new SuccessResult(Messages.UserAdded);
        }

        public IResult AddFamilyPerson(FamilyPersonCreateDto userCreateDto)
        {
            _familyPersonDal.AddFamilyPerson(userCreateDto);
            return new SuccessResult(Messages.UserAdded);
        }

        public IDataResult<object> AverageFamilyPersonExpense()
        {
            return new SuccessDataResult<object>(_familyPersonDal.AverageFamilyPersonExpense(),Messages.AverageUserExpenseListed);
        }

        public IResult Delete(FamilyPerson user)
        {
            _familyPersonDal.Delete(user);
            return new SuccessResult(Messages.UserDeleted);
        }

        public IResult DeleteFamilyPerson(int userId)
        {
            _familyPersonDal.DeleteFamilyPerson(userId);
            return new SuccessResult(Messages.UserDeleted);
        }

        public IDataResult<List<FamilyPerson>> GetAll()
        {
           return new SuccessDataResult<List<FamilyPerson>>(_familyPersonDal.GetAll(),Messages.UsersListed);
        }

        public IDataResult<List<FamilyPersonListDto>> GetAllFamilyPersons()
        {
            return new SuccessDataResult<List<FamilyPersonListDto>>(_familyPersonDal.GetAllFamilyPersons(),Messages.UsersListed);
        }

        public IDataResult<FamilyPerson> GetById(int id)
        {
            return new SuccessDataResult<FamilyPerson>(_familyPersonDal.Get(p=>p.Id==id),Messages.UserDetailListed);
        }

        public IDataResult<FamilyPersonDetailDto> GetFamilyPersonDetail(int userId)
        {
            return new SuccessDataResult<FamilyPersonDetailDto>(_familyPersonDal.GetFamilyPersonDetails(userId),Messages.UserDetailListed);
        }

        public IDataResult<List<FamilyPersonListDto>> GetFamilyPersonsWithRoles()
        {
            return new SuccessDataResult<List<FamilyPersonListDto>>(_familyPersonDal.GetFamilyPersonsWithRoles(),Messages.UsersListed);
        }

        public IResult Update(FamilyPerson user)
        {
            _familyPersonDal.Update(user);
            return new SuccessResult(Messages.UserUpdated);
        }

        public IResult UpdateFamilyPerson(FamilyPersonUpdateDto userUpdateDto)
        {
            _familyPersonDal.UpdateFamilyPerson(userUpdateDto);
            return new SuccessResult(Messages.UserUpdated);
        }

      

        public IDataResult<List<FamilyPersonDto>> FamilyPersonsInRole(int roleId)
        {
            return new SuccessDataResult<List<FamilyPersonDto>>(_familyPersonDal.FamilyPersonsInRoles(roleId),Messages.UsersListed);
        }

        public IDataResult<object> FamilyPersonWiseFinancials()
        {
            return new SuccessDataResult<object>(_familyPersonDal.FamilyPersonWiseFinancials(),Messages.userWiseFinancialsListed);
        }
    }
}
