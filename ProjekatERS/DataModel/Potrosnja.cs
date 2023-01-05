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
        private double _Potrosnjab;
        private int _Mesec;

        public Potrosnja(int iDB, double potrosnjab, int mesec)
        {
            _IDB = iDB;
            _Potrosnjab = potrosnjab;
            _Mesec = mesec;
        }

        public override string ToString()
        {
            return base.ToString();
        }


        public int IDB
        {
            get { return _IDB; }
            set { _IDB = value; }
        }


        public double PotrosnjaB
        {
            get
            {
                return _Potrosnjab;
            }
            set
            {
                _Potrosnjab = value;
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

    }
}
