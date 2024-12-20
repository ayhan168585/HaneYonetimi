using Core.DataAccess.Abstract;
using Entities.Concrete;
using Entities.Concrete.Dtos.ExpenseItems;
using Entities.Concrete.Dtos.MarketItems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IMarketItemDal:IEntityRepository<MarketItem>
    {
        public List<MarketItemListDto> MarketItemLists();
        public List<ExpenseItemDto> MarketItemListsByExpense(int expenseId);
        public void AddMarketItem(MarketItemCreateDto marketItemCreateDto);
        public void UpdateMarketItem(MarketItemUpdateDto marketItemUpdateDto);
        public object MarketItemExpenses();
        public bool DeleteMarketItem(int marketItemId);
    }
}
