using Core.DataAccess.Abstract;
using Entities.Concrete;
using Entities.Concrete.Dtos.Units;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IUnitDal:IEntityRepository<Unit>
    {
        public void AddUnit(UnitCreateDto unitCreateDto);
        public void UpdateUnit(UnitUpdateDto unitUpdateDto);
        public bool DeleteUnit(int unitId);
        public UnitDetailDto GetUnitDetail(int unitId);
        public List<UnitListDto> GetAllUnits();
    }
}
