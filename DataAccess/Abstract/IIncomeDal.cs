using Core.DataAccess.Abstract;
using Entities.Concrete;
using Entities.Concrete.Dtos.Incomes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IIncomeDal:IEntityRepository<Income>
    {
        public void AddIncome(IncomeCreateDto incomeCreateDto);
        public void UpdateIncome(IncomeUpdateDto incomeUpdateDto);
        public List<IncomeListDto> GetIncomesInUser(int userId);
        public IncomeDetailDto GetIncomeDetail(int id);
        public decimal IncomeTotalinUser(int userId);
        public decimal IncomeTotalAllUser();
        public object TopIncomeSources();


    }
}
