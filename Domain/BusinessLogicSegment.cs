using Castle.Windsor;
using Infraestructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class BusinessLogicSegment : IBusinessLogicSegment
    {

        private WindsorContainer container;
        private readonly IUtil util;
        private readonly IBusinessLogicSentence blSentence;

        public BusinessLogicSegment()
        {

            this.container = new WindsorContainer();
            container.Install(new Installer());
            this.util = this.container.Resolve<IUtil>();
            this.blSentence = this.container.Resolve<IBusinessLogicSentence>();
        }

        public List<string> readAllData(string data)
        {                   
            SegmentData segDataAux = new SegmentData();
            try
            {
                string[] vecAux = data.Split(new string[] { this.util.CharacterSplitDocument }, StringSplitOptions.None);
                if (Convert.ToInt32(vecAux[0]) > 0 && Convert.ToInt32(vecAux[0]) <= this.util.MaxQuantityIterations)
                {

                    for (int i = 0; i < Convert.ToInt32(vecAux[0]); i++)
                    {
                        segDataAux = getSegmentData(vecAux, segDataAux);
                        segDataAux.End = segDataAux.End + 1;
                        segDataAux.Start = segDataAux.End;
                    }

                }
            }catch (Exception exception)
            {
                UtilLog.Default.Error("Error", exception);
            }
            return segDataAux.ArraySum;
        }


        public SegmentData getSegmentData(string[] data, SegmentData segDataAux)
        {

            string[] vecMetaDataAux = data[segDataAux.Start].Split(new string[] { this.util.CharacterSplitLine }, StringSplitOptions.None);

            if (Convert.ToInt32(vecMetaDataAux[0]) > 0 && Convert.ToInt32(vecMetaDataAux[0]) <= this.util.MaxLenghtArray)
            {
                if (Convert.ToInt32(vecMetaDataAux[1]) > 0 && Convert.ToInt32(vecMetaDataAux[1]) <= this.util.MaxLenghtOperations)
                {

                    int[,,] array3D = util.InstanceArray(Convert.ToInt32(vecMetaDataAux[0]));

                    segDataAux.End = segDataAux.End + Convert.ToInt32(vecMetaDataAux[1]);

                    for (int i = segDataAux.Start + 1; i <= segDataAux.End; i++)
                    {
                        int numAux = blSentence.executeSentece(data[i], array3D, Convert.ToInt32(vecMetaDataAux[0]), Convert.ToInt32(vecMetaDataAux[1]));
                        if (numAux > -1)
                        {
                            segDataAux.ArraySum.Add(Convert.ToString(numAux));
                        }
                    }
                }
            }

            return segDataAux;
        }

        

    }
}
