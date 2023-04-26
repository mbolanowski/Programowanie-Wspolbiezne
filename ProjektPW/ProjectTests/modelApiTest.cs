using Microsoft.VisualStudio.TestTools.UnitTesting;
using Dane;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;
using Logika;
using Model;
using System.Collections.ObjectModel;

namespace Testy
{
    [TestClass()]
    public class modelApiTest
    {
        [TestMethod]
        public void _ModelApiTest()
        {
            AbstractModelApi modelApi = AbstractModelApi.API();
            modelApi.StartUpdating(2);
            Assert.AreEqual(2, modelApi.GetBalls().Count);
        }
        [TestMethod]
        public void _ModelBallTest()
        {
            Dane.ballData ball = new Dane.ballData(1, 1);
            Logika.BallLogic ballLogic = new Logika.BallLogic(ball);

            Assert.AreEqual(ball.X, ballLogic.X);
            Assert.AreEqual(ball.Y, ballLogic.Y);
            Assert.AreEqual(ball.Radius, ballLogic.Radius);
        }
    }
}