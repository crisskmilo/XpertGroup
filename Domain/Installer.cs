using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Installer : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<IBusinessLogicSegment>()
               .ImplementedBy<BusinessLogicSegment>().LifestyleTransient());

            container.Register(Component.For<IBusinessLogicSentence>()
               .ImplementedBy<BusinessLogicSentence>().LifestyleTransient());

            container.Install(new Infraestructure.Installer());

        }

      }
}
