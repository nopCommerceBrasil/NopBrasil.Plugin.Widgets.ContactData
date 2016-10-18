using Autofac;
using Nop.Core.Configuration;
using Nop.Core.Infrastructure;
using Nop.Core.Infrastructure.DependencyManagement;
using NopBrasil.Plugin.Widgets.ContactData.Controllers;
using NopBrasil.Plugin.Widgets.ContactData.Service;

namespace NopBrasil.Plugin.Widgets.ContactData.Infrastructure
{
    public class DependencyRegistrar : IDependencyRegistrar
    {
        public virtual void Register(ContainerBuilder builder, ITypeFinder typeFinder, NopConfig nopConfig)
        {
            builder.RegisterType<WidgetsContactDataController>().AsSelf();
            builder.RegisterType<ContactDataService>().As<IContactDataService>().InstancePerDependency();
        }

        public int Order
        {
            get { return 2; }
        }
    }
}
