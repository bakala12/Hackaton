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
        private const int treesCount = 20;

        public JsonResult GetTrees(double southWestX, double southWestY, double northEastX, double northEastY)
        {
            using (ApplicationDbContext ctx = new ApplicationDbContext())
            {
                var trees = ctx.Trees.Where(t =>
                    t.CoordX > southWestX && t.CoordX < northEastX &&
                    t.CoordY < northEastY && t.CoordY > southWestY).ToList();
                int c = trees.Count();
                int step = c/treesCount;
                if (step == 0) step = 1;
                var ret = trees.Where((x, i) => i % step == 0);
                return Json(ret, JsonRequestBehavior.AllowGet);
            }
        }
    }
}