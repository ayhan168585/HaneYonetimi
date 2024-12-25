using Core.Utilities.Results;
using Entities.Concrete;
using Entities.Concrete.Dtos.Users;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IFamilyPersonService
    {
        IDataResult <List<FamilyPersonListDto>> GetAllFamilyPersons();
        IDataResult<List<FamilyPersonListDto>> GetFamilyPersonsWithRoles();
        IDataResult<List<FamilyPersonDto>> FamilyPersonsInRole(int roleId);

        IDataResult<FamilyPersonDetailDto> GetFamilyPersonDetail(int userId);
        IDataResult<List<FamilyPerson>> GetAll();
        IDataResult<FamilyPerson> GetById(int id);
        IResult AddFamilyPerson(FamilyPersonCreateDto userCreateDto);
        IResult Add(FamilyPerson user);
        IResult Update(FamilyPerson user);
        IResult UpdateFamilyPerson(FamilyPersonUpdateDto userUpdateDto);
        IResult Delete(FamilyPerson user);
        IResult DeleteFamilyPerson(int userId);
        IDataResult<object> FamilyPersonWiseFinancials();
        IDataResult<object> AverageFamilyPersonExpense();
        IResult TransactionalOperation(FamilyPerson familyPerson);



    }
}
