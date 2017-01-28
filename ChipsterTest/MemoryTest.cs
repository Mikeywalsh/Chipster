using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit;
using NUnit.Framework;
using Chipster;

namespace ChipsterTest
{
    [TestFixture]
    public class MemoryTest
    {
        [Test]
        public void ReadTest()
        {
            Memory m = new Memory(100);
            Assert.AreEqual(0, m.Read(50));
        }

        [Test]
        public void WriteByteTest()
        {
            Memory m = new Memory(100);
            m.Write(253, 67);
            Assert.AreEqual(253, m.Read(67));
        }

        [Test]
        public void WriteBytesTest()
        {
            Memory m = new Memory(100);

            byte[] data = new byte[2] { 45, 86 };

            m.Write(data, 14);
            Assert.AreEqual(45, m.Read(14));
            Assert.AreEqual(86, m.Read(15));
        }

        [Test]
        public void ClearTest()
        {
            Memory m = new Memory(100);
            m.Write(253, 67);
            Assert.AreEqual(253, m.Read(67));

            m.Clear();

            Assert.AreEqual(0, m.Read(67));
        }

        [Test]
        public void FailTest()
        {
            Assert.False(true);

        }
    }
}
