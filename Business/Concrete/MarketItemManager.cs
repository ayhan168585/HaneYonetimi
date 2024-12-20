using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Concrete.Dtos.ExpenseItems;
using Entities.Concrete.Dtos.MarketItems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class MarketItemManager : IMarketItemService
    {
        IMarketItemDal _marketItemDal;

        public MarketItemManager(IMarketItemDal marketItemDal)
        {
            _marketItemDal = marketItemDal;
        }

        public IResult Add(MarketItem item)
        {
            _marketItemDal.Add(item);
            return new SuccessResult(Messages.MarketItemAdded);
        }

        public IResult AddMarketItem(MarketItemCreateDto marketItemCreateDto)
        {
            _marketItemDal.AddMarketItem(marketItemCreateDto);
            return new SuccessResult(Messages.MarketItemAdded);
        }

        public IResult Delete(MarketItem item)
        {
            _marketItemDal.Delete(item);
            return new SuccessResult(Messages.MarketItemDeleted);
        }

        public IResult DeleteMarketItem(int marketItemId)
        {
            _marketItemDal.DeleteMarketItem(marketItemId);
            return new SuccessResult(Messages.MarketItemDeleted);
        }

        public IDataResult<MarketItem> Get(int id)
        {
            return new SuccessDataResult<MarketItem>(_marketItemDal.Get(p=>p.Id==id), Messages.MarketItemDetailListed); 
        }

        public IDataResult<List<MarketItem>> GetAll()
        {
            return new SuccessDataResult<List<MarketItem>>(_marketItemDal.GetAll(),Messages.MarketItemsListed);
        }

        public IDataResult<object> MarketItemExpenses()
        {
           return new SuccessDataResult<object>(_marketItemDal.MarketItemExpenses(), Messages.MarketItemExpensesListed);
        }

        public IDataResult<List<MarketItemListDto>> MarketItemLists()
        {
            return new SuccessDataResult<List<MarketItemListDto>>(_marketItemDal.MarketItemLists(),Messages.MarketItemsListed);    
        }

        public IDataResult<List<ExpenseItemDto>> MarketItemListsByExpense(int expenseId)
        {
            return new SuccessDataResult<List<ExpenseItemDto>>(_marketItemDal.MarketItemListsByExpense(expenseId),Messages.MarketItemsListedByCategory);
        }

        public IResult Update(MarketItem item)
        {
            _marketItemDal.Update(item);
            return new SuccessResult(Messages.MarketItemUpdated);
        }

        public IResult UpdateMarketItem(MarketItemUpdateDto marketItemUpdateDto)
        {
            _marketItemDal.UpdateMarketItem(marketItemUpdateDto);
            return new SuccessResult(Messages.MarketItemUpdated);
        }
    }
}
