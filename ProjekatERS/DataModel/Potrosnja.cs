﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    public class Potrosnja
    {
        private int _IDB;
<<<<<<< HEAD
        private double _Potrosnjab;
=======
        private double _PotrosnjaB;
>>>>>>> fd87027ef539e05c03c988922ae62089a9c9260f
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

        public int IDB { get
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

        public Potrosnja(int iDB, double potrosnjaB, int mesec)
        {
            _IDB = iDB;
            _PotrosnjaB = potrosnjaB;
            _Mesec = mesec;
        }
        public Potrosnja()
        {
            _IDB = -1;
            _PotrosnjaB = 0;
            _Mesec = -1;
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
