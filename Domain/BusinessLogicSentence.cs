using Castle.Windsor;
using Infraestructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
   public  class BusinessLogicSentence: IBusinessLogicSentence
    {

        private WindsorContainer container;
        private readonly IUtil util;

        public BusinessLogicSentence()
        {
            this.container = new WindsorContainer();
            container.Install(new Installer());
            this.util = this.container.Resolve<IUtil>();
        }

        public int executeSentece(string data, int[,,] array3D, int n, int m)
        {
            int sumAux = -1;
            string[] vecMetaDataAux = data.Split(new string[] { this.util.CharacterSplitLine }, StringSplitOptions.None);
            if (vecMetaDataAux[0].ToUpper().Equals(this.util.CharacterGetSentence))
            {
                sumAux = this.executeSenteceQuery(vecMetaDataAux, array3D, n, m);
            }
            else
            {
                this.executeSenteceUpdate(vecMetaDataAux, array3D, n, m);
            }
            return sumAux;
        }

        public int executeSenteceQuery(string[] vecMetaDataAux, int[,,] array3D, int n, int m)
        {
            int sumAux = 0;
            if (Convert.ToInt32(vecMetaDataAux[1]) - 1 >= 0 && Convert.ToInt32(vecMetaDataAux[1]) - 1 < n && Convert.ToInt32(vecMetaDataAux[2]) - 1 >= 0 && Convert.ToInt32(vecMetaDataAux[2]) - 1 < n && Convert.ToInt32(vecMetaDataAux[3]) - 1 >= 0 && Convert.ToInt32(vecMetaDataAux[3]) - 1 < n)
            {
                for (int i = Convert.ToInt32(vecMetaDataAux[1]) - 1; i <= Convert.ToInt32(vecMetaDataAux[4]) - 1; i++)
                {
                    for (int j = Convert.ToInt32(vecMetaDataAux[2]) - 1; j <= Convert.ToInt32(vecMetaDataAux[5]) - 1; j++)
                    {
                        for (int k = Convert.ToInt32(vecMetaDataAux[3]) - 1; k <= Convert.ToInt32(vecMetaDataAux[6]) - 1; k++)
                        {
                            sumAux = sumAux + array3D[i, j, k];
                        }
                    }
                }
            }

            return sumAux;
        }

        public void executeSenteceUpdate(string[] vecMetaDataAux, int[,,] array3D, int n, int m)
        {
            if (Convert.ToInt32(vecMetaDataAux[1]) - 1 >= 0 && Convert.ToInt32(vecMetaDataAux[1]) - 1 < n && Convert.ToInt32(vecMetaDataAux[2]) - 1 >= 0 && Convert.ToInt32(vecMetaDataAux[2]) - 1 < n && Convert.ToInt32(vecMetaDataAux[3]) - 1 >= 0 && Convert.ToInt32(vecMetaDataAux[3]) - 1 < n)
            {
                array3D[Convert.ToInt32(vecMetaDataAux[1]) - 1, Convert.ToInt32(vecMetaDataAux[2]) - 1, Convert.ToInt32(vecMetaDataAux[3]) - 1] = Convert.ToInt32(vecMetaDataAux[4]);
            }

        }
    }
}
