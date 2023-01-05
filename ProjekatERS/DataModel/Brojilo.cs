using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    public class Brojilo
    {
        private int _ID;
        private string _ImeKorisnika;
        private string _PrezimeKorisnika;
        private string _Ulica;
        private int _Broj;
        private int _PostanskiBroj;
        private string _Grad;

        public int ID
        {
            get
            {
                return _ID;
            }
            set
            {
                _ID= value;
            }
        }

        public string ImeKorisnika
        {
            get
            {
                return _ImeKorisnika;
            }
            set
            {
                _ImeKorisnika = value;
            }
        }

        public string PrezimeKorisnika
        {
            get
            {
                return _PrezimeKorisnika;
            }
            set
            {
                _PrezimeKorisnika = value;
            }
        }

        public string Ulica
        {
            get
            {
                return _Ulica;
            }
            set
            {
                _Ulica = value;
            }
        }

        public int Broj
        {
            get
            {
                return _Broj;
            }
            set
            {
                _Broj = value;
            }
        }
        public int PostanskiBroj
        {
            get
            {
                return _PostanskiBroj;
            }
            set
            {
                _PostanskiBroj = value;
            }
        }
        public string Grad
        {
            get
            {
                return _Grad;
            }
            set
            {
                _Grad = value;
            }
        }
        public Brojilo(int iD, string imeKorisnika, string prezimeKorisnika, string ulica, int broj, int postanskiBroj, string grad)
        {
            _ID = iD;
            _ImeKorisnika = imeKorisnika ?? throw new ArgumentNullException(nameof(imeKorisnika));
            _PrezimeKorisnika = prezimeKorisnika ?? throw new ArgumentNullException(nameof(prezimeKorisnika));
            _Ulica = ulica ?? throw new ArgumentNullException(nameof(ulica));
            _Broj = broj;
            _PostanskiBroj = postanskiBroj;
            _Grad = grad ?? throw new ArgumentNullException(nameof(grad));
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }



}
