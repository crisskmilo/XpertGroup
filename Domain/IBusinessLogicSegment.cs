using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public interface IBusinessLogicSegment
    {
        List<string> readAllData(string data);
    }
}
