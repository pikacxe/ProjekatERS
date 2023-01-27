using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;


namespace Reader
{
    public interface IReader
    {
        IEnumerable<Potrosnja> ReadPotrosnjaBrojila(int idp);
        int ExistsById(int id, IDbConnection conn);
        int SavePotrosnja(IPotrosnja potrosnja);
    }
}
