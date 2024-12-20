using System;
using System.Collections.Generic;
using System.Text;
using Core.DataAccess.Abstract;
using Entities.Concrete;
using Entities.Concrete.Dtos.Categories;
using Entities.Concrete.Dtos.Expenses;
using Entities.Concrete.Dtos.MarketItems;

namespace DataAccess.Abstract
{
    public interface IExpenseDal : IEntityRepository<Expense>
    {
        //public List<ExpenseDto> GetAllExpenses();
        public List<ExpenseDto> ExpenseListInUser(int userId);
        public List<ExpenseDto> GetAllExpenses();
        public ExpenseDetailDto ExpenseDetail(int expenseId);
        public void AddExpense(ExpenseCreateDto expenseCreateDto);
        public decimal ExpenseTotalInUser(int userId);
        public List<CategoryExpenseTotalDto> ExpenseForCategoryTotals();
        public void UpdateExpense(ExpenseUpdateDto expenseUpdateDto);
        public void DeleteExpense(int expenseId);
        public object CompareIncomeAndExpense();
        public object categoryWiseExpenses();
        public object DailyReports();
        public object YearlyFinancials();
        public object TopExpenseMonthOfYear();


    }
}
