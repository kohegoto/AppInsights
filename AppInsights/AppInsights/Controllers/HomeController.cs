using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using log4net;
using Microsoft.ApplicationInsights.Extensibility;
using Microsoft.ApplicationInsights.Extensibility.PerfCounterCollector;

namespace AppInsights.Controllers
{
    public class HomeController : Controller
    {

        
        public ActionResult Index()
        {
            var perfCollectorModule = new PerformanceCollectorModule();
            perfCollectorModule.Counters.Add(new PerformanceCounterCollectionRequest(
              @"\Process([replace-with-application-process-name])\Page Faults/sec", "PageFaultsPerfSec"));
            perfCollectorModule.Initialize(TelemetryConfiguration.Active);

            log4net.Config.XmlConfigurator.Configure();
            var logger = LogManager.GetLogger(typeof(ActionResult));
            logger.Info("Index info");
            return View();
        }

        [HttpPost]
        public ActionResult Debug(String msg)
        {
            log4net.Config.XmlConfigurator.Configure();
            var logger = LogManager.GetLogger(typeof(ActionResult));
            logger.Debug(msg);
            ViewData["msg"] = msg;
            return View();
        }

        [HttpPost]
        public ActionResult Info(String msg)
        {
            log4net.Config.XmlConfigurator.Configure();
            var logger = LogManager.GetLogger(typeof(ActionResult));
            logger.Info(msg);
            ViewData["msg"] = msg;
            return View();
        }

        [HttpPost]
        public ActionResult Warn(String msg)
        {
            log4net.Config.XmlConfigurator.Configure();
            var logger = LogManager.GetLogger(typeof(ActionResult));
            logger.Warn(msg);
            ViewData["msg"] = msg;
            return View();
        }

        [HttpPost]
        public ActionResult Error(String msg)
        {
            log4net.Config.XmlConfigurator.Configure();
            var logger = LogManager.GetLogger(typeof(ActionResult));
            logger.Error(msg);
            ViewData["msg"] = msg;
            return View();
        }
    }
}