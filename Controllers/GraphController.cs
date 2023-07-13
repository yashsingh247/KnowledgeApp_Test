using KnowledgeApp_Test.Models.Graph;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KnowledgeApp_Test.Services;
using System.Web.Mvc;

namespace KnowledgeApp_Test.Controllers
{
    public class GraphController : Controller
    {
        JsonSerializerSettings _jsonSetting = new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore };
        GraphServices Gs = new GraphServices();
        // GET: Graph
        public ActionResult ParameterGraph()
        {
            List<StoppageGraph> SG = new List<StoppageGraph>();
            SG = Gs.StoppageGraph();
            ViewBag.DataPoints = JsonConvert.SerializeObject(SG, _jsonSetting);
            return View();
        }
        public ActionResult ParameterFrequencyGraph()
        {
            return View();
        }
        public ActionResult StoppageGraph()
        {
            List<StoppageGraph> SG = new List<StoppageGraph>();
            SG =Gs.StoppageGraph();
            ViewBag.StoppageData = JsonConvert.SerializeObject(SG, _jsonSetting);
            return View();
        }
        public ActionResult StoppageReasonWiseGraph()
        {
            return View();
        }
       

    }
}