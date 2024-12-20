using Business.Constants;
using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class CategoryValidator:AbstractValidator<Category>    
    {
        public CategoryValidator()
        {
            RuleFor(p => p.Name).NotEmpty().WithMessage(Messages.CategoryNameNotEmpty);
            RuleFor(p => p.Name).MinimumLength(2).WithMessage(Messages.CategoryNameMinLength);
            RuleFor(x => x)
           .Must(NotDuringMaintenanceHours)
           .WithMessage("Saat 23:00-24:00 arası bakım zamanıdır. Şu anda işlem yapamazsınız."); 

        }

        private bool NotDuringMaintenanceHours(object _)
        {
            var currentTime = DateTime.Now.TimeOfDay;

            // Bakım saati kontrolü (23:00 - 24:00 arası)
            var startMaintenance = new TimeSpan(23, 0, 0);
            var endMaintenance = new TimeSpan(23, 59, 59);

            return !(currentTime >= startMaintenance && currentTime <= endMaintenance);
        }
    }
}
