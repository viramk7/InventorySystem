using Autofac;
using InventorySystem.Data.Database;
using InventorySystem.Data.Repositories;
using InventorySystem.Services.User;

namespace InventorySystem.Services
{
    public partial class ServiceDependencyRegister
    {
        public static void Resolve(ContainerBuilder builder)
        {
            builder.RegisterGeneric(typeof(EfRepository<>)).As(typeof(IRepository<>)).InstancePerDependency();
            builder.RegisterType<InventorySystemDBEntities>().As<IDbContext>().InstancePerDependency();

            // builder.RegisterType<UserService>().As<IUserService>().InstancePerDependency();
            builder.RegisterType<UserServiceEF>().As<IUserService>().InstancePerDependency();
        }
    }
}
