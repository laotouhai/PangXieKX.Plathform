using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using Autofac;
using Autofac.Configuration;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using PangXieKX.Plathform.Model;
using PangXieKX.Plathform.Business;
using PangXieKX.Plathform.IBusiness;
using PangXieKX.Plathform.DataAccess;
using PangXieKX.Plathform.IDataAccess;
using PangXieKX.Plathform.DB;
using PangXieKX.Plathform.DataAccess.DBUtils;
using PangXieKX.Plathform.DB.SqlDBHelper;

namespace PangXieKX.Plathform.Configuration
{
    public static class Container
    {
        /// <summary>
        /// 业务层和数据访问层注入
        /// </summary>
        /// <returns></returns>
        public static ContainerBuilder RegisterService()
        {
            var builder = new ContainerBuilder();
            var baseType = typeof(IDependency);
            var assemblys = AppDomain.CurrentDomain.GetAssemblies().ToList();
            var AllServices = assemblys
                .SelectMany(s => s.GetTypes())
                .Where(p => baseType.IsAssignableFrom(p) && p != baseType);

            builder.RegisterAssemblyTypes(assemblys.ToArray())
                   .Where(t => baseType.IsAssignableFrom(t) && t != baseType)
                   .AsImplementedInterfaces().InstancePerLifetimeScope();

            builder.RegisterType<MemberMenuBLL>().As<IMemberMenuBLL>().InstancePerLifetimeScope();
            builder.RegisterType<MemberMenuDAL>().As<IMemberMenuDAL>().InstancePerLifetimeScope();

            return builder;
        }

        /// <summary>
        /// 数据库连接池注入
        /// </summary>
        /// <returns></returns>
        public static IContainer RegisterDataBase()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<Database>().As<IDatabase>().WithParameter("connKey", "DefaultConnection").InstancePerLifetimeScope();
            builder.RegisterType<DBSessionBase>().As<IDBSession>().InstancePerLifetimeScope();
            builder.RegisterType<DBAdaptor>().As<IDBHelper>().WithParameter("connKey", "DefaultConnection").SingleInstance();
            SqlHelper.IC = builder.Build();
            return SqlHelper.IC;
        }
    }
}
