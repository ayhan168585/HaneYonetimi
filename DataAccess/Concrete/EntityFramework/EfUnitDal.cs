using Core.DataAccess.Concrete.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Concrete.Dtos.MarketItems;
using Entities.Concrete.Dtos.Roles;
using Entities.Concrete.Dtos.Units;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfUnitDal : EfEntityRepositoryBase<Unit, HaneYonetimiContext>, IUnitDal
    {
        public void AddUnit(UnitCreateDto unitCreateDto)
        {
            using (HaneYonetimiContext context=new HaneYonetimiContext())
            {
               
                  
                        var unit = new Unit
                        {
                            Name = unitCreateDto.Name
                        };

                        context.Units.Add(unit);
                        context.SaveChanges();
                    
                
            }
        }

        public bool DeleteUnit(int unitId)
        {
            using (HaneYonetimiContext context = new HaneYonetimiContext())
            {
                var unit = context.Units.Find(unitId);

                if (unit == null) return false;

                context.Units.Remove(unit);
                context.SaveChanges();
                return true;
            }
        }

       

        public List<UnitListDto> GetAllUnits()
        {
            using (HaneYonetimiContext context = new HaneYonetimiContext())
            {
                var units = context.Units
                .Select(r => new UnitListDto
                {
                   Id = r.Id,
                   Name = r.Name,
                
                })
                    .ToList();
                return units;

            }
        }

        public UnitDetailDto GetUnitDetail(int unitId)
        {
            using (HaneYonetimiContext context=new HaneYonetimiContext())
            {
                var unitDetails = context.Units
            .Include(u => u.MarketItems)
            .Where(u => u.Id == unitId)
            .Select(u => new UnitDetailDto
            {
                Id = u.Id,
                Name = u.Name,
                MarketItems = u.MarketItems.Select(mi => new MarketItemDto
                {
                    Id = mi.Id,
                    Name = mi.Name,
                    Price = mi.Price,
                    CategoryName=mi.Category.Name
                }).ToList()
            })
            .SingleOrDefault();

                return unitDetails;
            }
        }

        public void UpdateUnit(UnitUpdateDto unitUpdateDto)
        {
            using (HaneYonetimiContext context=new HaneYonetimiContext())
            {
                var unit = context.Units.SingleOrDefault(u => u.Id == unitUpdateDto.Id);

                if (unit == null)
                {
                    throw new Exception("Birim bulunamadı.");
                }

                unit.Name = unitUpdateDto.Name;
                context.SaveChanges();

            }
        }
    }
}
