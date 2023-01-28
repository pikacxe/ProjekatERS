using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using Replicator;

namespace ReplicatorTest
{
    [TestFixture]

    public class ReplicatorSenderTest
    {
        IReplicatorReceiver receiver=null;
        [SetUp]
        public void Setup()
        {
            Mock<IReplicatorReceiver> mock=new Mock<IReplicatorReceiver>();          
            receiver=mock.Object;

        }

        [Test]
        [TestCase(null)]

        public void ReplicatorSenderKonstruktorTestLosiParametri(IReplicatorReceiver recierver)
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                ReplicatorSender replicator=new ReplicatorSender(recierver);
            }
            );
        }

        [Test]
        public void ReplicatorSenderKonstruktorTestDobriParametri()
        {
            ReplicatorSender r=new ReplicatorSender(receiver);
            Assert.AreEqual(r.Recv, receiver);
        }
        [Test]
        [TestCase(1, 5)]
        [TestCase(5, 20)]
        [TestCase(7, 15.5)]
        [TestCase(2, 30.123)]

        public void GetDataTestDobriParametri(int id,double potrosnja)
        {
            Assert.DoesNotThrow(() =>
            { 
                ReplicatorSender sender =new ReplicatorSender(receiver);
                sender.GetData(id,potrosnja);
            }
            );
        }

        [Test]
        [TestCase(0, 100)]
        [TestCase(-10, 100.567)]
        [TestCase(5, -105)]
        [TestCase(4, -156.23)]


        public void GetDataTestLosiParametri(int id, double potrosnja)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                ReplicatorSender sender = new ReplicatorSender(receiver);
                sender.GetData(id, potrosnja);
            }
            );
        }



    }
}
