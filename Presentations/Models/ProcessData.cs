using Presentations.WsXpertGroup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Presentations.WsXpertGroup;

namespace Presentations.Models
{
    public class ProcessData
    {
        public string getProcessDataSum(wsdata data)
        {
            String [] responseVec = new String [1];
            string response = "";
            using (WsXpertGroupClient client = new WsXpertGroupClient())
            {
                responseVec = client.SumData(data);
                for(int i = 0; i < responseVec.Length; i++)
                {
                    response = response + responseVec[i] + "\r\n";
                }
            }

            return response;
        }

       
    }
}