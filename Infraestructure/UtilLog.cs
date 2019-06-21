using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;
using log4net.Config;
using System.Reflection;


namespace Infraestructure
{
    public class UtilLog
    {
        private static ILog log;

        public static ILog Default
        {
            get
            {
                if (log == null)
                {
                    XmlConfigurator.Configure();
                    log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
                    return log;
                }

                return log;
            }
        }
    }
}