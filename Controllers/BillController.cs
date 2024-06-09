using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication14.Models;
using WebApplication14.Repository;


namespace WebApplication14.Controllers
{
    public class BillController : Controller
    {
        // GET: Bill
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(BillDetails details)
        {
            Data data = new Data();
            data.SaveBillDetail(details);
            ModelState.Clear();
            return View();
        }
    }
}