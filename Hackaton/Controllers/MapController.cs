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

        private class MyTree
        {
            public int Id { get; set; }
            public double CoordX { get; set; }
            public double CoordY { get; set; }
            public bool IsEvent { get; set; }

        }

        public JsonResult GetTrees(double southWestX, double southWestY, double northEastX, double northEastY)
        {
            using (ApplicationDbContext ctx = new ApplicationDbContext())
            {
                List<MyTree> ret = new List<MyTree>();

                int c = ctx.Trees.Count(t =>
                    t.CoordX > southWestX && t.CoordX < northEastX &&
                    t.CoordY < northEastY && t.CoordY > southWestY);
                
                var checkedTrees = ctx.Events.Select(e => e.Tree).Where(t =>
                    t.CoordX > southWestX && t.CoordX < northEastX &&
                    t.CoordY < northEastY && t.CoordY > southWestY).Take(treesCount);

                foreach (var v in checkedTrees)
                {
                    ret.Add(new MyTree()
                    {
                        Id = v.Id,
                        CoordX = v.CoordX,
                        CoordY = v.CoordY,
                        IsEvent = true
                    });
                }

                if (treesCount != ret.Count)
                {
                    int step = c / (treesCount - checkedTrees.Count());
                if (step == 0) step = 1;

                var trees = ctx.Trees.Where(t => t.Id % step == 0 &&
                    t.CoordX > southWestX && t.CoordX < northEastX &&
                                                     t.CoordY < northEastY && t.CoordY > southWestY).ToList();
                    trees = trees.Where(t => !ret.Select(re => re.Id).Contains(t.Id)).ToList();

                    foreach (var v in trees)
                    {
                        ret.Add(new MyTree()
                        {
                            Id = v.Id,
                            CoordX = v.CoordX,
                            CoordY = v.CoordY,
                            IsEvent = false
                        });
                    }
                }
                return Json(ret, JsonRequestBehavior.AllowGet);
            }
        }

    }
}