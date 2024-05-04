using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace YourNamespace.Controllers
{
    public class ReportController : Controller
    {
        private _DbContext db = new _DbContext();

        // GET: Report
        public ActionResult Index()
        {
            //ViewBag.CustomerIDs = db.OrderMasters.Select(o => new { o.CustomerID }).Distinct().ToList();
            ViewBag.CustomerIDs = db.OrderMasters.Select(o => o.CustomerID.ToString()).Distinct().ToList();
            return View();
        }

        [HttpPost]
        public ActionResult Search(string customerId)
        {
            var orders = db.OrderMasters.Where(o => o.CustomerID == customerId).ToList();

            return PartialView("_OrderList", orders);
        }
    }
}
