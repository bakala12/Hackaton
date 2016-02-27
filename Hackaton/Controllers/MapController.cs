using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Hackaton.DataAccess;
using Hackaton.DataAccess.Entities;

namespace Hackaton.Controllers
{
    public class MapController : Controller
    {
        public JsonResult GetTrees()
        {
            using (ApplicationDbContext ctx = new ApplicationDbContext())
            {
                /* List<Tree> trees = new List<Tree>();
                 trees.Add(ctx.Trees.First());
                 trees.Add(ctx.Trees.First(t => t.Id == 10));
                 return Json(trees, JsonRequestBehavior.AllowGet);*/
                return Json(ctx.Trees.ToList(), JsonRequestBehavior.AllowGet);
            }
        }
    }
}