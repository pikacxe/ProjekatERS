using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using Replicator;
using Writer;

namespace WriterTest
{
    [TestFixture]
    public class WriterTest
    {
        IReplicatorSender sender = null;
        

        [SetUp]
        public void SetUp()
        {
            var moq1=new Mock<IReplicatorSender>();
            sender=moq1.Object;

        }

        [Test]
        public void WriterConstructorTestDobriParametri()
        {
            IWriter w=new Writer.Writer(sender);
            Assert.AreEqual(sender,w.Sender);
        }

        [Test]
        [TestCase(null)]
        public void WriterConstructorTestNull(IReplicatorSender s)
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                IWriter w = new Writer.Writer(s);
            });
        }

        [Test]
        public void UkljuciTest() {
            Writer.Writer w = new Writer.Writer(sender);
            w.Ukljuci();
            Assert.AreEqual(true, w.Stanje);
        }

        [Test]
        public void IskljuciTest()
        {
            Writer.Writer w = new Writer.Writer(sender);
            w.Iskljuci();
            Assert.AreEqual(false, w.Stanje);
        }

        [Test]
        [TestCase(1, 5)]
        [TestCase(5, 20)]
        [TestCase(7, 15.5)]
        [TestCase(2, 30.123)]
        public void AcceptPotrosnjaTestDobriParametri(int id, double potrosnja)
        {
            Assert.DoesNotThrow(() =>
            {
                Writer.Writer w = new Writer.Writer(sender);
                w.Ukljuci();
                w.AcceptPotrosnja(id, potrosnja);
            });
        }

        [Test]
        [TestCase(0, 100)]
        [TestCase(-10, 100.567)]
        [TestCase(5, -105)]
        [TestCase(4, -156.23)]
        public void AcceptPotrosnjaTestLosiParametri(int id, double potrosnja)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Writer.Writer w = new Writer.Writer(sender);
                w.Ukljuci();
                w.AcceptPotrosnja(id, potrosnja);
            });
        }

        [Test]
        [TestCase(1, 5)]
        [TestCase(5, 20)]
        [TestCase(7, 15.5)]
        [TestCase(2, 30.123)]
        public void AcceptPotrosnjaTestLoseStanje(int id, double potrosnja)
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                Writer.Writer w = new Writer.Writer(sender);
                w.AcceptPotrosnja(id, potrosnja);
            });
        }

    }
}
