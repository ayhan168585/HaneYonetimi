using Core.Utilities.Results;
using Entities.Concrete;
using Entities.Concrete.Dtos.Categories;
using Entities.Concrete.Dtos.Expenses;
using Entities.Concrete.Dtos.MarketItems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IExpenseService
    {
        IDataResult<List<Expense>> GetAll();
        //IDataResult<List<ExpenseDto>> GetAllExpenses();
        IDataResult<List<ExpenseDto>> ExpenseListInUser(int userId);
        IDataResult<ExpenseDetailDto> ExpenseDetail(int expenseId);
        IDataResult<List<CategoryExpenseTotalDto>> ExpenseForCategoryTotals();
        IDataResult<decimal> ExpenseTotalInUser(int userId);
        IDataResult<Expense> GetById(int id);
        IResult Add(Expense expense);
        IResult AddExpense(ExpenseCreateDto expenseCreateDto);
        IResult Update(Expense expense);
        //IResult UpdateExpense(ExpenseUpdateDto expenseUpdateDto);
        IResult Delete(Expense expense);
        IResult UpdateExpense(ExpenseUpdateDto expenseUpdateDto);
        IResult DeleteExpense(int expenseId);
        IDataResult<List<ExpenseDto>> GetAllExpenses();
        IDataResult<object> CompareIncomeAndExpense();
        IDataResult<object> categoryWiseExpenses();
        IDataResult<object> DailyReports();
        IDataResult<object> YearlyFinancials();
        IDataResult<object> TopExpenseMonthOfYear();









    }
}
