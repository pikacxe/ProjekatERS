using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    public class Potrosnja
    {
        private int _IDB;
        private double _PotrosnjaB;
        private int _Mesec;

        public int IDB { get 
            {
                return _IDB;    
            }
            set 
            {
                _IDB= value;
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
                _Mesec = value;
            }
        }


        public Potrosnja(int iDB, double potrosnjaB, int mesec)
        {
            _IDB = iDB;
            _PotrosnjaB = potrosnjaB;
            _Mesec = mesec;
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
