using Core.Utilities.Results;
using Entities.Concrete;
using Entities.Concrete.Dtos.Incomes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IIncomeService
    {
        IDataResult<List<IncomeListDto>> GetIncomesInUser(int userId);
        IDataResult<IncomeDetailDto> GetIncomeDetail(int id);
        IDataResult<decimal> IncomeTotalinUser(int userId);
        IDataResult<decimal> IncomeTotalAllUser();
        IDataResult<List<Income>> GetAll();
        IDataResult<Income> GetById(int id);
        IResult Add(Income income);
        IResult AddIncome(IncomeCreateDto incomeCreateDto);
        IResult Update(Income income);
        IResult UpdateIncome(IncomeUpdateDto incomeUpdateDto);
        IResult Delete(Income ıncome);
        IDataResult<object> TopIncomeSources();

    }
}
