using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    public class Brojilo : IBrojilo
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
                if (value < 0)
                {
                    throw new ArgumentException("ID ne sme biti manji od nule!");
                }
                _ID = value;
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
                if (value == "")
                {
                    throw new ArgumentException("Ime ne sme biti prazno!");
                }
                if (value == null)
                {
                    throw new ArgumentNullException("Ime ne sme biti null");
                }

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
                if (value == "")
                {
                    throw new ArgumentException("Prezime ne sme biti prazno!");
                }
                if (value == null)
                {
                    throw new ArgumentNullException("Prezime ne sme biti null");
                }
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
                if (value == "")
                {
                    throw new ArgumentException("Ulica ne sme biti prazna!");
                }
                if (value == null)
                {
                    throw new ArgumentNullException("Ulica ne sme biti null");
                }
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
                if (value < 0)
                {
                    throw new ArgumentException("Broj ne sme biti manji od nule!");
                }
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
                if (value < 10_000 || value > 39_000)
                {
                    throw new ArgumentException("Postanski broj van opsega!");
                }
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
            if(iD < 0)
            {
                throw new ArgumentException("ID ne sme biti manji od nule!");
            }
            _ID = iD;
            if(imeKorisnika == "")
            {
                throw new ArgumentException("Ime ne sme biti prazno!");
            }
            if(imeKorisnika == null)
            {
                throw new ArgumentNullException("Ime ne sme biti null");
            }
            _ImeKorisnika = imeKorisnika;
            if (prezimeKorisnika == "")
            {
                throw new ArgumentException("Prezime ne sme biti prazno!");
            }
            if (prezimeKorisnika == null)
            {
                throw new ArgumentNullException("Prezime ne sme biti null");
            }
            _PrezimeKorisnika = prezimeKorisnika;
            if (ulica == "")
            {
                throw new ArgumentException("Ulica ne sme biti prazna!");
            }
            if (ulica == null)
            {
                throw new ArgumentNullException("Ulica ne sme biti null");
            }
            _Ulica = ulica;
            if(broj < 0)
            {
                throw new ArgumentException("Broj mora biti veci od nule!");
            }
            _Broj = broj;
            if(postanskiBroj < 10_000 || postanskiBroj > 39_000)
            {
                throw new ArgumentOutOfRangeException("Postanski broj van opsega!");
            }
            _PostanskiBroj = postanskiBroj;
            if (grad == "")
            {
                throw new ArgumentException("Grad ne sme biti prazan!");
            }
            if (grad == null)
            {
                throw new ArgumentNullException("Grad ne sme biti null");
            }
            _Grad = grad;
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
