using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegates
{
    internal class PlayingField
    {
        public XY MinPoint { get; set; }
        public XY MaxPoint { get; set; }
        public PlayingField()
        {
            MinPoint = new XY(0,0);
            MaxPoint = new XY(50, 20);
        }
    }
}
