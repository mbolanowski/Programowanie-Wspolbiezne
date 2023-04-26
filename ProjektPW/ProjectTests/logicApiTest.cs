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

namespace Testy
{
    [TestClass()]
    public class LogicApiTests
    {
        [TestMethod()]
        public void _LogicApiTest()
        {
            AbstractLogicApi api = AbstractLogicApi.API();
            api.StartUpdating(100, 100, 2);
            Assert.AreEqual(2, api.GetBalls().Count);
        }
    }
}