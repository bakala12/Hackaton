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
        private const int treesCount = 50;

        public JsonResult GetTrees(double southWestX, double southWestY, double northEastX, double northEastY)
        {
            using (ApplicationDbContext ctx = new ApplicationDbContext())
            {
                int c = ctx.Trees.Count(t =>
                    t.CoordX > southWestX && t.CoordX < northEastX &&
                    t.CoordY < northEastY && t.CoordY > southWestY);
                
                int step = c / treesCount;
                if (step == 0) step = 1;

                var trees = ctx.Trees.Where(t => t.Id % step == 0 &&
                    t.CoordX > southWestX && t.CoordX < northEastX &&
                    t.CoordY < northEastY && t.CoordY > southWestY);

                return Json(trees.ToList(), JsonRequestBehavior.AllowGet);
            }
        }

    }
}