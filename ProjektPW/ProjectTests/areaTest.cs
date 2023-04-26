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
    public class FieldTest
    {
        ballArea field = new ballArea(100, 100, 2);

        [TestMethod]
        public void GetterTest()
        {
            Assert.AreEqual(100, field.Height);
            Assert.AreEqual(100, field.Width);
            Assert.AreEqual(2, field.Balls.Count);
        }

        [TestMethod]
        public void SetterTest()
        {
            field.Width = 200;
            field.Height = 200;

            Assert.AreEqual(200, field.Width);
            Assert.AreEqual(200, field.Height);

        }
    }
}