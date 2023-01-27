using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using DataModel;
using Replicator;
using System.Threading;
using Reader;

namespace ReplicatorTest
{
    [TestFixture]
    class ReplicatorReceiverTest
    {

        private IPotrosnja potrosnja1 = null;
        private IReplicatorReceiver receiver = null;
        private void ThreadTest() { }
        [SetUp]
        public void Setup()
        {
            Mock<IPotrosnja> mock = new Mock<IPotrosnja>();
            mock.Setup(x => x.IDB).Returns(1);
            mock.Setup(x => x.Mesec).Returns(10);
            mock.Setup(x => x.PotrosnjaB).Returns(100.12);
            potrosnja1 = mock.Object;

            Mock<IReplicatorReceiver> mock1 = new Mock<IReplicatorReceiver>();
            mock1.Setup(x => x.Readers).Returns(new List<IReader>());
            mock1.Setup(x => x.Potrosnje).Returns(new List<IPotrosnja>());
            mock1.Setup(x => x.GetPerioda()).Returns(1);
            mock1.Setup(x => x.Thread).Returns(new Thread(ThreadTest));
            receiver = mock1.Object;
            receiver.Thread.Start();
        }


        [Test]
        [TestCase(10, 5)]
        [TestCase(20, 7)]


        public void ReplicatorReceiverKonsturktorDobriParametri(int numOfReaders, int second)
        {
            ReplicatorReceiver r = new ReplicatorReceiver(numOfReaders, second);
            Assert.AreEqual(numOfReaders, r.Readers.Count);
            Assert.AreEqual(second, r.GetPerioda());
        }

        [Test]
        [TestCase(1, 5)]
        [TestCase(12, 1)]
        [TestCase(1, 1)]

        public void ReplicatorReceiverKonsturktorGranicniParametri(int numOfReaders, int second)
        {
            ReplicatorReceiver r = new ReplicatorReceiver(numOfReaders, second);
            Assert.AreEqual(numOfReaders, r.Readers.Count);
            Assert.AreEqual(second, r.GetPerioda());
        }

        [Test]
        [TestCase(0, 5)]
        [TestCase(4, -2)]
        [TestCase(0, -10)]

        public void ReplicatorRecieverKostruktorLosiParametri(int numOFReaders, int second)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                ReplicatorReceiver r = new ReplicatorReceiver(numOFReaders, second);
            });
        }




        [Test]
        [TestCase(null)]

        public void GetPotrosnjaTest(Potrosnja potrosnja)
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                ReplicatorReceiver receiver = new ReplicatorReceiver();
                receiver.AddPotrosnja(potrosnja);
            });
        }
        [Test]
        [TestCase(1)]
        [TestCase(5)]
        [TestCase(100)]
        public void SetPeriodaTestDobriParametri(int perioda)
        {
            ReplicatorReceiver r = new ReplicatorReceiver();
            r.SetPerioda(perioda);
            Assert.AreEqual(perioda, r.GetPerioda());
        }
        [Test]
        [TestCase(-1)]
        [TestCase(-10)]
        [TestCase(-100)]
        public void SetPeriodaTestLosiParametri(int perioda)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                ReplicatorReceiver r = new ReplicatorReceiver();
                r.SetPerioda(perioda);
            }
            );
        }

        [Test]
        public void StopThreadTest()
        {
            receiver.StopThread();
            Assert.AreEqual(false, receiver.Thread.IsAlive);
            Assert.AreEqual(ThreadState.Stopped, receiver.Thread.ThreadState);
        }
    }
}
