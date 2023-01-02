using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    public class Brojilo
    {
        private int ID;
        private string ImeKorisnika;
        private string PrezimeKorisnika;
        private string Ulica;
        private int Broj;
        private int PostanskiBroj;
        private string Grad;

        public Brojilo(int iD, string imeKorisnika, string prezimeKorisnika, string ulica, int broj, int postanskiBroj, string grad)
        {
            ID = iD;
            ImeKorisnika = imeKorisnika ?? throw new ArgumentNullException(nameof(imeKorisnika));
            PrezimeKorisnika = prezimeKorisnika ?? throw new ArgumentNullException(nameof(prezimeKorisnika));
            Ulica = ulica ?? throw new ArgumentNullException(nameof(ulica));
            Broj = broj;
            PostanskiBroj = postanskiBroj;
            Grad = grad ?? throw new ArgumentNullException(nameof(grad));
        }
    }
}
