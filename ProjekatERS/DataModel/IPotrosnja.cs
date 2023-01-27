using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    public interface IPotrosnja
    {
        int IDB { get; set; }
        int Mesec { get; set; }
        double PotrosnjaB { get; set; }
    }
}
