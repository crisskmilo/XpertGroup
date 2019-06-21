using Presentations.Models;
using Presentations.WsXpertGroup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Presentations.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }

        [HttpPost]
        public string GetData(string dataAux)
        {
            wsdata wsdataAux = new wsdata();
            wsdataAux.data = dataAux;
            ProcessData processData= new ProcessData();
            string response = processData.getProcessDataSum(wsdataAux);

            return response;
        }
    }
}
