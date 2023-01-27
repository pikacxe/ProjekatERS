using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    public class Potrosnja : IPotrosnja
    {
        private int _IDB;
        private double _PotrosnjaB;
        private int _Mesec;

        public Potrosnja(int iDB, double potrosnjaB, int mesec)
        {
            if(iDB < 0)
            {
                throw new ArgumentException("ID brojila ne sme biti manji od nule!");
            }
            _IDB = iDB;
            if (potrosnjaB < 0)
            {
                throw new ArgumentException("Potrosnja ne sme biti manji od nule!");
            }
            _PotrosnjaB = potrosnjaB;
            if (mesec <= 0 || mesec > 12)
            {
                throw new ArgumentOutOfRangeException("Mesec mora biti u opsegu 1-12!");
            }
            _Mesec = mesec;
        }

        public Potrosnja()
        {
            _IDB = 0;
            _PotrosnjaB = 0;
            _Mesec = 1;
        }
        
        public int IDB
        {
            get
            {
                return _IDB;
            }
            set 
            {
                if (value < 0)
                {
                    throw new ArgumentException("ID brojila ne sme biti manji od nule!");
                }
                _IDB = value;
            }
        }


        public double PotrosnjaB
        {
            get
            {
                return _PotrosnjaB;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Potrosnja ne sme biti manji od nule!");
                }
                _PotrosnjaB = value;
            }
        }

        public int Mesec
        {
            get
            {
                return _Mesec;
            }
            set
            {
                if (value <= 0 && value > 12)
                {
                    throw new ArgumentOutOfRangeException("Mesec mora biti u opsegu 1-12!");
                }
                _Mesec = value;
            }
        }

        public override string ToString()
        {
            return string.Format("{0,6}\t{1,10}\t{2,6}", _IDB, _PotrosnjaB, _Mesec);
        }

        public static string GetFormattedHeader()
        {
            return string.Format("{0,6}\t{1,10}\t{2,6}", "IDB", "POTROSNJA", "MESEC");
        }
    }
}
