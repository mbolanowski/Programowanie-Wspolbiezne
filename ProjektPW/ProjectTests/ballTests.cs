using Microsoft.VisualStudio.TestTools.UnitTesting;
using Dane;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace Testy
{
    [TestClass()]
    public class ballTests
    {
        ballData ball = new ballData(1, 1, 1);

        [TestMethod]
        public void GetterTest()
        {
            Assert.AreEqual(1, ball.X);
            Assert.AreEqual(1, ball.Y);
            Assert.AreEqual(15, ball.Radius);
            Assert.AreEqual(1, ball.Weight);
        }

        [TestMethod]
        public void SetterTest()
        {
            ball.setSpeed(2, 2);
            ball.X = 2;
            ball.Y = 2;
            ball.Radius = 2;

            Assert.AreEqual(2, ball.XSpeed);
            Assert.AreEqual(2, ball.YSpeed);
            Assert.AreEqual(2, ball.X);
            Assert.AreEqual(2, ball.Y);
            Assert.AreEqual(2, ball.Radius);
        }
    }
}