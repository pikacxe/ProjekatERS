using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reports
{
    public interface IReports
    {
        IEnumerable<Potrosnja> PotrosnjaPoUlici(string ulica);
        IEnumerable<Potrosnja> PotrosnjaPoBrojilu(int idb);
    }
}
