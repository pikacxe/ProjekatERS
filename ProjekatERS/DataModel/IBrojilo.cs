using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    public interface IBrojilo
    {
        int ID { get; set; }
        string ImeKorisnika { get; set; }
        string PrezimeKorisnika { get; set; }
        string Ulica { get; set; }
        int Broj { get; set; }
        int PostanskiBroj { get; set; }
        string Grad { get; set; }

    }
}
