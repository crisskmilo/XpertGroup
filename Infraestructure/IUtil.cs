using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure
{
    public interface IUtil
    {
        int[,,] InstanceArray(int dimensions);
        int MaxQuantityIterations { get; set; }
        int MaxLenghtArray { get; set; }
        int MaxLenghtOperations { get; set; }
        String CharacterSplitDocument { get; set; }
        String CharacterSplitLine { get; set; }
        String CharacterGetSentence { get; set; }
        String CharacterPutSentence { get; set; }
    }
}
