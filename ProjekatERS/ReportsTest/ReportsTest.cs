using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataModel;
using Moq;
using NUnit.Framework;
using Reports;

namespace ReportsTest
{
    [TestFixture]
    public class ReportsTest
    {


        [Test]
        [TestCase("")]
        [TestCase("   ")]
        [TestCase("\t\t\t")]
        public void PotrosnjaPoUliciTestLosiParametri(string ulica)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Report r = new Report();
                r.PotrosnjaPoUlici(ulica);
            });
        }
        [Test]
        [TestCase(null)]
        public void PotrosnjaPoUliciTestLosiParametriNull(string ulica)
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                Report r = new Report();
                r.PotrosnjaPoUlici(ulica);
            });
        }

        [Test]
        [TestCase("Kisacka")]
        [TestCase("Danila Kisa")]
        [TestCase("Niska")]
        public void PotrosnjaPoUliciTestDobriParametri(string ulica)
        {
            Report r = new Report();
            Assert.IsInstanceOf<IEnumerable<Potrosnja>>(r.PotrosnjaPoUlici(ulica));
        }

        [Test]
        [TestCase(10)]
        [TestCase(123)]
        [TestCase(12345)]
        public void PotrosnjaPoBrojiluDobriParametri(int idb)
        {
            Report r = new Report();
            Assert.IsInstanceOf<IEnumerable<Potrosnja>>(r.PotrosnjaPoBrojilu(idb));
        }
        [Test]
        [TestCase(1)]
        public void PotrosnjaPoBrojiluGranicniParametri(int idb)
        {
            Report r = new Report();
            Assert.IsInstanceOf<IEnumerable<Potrosnja>>(r.PotrosnjaPoBrojilu(idb));
        }
        [Test]
        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(-100)]
        public void PotrosnjaPoBrojiluLosiParametri(int idb)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Report r = new Report();
                r.PotrosnjaPoBrojilu(idb);
            });
        }
    }
}
