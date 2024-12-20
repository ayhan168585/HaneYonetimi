using Core.Utilities.Results;
using Entities.Concrete;
using Entities.Concrete.Dtos.ExpenseItems;
using Entities.Concrete.Dtos.MarketItems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IMarketItemService
    {
        IDataResult<List<MarketItem>> GetAll();
        IDataResult<List<MarketItemListDto>> MarketItemLists();
        IDataResult<List<ExpenseItemDto>> MarketItemListsByExpense(int expenseId);
        IDataResult<MarketItem> Get(int id);
        IResult Add(MarketItem item);
        IResult AddMarketItem(MarketItemCreateDto marketItemCreateDto);   
        IResult Update(MarketItem item);
        IResult UpdateMarketItem(MarketItemUpdateDto marketItemUpdateDto);
        IResult Delete(MarketItem item);
        IDataResult<object> MarketItemExpenses();
        IResult DeleteMarketItem(int marketItemId);



    }
}
