using Core.DataAccess.Abstract;
using Entities.Concrete;
using Entities.Concrete.Dtos.Users;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IFamilyPersonDal : IEntityRepository<FamilyPerson>
    {
        public List<FamilyPersonListDto> GetAllFamilyPersons();
        public FamilyPersonDetailDto GetFamilyPersonDetails(int userId);
        public List<FamilyPersonListDto> GetFamilyPersonsWithRoles();
        public List<FamilyPersonDto> FamilyPersonsInRoles(int roleId);
        public void AddFamilyPerson(FamilyPersonCreateDto userCreateDto);
        public bool UpdateFamilyPerson(FamilyPersonUpdateDto userUpdateDto);
        public bool DeleteFamilyPerson(int userId);
        public object FamilyPersonWiseFinancials();
        public object AverageFamilyPersonExpense();


    }
}
