using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Castle.Windsor;
using Domain;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Test
{
    [TestClass]
    public class BusinessLogicSegmentTest
    {
        private WindsorContainer container;
        private readonly IBusinessLogicSegment blLogic;

        public struct wsdata
        {
            public string data { get; set; }
        }



        public BusinessLogicSegmentTest()
        {
            this.container = new WindsorContainer();
            container.Install(new Installer());

            this.blLogic = this.container.Resolve<IBusinessLogicSegment>();
        }

        [TestMethod]
        public void TestDataEmpty()
        {
            List<string> responseService = blLogic.readAllData(JsonConvert.SerializeObject(new wsdata()));
            Assert.AreEqual(responseService.Count, 0);
        }

        [TestMethod]
        public void TestDataNull()
        {
            List<string> responseService = blLogic.readAllData(null);
            Assert.AreEqual(responseService.Count, 0);
        }

        [TestMethod]
        public void TestDataOk()
        {
            wsdata wsdata = new wsdata();

            wsdata.data = "2\r\n4 5\r\nUPDATE 2 2 2 4\r\nQUERY 1 1 1 3 3 3\r\nUPDATE 1 1 1 23\r\nQUERY 2 2 2 4 4 4\r\nQUERY 1 1 1 3 3 3\r\n2 4\r\nUPDATE 2 2 2 1\r\nQUERY 1 1 1 1 1 1\r\nQUERY 1 1 1 2 2 2\r\nQUERY 2 2 2 2 2 2";
            List<string> listResponse = blLogic.readAllData(wsdata.data);

            string responseService = "{\"SumDataResult\":" + JsonConvert.SerializeObject(listResponse) + "}";

            string responseExpective = "{\"SumDataResult\":[\"4\",\"4\",\"27\",\"0\",\"1\",\"1\"]}";

            Assert.AreEqual(responseService, responseExpective);

        }


        [TestMethod]
        public void TestDataError()
        {
            wsdata wsdata = new wsdata();

            wsdata.data = "4 5\r\nUPDATE 2 2 2 4\r\nQUERY 1 1 1 3 3 3\r\nUPDATE 1 1 1 23\r\nQUERY 2 2 2 4 4 4\r\nQUERY 1 1 1 3 3 3\r\n2 4\r\nUPDATE 2 2 2 1\r\nQUERY 1 1 1 1 1 1\r\nQUERY 1 1 1 2 2 2\r\nQUERY 2 2 2 2 2 2";
            List<string> listResponse = blLogic.readAllData(wsdata.data);

            string responseService = "{\"SumDataResult\":" + JsonConvert.SerializeObject(listResponse) + "}";

            string responseExpective = "{\"SumDataResult\":[\"4\",\"4\",\"27\",\"0\",\"1\",\"1\"]}";

            Assert.AreEqual(responseService, responseExpective);

        }
    }
}
