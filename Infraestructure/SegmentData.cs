using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure
{
    public class SegmentData
    {
        private List<string> arraySum;

        private int start;

        private int end;


        public SegmentData()
        {
           arraySum = new List<string>();
           start=1;
           end =1;
        }


        public List<string> ArraySum
        {
            get { return arraySum; }
            set { arraySum = value; }
        }

        public int Start
        {
            get { return start; }
            set { start = value; }
        }

        public int End
        {
            get { return end; }
            set { end = value; }
        }

    }
}
