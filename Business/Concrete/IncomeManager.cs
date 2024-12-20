using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Concrete.Dtos.Incomes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class IncomeManager : IIncomeService
    {
        IIncomeDal _incomeDal;

        public IncomeManager(IIncomeDal incomeDal)
        {
            _incomeDal = incomeDal;
        }

        public IResult Add(Income income)
        {
            _incomeDal.Add(income);
            return new SuccessResult(Messages.IncomeAdded);
        }

        public IResult AddIncome(IncomeCreateDto incomeCreateDto)
        {
            _incomeDal.AddIncome(incomeCreateDto);
            return new SuccessResult(Messages.IncomeAdded);
        }

        public IResult Delete(Income income)
        {
            _incomeDal.Delete(income);
            return new SuccessResult(Messages.IncomeDeleted);
        }

        public IDataResult<List<Income>> GetAll()
        {
            return new SuccessDataResult<List<Income>>(_incomeDal.GetAll(),Messages.IncomesListed);
        }

        public IDataResult<Income> GetById(int id)
        {
            return new SuccessDataResult<Income>(_incomeDal.Get(p=>p.Id==id),Messages.IncomeDetailListed);
        }

        public IDataResult<IncomeDetailDto> GetIncomeDetail(int id)
        {
            return new SuccessDataResult<IncomeDetailDto>(_incomeDal.GetIncomeDetail(id),Messages.IncomeDetailListed);
        }

        public IDataResult<List<IncomeListDto>> GetIncomesInUser(int userId)
        {
            return new SuccessDataResult<List<IncomeListDto>>(_incomeDal.GetIncomesInUser(userId),Messages.IncomeInUserListed);
        }

        public IDataResult<decimal> IncomeTotalAllUser()
        {
            return new SuccessDataResult<decimal>(_incomeDal.IncomeTotalAllUser(), Messages.IncomeTotalAllUserListed);
        }

        public IDataResult<decimal> IncomeTotalinUser(int userId)
        {
           return new SuccessDataResult<decimal>(_incomeDal.IncomeTotalinUser(userId),Messages.IncomeTotalinUserListed);
        }

        public IDataResult<object> TopIncomeSources()
        {
            return new SuccessDataResult<object>(_incomeDal.TopIncomeSources(), Messages.TopIncomeSourcesListed);
        }

        public IResult Update(Income income)
        {
            _incomeDal.Update(income);
            return new SuccessResult(Messages.IncomeUpdated);           
        }

        public IResult UpdateIncome(IncomeUpdateDto incomeUpdateDto)
        {
            _incomeDal.UpdateIncome(incomeUpdateDto);
            return new SuccessResult(Messages.IncomeUpdated);
        }
    }
}
