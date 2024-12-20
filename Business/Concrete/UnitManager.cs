using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Concrete.Dtos.Units;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    internal class UnitManager : IUnitService
    {
        IUnitDal _unitDal;

        public UnitManager(IUnitDal unitDal)
        {
            _unitDal = unitDal;
        }

        public IResult Add(Unit unit)
        {
           _unitDal.Add(unit);
            return new SuccessResult(Messages.UnitAdded);
        }

        public IResult AddUnit(UnitCreateDto unitCreateDto)
        {
           _unitDal.AddUnit(unitCreateDto);
            return new SuccessResult(Messages.UnitAdded);
        }

        public IResult Delete(Unit unit)
        {
           _unitDal.Delete(unit);
            return new SuccessResult(Messages.UnitDeleted);
        }

        public IResult DeleteUnit(int unitId)
        {
            _unitDal.DeleteUnit(unitId);
            return new SuccessResult(Messages.UnitDeleted);
        }

        public IDataResult<List<Unit>> GetAll()
        {
            return new SuccessDataResult<List<Unit>>(_unitDal.GetAll(),Messages.UnitsListed);
        }

        public IDataResult<List<UnitListDto>> GetAllUnits()
        {
            return new SuccessDataResult<List<UnitListDto>>(_unitDal.GetAllUnits(),Messages.UnitsListed);
        }

        public IDataResult<Unit> GetById(int id)
        {
            return new SuccessDataResult<Unit>(_unitDal.Get(p => p.Id == id), Messages.UnitDetailListed);
        }

        public IDataResult<UnitDetailDto> GetUnitDetail(int unitId)
        {
            return new SuccessDataResult<UnitDetailDto>(_unitDal.GetUnitDetail(unitId), Messages.UnitDetailListed);
        }

        public IResult Update(Unit unit)
        {
            _unitDal.Update(unit);
            return new SuccessResult(Messages.UnitUpdated);
        }

        public IResult UpdateUnit(UnitUpdateDto unitUpdateDto)
        {
            _unitDal.UpdateUnit(unitUpdateDto);
            return new SuccessResult(Messages.UnitUpdated);
        }
    }
}
