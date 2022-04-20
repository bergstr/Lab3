using System;
using System.Collections.Generic;
using System.Text;

namespace Lab3
{
    interface IScore
    {
        abstract void PrintScore(LeafBoard leafBoard);
        abstract void PrintScore(CompositeBoard compositeBoard);
        abstract void PrintScore(ComponentBoard componentBoard);
    }
}
