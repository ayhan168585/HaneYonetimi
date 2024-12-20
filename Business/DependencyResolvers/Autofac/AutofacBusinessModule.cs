using Autofac;
using Autofac.Extras.DynamicProxy;
using Business.Abstract;
using Business.Concrete;
using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            
            builder.RegisterType<CategoryManager>().As<ICategoryService>().SingleInstance();
            builder.RegisterType<EfCategoryDal>().As<ICategoryDal>().SingleInstance();
            builder.RegisterType<EfExpenseDal>().As<IExpenseDal>().SingleInstance();
            builder.RegisterType<ExpenseManager>().As<IExpenseService>().SingleInstance();
            builder.RegisterType<IncomeManager>().As<IIncomeService>().SingleInstance();
            builder.RegisterType<EfIncomeDal>().As<IIncomeDal>().SingleInstance();
            builder.RegisterType<MarketItemManager>().As<IMarketItemService>().SingleInstance();
            builder.RegisterType<EfMarketItemDal>().As<IMarketItemDal>().SingleInstance();          
            builder.RegisterType<EfRoleDal>().As<IRoleDal>().SingleInstance();          
            builder.RegisterType<RoleManager>().As<IRoleService>().SingleInstance();          
            builder.RegisterType<FamilyPersonManager>().As<IFamilyPersonService>().SingleInstance();          
            builder.RegisterType<EfFamilyPersonDal>().As<IFamilyPersonDal>().SingleInstance();
            builder.RegisterType<EfUnitDal>().As<IUnitDal>().SingleInstance();
            builder.RegisterType<UnitManager>().As<IUnitService>().SingleInstance();

            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();

        }
    }
}
