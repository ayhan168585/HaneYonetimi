using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Concrete.Dtos.Categories;
using Entities.Concrete.Dtos.Expenses;
using Entities.Concrete.Dtos.MarketItems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ExpenseManager : IExpenseService
    {
        IExpenseDal _expenseDal;

        public ExpenseManager(IExpenseDal expenseDal)
        {
            _expenseDal = expenseDal;
        }

        public IResult Add(Expense expense)
        {
            _expenseDal.Add(expense);
            return new SuccessResult(Messages.ExpenseAdded);
        }

        public IResult AddExpense(ExpenseCreateDto expenseCreateDto)
        {
            _expenseDal.AddExpense(expenseCreateDto);
            return new SuccessResult(Messages.ExpenseAdded);
        }

      

        public IResult Delete(Expense expense)
        {
            _expenseDal.Delete(expense);
            return new SuccessResult(Messages.ExpenseDeleted);
        }

        public IDataResult<ExpenseDetailDto> ExpenseDetail(int expenseId)
        {
            return new SuccessDataResult<ExpenseDetailDto>(_expenseDal.ExpenseDetail(expenseId), Messages.ExpenseDetailListed);
        }

        public IDataResult<List<ExpenseDto>> ExpenseListInUser(int userId)
        {
           return new SuccessDataResult<List<ExpenseDto>>(_expenseDal.ExpenseListInUser(userId),Messages.ExpensesListInUser);
        }

        public IDataResult<decimal> ExpenseTotalInUser(int userId)
        {
            return new SuccessDataResult<decimal>(_expenseDal.ExpenseTotalInUser(userId),Messages.ExpenseTotalInUser);
        }

        public IDataResult<List<Expense>> GetAll()
        {
            return new SuccessDataResult<List<Expense>>(_expenseDal.GetAll(),Messages.ExpensesListed);
        }

        public IDataResult<Expense> GetById(int id)
        {
            return new SuccessDataResult<Expense>(_expenseDal.Get(p=>p.Id==id),Messages.ExpenseDetailListed);
        }

        public IResult Update(Expense expense)
        {
            _expenseDal.Update(expense);
            return new SuccessResult(Messages.ExpenseUpdated);
        }



        public IDataResult<List<CategoryExpenseTotalDto>> ExpenseForCategoryTotals()
        {
            return new SuccessDataResult<List<CategoryExpenseTotalDto>>(_expenseDal.ExpenseForCategoryTotals(),Messages.ExpensesListByCategory);
        }

        public IResult UpdateExpense(ExpenseUpdateDto expenseUpdateDto)
        {
            _expenseDal.UpdateExpense(expenseUpdateDto);
            return new SuccessResult(Messages.ExpenseUpdated);
        }

        public IResult DeleteExpense(int expenseId)
        {
            _expenseDal.DeleteExpense(expenseId);
            return new SuccessResult(Messages.ExpenseDeleted);
        }

        public IDataResult<List<ExpenseDto>> GetAllExpenses()
        {
            return new SuccessDataResult<List<ExpenseDto>>(_expenseDal.GetAllExpenses(),Messages.ExpensesListed);
        }

        public IDataResult<object> CompareIncomeAndExpense()
        {
            return new SuccessDataResult<object>(_expenseDal.CompareIncomeAndExpense(),Messages.CompareIncomeAndExpenseListed);
        }

        public IDataResult<object> categoryWiseExpenses()
        {
            return new SuccessDataResult<object>(_expenseDal.categoryWiseExpenses(), Messages.categoryWiseExpensesListed);
        }

        public IDataResult<object> DailyReports()
        {
            return new SuccessDataResult<object>(_expenseDal.DailyReports(), Messages.DailyReportsListed);
        }

        public IDataResult<object> YearlyFinancials()
        {
            return new SuccessDataResult<object>(_expenseDal.YearlyFinancials(), Messages.YearlyFinancialsListed);
        }

        public IDataResult<object> TopExpenseMonthOfYear()
        {
            return new SuccessDataResult<object>(_expenseDal.TopExpenseMonthOfYear(), Messages.TopExpenseMonthOfYearListed);
        }
    }
}

