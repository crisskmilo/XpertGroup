using Castle.Windsor;
using Domain;
using Infraestructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Web.Http;
using System.Web.Http.Cors;

namespace WsService
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "WsXpertGroup" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione WsXpertGroup.svc o WsXpertGroup.svc.cs en el Explorador de soluciones e inicie la depuración.
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class WsXpertGroup : IWsXpertGroup
    {
        private List<string> dataOpSum;
        private WindsorContainer container;
        private readonly IBusinessLogicSegment businessLogic;


        public WsXpertGroup()
        {
            dataOpSum = new List<string>();
            this.container = new WindsorContainer();
            container.Install(new Installer());
            this.businessLogic = this.container.Resolve<IBusinessLogicSegment>();
        }

        [AcceptVerbs("POST")]
        public List<string> SumData(wsdata wsdata)
        {
            try
            {
                if (wsdata !=null && wsdata.data !=null) {
                    dataOpSum = this.businessLogic.readAllData(wsdata.data);
                }
                else
                {
                    UtilLog.Default.Error("Error, data not found");
                    dataOpSum.Add("Error, data not found");
                }       
            }
            catch (Exception exception)
            {
                UtilLog.Default.Error("Error", exception);
                dataOpSum.Add("Error, data not found");
            }

            return dataOpSum;
        }
        

    }
}
