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

        public Potrosnja(int iDB, double potrosnjab, int mesec)
        {
            _IDB = iDB;
            _PotrosnjaB = potrosnjab;
            _Mesec = mesec;
        }

        public Potrosnja()
        {
            _IDB = -1;
            _PotrosnjaB = 0;
            _Mesec = -1;
        }
        
        public int IDB
        {
            get
            {
                return _IDB;
            }
            set 
            { 
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

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
