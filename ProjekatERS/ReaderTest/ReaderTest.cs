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

namespace ReaderTest
{
    [TestFixture]
    public class ReaderTest
    {
        SqlConnection conn = null;
        Potrosnja potrosnja = null;
        Reader.Reader reader1 = null;
        Reader.Reader reader2 = null;
        Reader.Reader reader3 = null;
        [SetUp]
        public void Setup()
        {
            potrosnja = new Potrosnja();
            var moq = new Mock<SqlConnection>();
            conn = moq.Object;
            var moq1 = new Mock<Potrosnja>();
            moq1.Setup(x => x.IDB).Returns(123);
            moq1.Setup(x => x.Mesec).Returns(1);
            moq1.Setup(x => x.PotrosnjaB).Returns(100.23);
            potrosnja = moq1.Object;
            reader1 = new Reader.Reader();
            reader2 = new Reader.Reader();
            reader3 = new Reader.Reader();
        }

        [Test]
        public void ReadPotrosnjaBrojilaTest()
        {

        }

    }
}
