using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Xml;

namespace Infraestructure
{
   public class Util : IUtil
    {
      
        public int maxQuantityIterations;
        public int maxLenghtArray;
        public int maxLenghtOperations;
        public String characterSplitDocument;
        public String characterSplitLine;
        public String characterGetSentence;
        public String characterPutSentence;
        private string pathXML = "";

        public Util()
        {
           this.readConfigXml();
        }

        public int MaxQuantityIterations
        {
            get { return maxQuantityIterations; }
            set { maxQuantityIterations = value; }
        }

        public int MaxLenghtArray
        {
            get { return maxLenghtArray; }
            set { maxLenghtArray = value; }
        }

        public int MaxLenghtOperations
        {
            get { return maxLenghtOperations; }
            set { maxLenghtOperations = value; }
        }

        public String CharacterSplitDocument
        {
            get { return characterSplitDocument; }
            set { characterSplitDocument = value; }
        }

        public String CharacterSplitLine
        {
            get { return characterSplitLine; }
            set { characterSplitLine = value; }
        }

        public String CharacterGetSentence
        {
            get { return characterGetSentence; }
            set { characterGetSentence = value; }
        }

        public String CharacterPutSentence
        {
            get { return characterPutSentence; }
            set { characterPutSentence = value; }
        }
        
        public int[,,] InstanceArray(int dimensions)
        {
            if (dimensions == 0) return null;
            int[,,] array3D = new int[Convert.ToInt32(dimensions), Convert.ToInt32(dimensions), Convert.ToInt32(dimensions)];
            return array3D;
        }


        private void readConfigXml()
        {
            XmlDocument xDoc = new XmlDocument();
            try
            {
                this.pathXML = HttpContext.Current.Server.MapPath("") + @"\InitConfig.xml";
            }catch(Exception e)
            {
                this.pathXML = Path.GetDirectoryName(System.AppDomain.CurrentDomain.BaseDirectory) + @"\InitConfig.xml";
            }
            xDoc.Load(pathXML);
            XmlNodeList initParams = xDoc.GetElementsByTagName("initParams");            
            foreach (XmlElement node in initParams)
            {
                int i = 0;
                MaxQuantityIterations = Convert.ToInt32(node.GetElementsByTagName("maxQuantityIterations")[i].InnerText);
                MaxLenghtArray = Convert.ToInt32(node.GetElementsByTagName("maxLenghtArray")[i].InnerText);
                MaxLenghtOperations = Convert.ToInt32(node.GetElementsByTagName("maxLenghtOperations")[i].InnerText);
                CharacterSplitDocument = node.GetElementsByTagName("characterSplitDocument")[i].InnerText;
                CharacterSplitDocument = CharacterSplitDocument.Replace("\\r", "\r").Replace("\\n", "\n").Replace("\\t", "\t");
                CharacterSplitLine = node.GetElementsByTagName("characterSplitLine")[i].InnerText;
                CharacterSplitLine = CharacterSplitLine.Replace("\\r", "\r").Replace("\\n", "\n").Replace("\\t", "\t");
                CharacterGetSentence = node.GetElementsByTagName("characterGetSentence")[i].InnerText;
                CharacterPutSentence = node.GetElementsByTagName("characterPutSentence")[i].InnerText;
            }
        }

    }
}
