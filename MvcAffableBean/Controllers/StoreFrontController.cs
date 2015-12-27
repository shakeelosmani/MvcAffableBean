using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MvcAffableBean.DAL;
using MvcAffableBean.Models;

namespace MvcAffableBean.Controllers
{
    public class StoreFrontController : Controller
    {

        private MvcAffableBeanContext db = new MvcAffableBeanContext();
        // GET: StoreFront
        public ActionResult Index(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Category category = db.Categories.Find(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }
    }
}