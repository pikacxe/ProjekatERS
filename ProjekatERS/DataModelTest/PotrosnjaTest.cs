using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using DataModel;

namespace DataModelTest
{
    [TestFixture]
    class PotrosnjaTest
    { 
        [Test]
        [TestCase(1,200.2,3)]
        [TestCase(2,300,5)]
        [TestCase(3,100,6)]
        public void PotrosnjaKonstruktorDobriParametri(int id, double potrosnja, int mesec)
        {
            Potrosnja p = new Potrosnja(id, potrosnja, mesec);
            Assert.AreEqual(id, p.IDB);
            Assert.AreEqual(potrosnja, p.PotrosnjaB);
            Assert.AreEqual(mesec, p.Mesec);
        }
        
        [Test]
        [TestCase(1,1,12)]
        [TestCase(2_000_000_000,2_000_000_000,1)]
        public void PotrosnjaKonsturktorGranicniParametri(int id, double potrosnja, int mesec)
        {
            Potrosnja p = new Potrosnja(id, potrosnja, mesec);
            Assert.AreEqual(id, p.IDB);
            Assert.AreEqual(potrosnja, p.PotrosnjaB);
            Assert.AreEqual(mesec, p.Mesec);
        }

        [Test]
        [TestCase(-1,200.2,3)]  // Los IDB
        [TestCase(123,-200,4)]  // Losa potrosnja
        [TestCase(12,-1,5)]     // Losa potrosnja
        [TestCase(1,100,14)]    // Los mesec
        [TestCase(1,100,-15)]   // Los mesec
        public void PotrosnjaKonstruktorLosiParametri(int id, double potrosnja, int mesec)
        {
            Assert.Throws<ArgumentException>(() => {
                Potrosnja p = new Potrosnja(id, potrosnja, mesec);
            }
            );
            
        }
    }
}
