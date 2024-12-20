using Core.Utilities.Results;
using Entities.Concrete;
using Entities.Concrete.Dtos.Units;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IUnitService
    {
        IResult Add(Unit unit);
        IResult Update(Unit unit);
        IResult Delete(Unit unit);
        IDataResult<List<Unit>> GetAll();
        IDataResult<Unit> GetById(int id);
        IResult AddUnit(UnitCreateDto unitCreateDto);
        IResult UpdateUnit(UnitUpdateDto unitUpdateDto);
        IResult DeleteUnit(int unitId);
        IDataResult<UnitDetailDto> GetUnitDetail(int unitId);
        IDataResult<List<UnitListDto>> GetAllUnits();




    }
}
