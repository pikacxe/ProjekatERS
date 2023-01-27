using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using System.Data.SqlClient;
using DataModel;
using Reader;
using System.Data;

namespace ReaderTest
{
    [TestFixture]
    public class ReaderTest
    {
        IDbConnection conn = null;
        IPotrosnja potrosnja = null;
        IReader reader = null;
        
        
        [SetUp]
        public void Setup()
        {
            var moq1 = new Mock<IDbConnection>();
            conn = moq1.Object;

            var moq2 = new Mock<IPotrosnja>();
            moq2.Setup(x => x.IDB).Returns(12345);
            moq2.Setup(x => x.Mesec).Returns(12345);
            moq2.Setup(x => x.PotrosnjaB).Returns(12345);
            potrosnja = moq2.Object;


            reader = new Reader.Reader();
        }

        [Test]
        [TestCase(1)]
        [TestCase(17)]
        [TestCase(30)]
        public void ReadPotrosnjaBrojilaTestDobriParametri(int id)
        {
            Reader.Reader r = new Reader.Reader();
            Assert.IsInstanceOf<IEnumerable<Potrosnja>>(r.ReadPotrosnjaBrojila(id));
        }

        [Test]
        [TestCase(-1)]
        [TestCase(-15)]
        [TestCase(0)]
        public void ReadPotrosnjaBrojilaTestLosiParametri(int id)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Reader.Reader r = new Reader.Reader();
                r.ReadPotrosnjaBrojila(id);
            });
        }

        [Test]
        [TestCase(-7)]
        [TestCase(-17)]
        [TestCase(0)]
        public void ExistsByIdTestLosiParametri(int id)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                reader.ExistsById(id, conn);
            });
        }

        [Test]
        [TestCase(1,null)]
        [TestCase(14, null)]
        [TestCase(26, null)]
        public void ExistsByIdTestLosiParametriNull(int id,IDbConnection conn)
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                Reader.Reader r = new Reader.Reader();
                r.ExistsById(id, conn);
            });
        }

        [Test]
        [TestCase(null)]
        public void SavePotrosnjaTestLosiParametri(IPotrosnja potrosnja)
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                Reader.Reader r = new Reader.Reader();
                r.SavePotrosnja(potrosnja);
            });
        }

        [Test]
        public void SavePotrosnjaTestDobriParametri()
        {
            Reader.Reader r = new Reader.Reader();
            Assert.GreaterOrEqual(r.SavePotrosnja(potrosnja),0);
        }
    }
}
