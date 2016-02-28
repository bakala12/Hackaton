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

        private class EventTree
        {
            public bool IsAuthenticated { get; set; }
            public int Id { get; set; }
            public double CoordX { get; set; }
            public double CoordY { get; set; }
            public bool IsEvent { get; set; }
            public string EventDate { get; set; }

        }

        public JsonResult GetTrees(double southWestX, double southWestY, double northEastX, double northEastY, int zoom)
        {
            using (ApplicationDbContext ctx = new ApplicationDbContext())
            {
                List<EventTree> ret = new List<EventTree>();

                int c = ctx.Trees.Count(t =>
                    t.CoordX > southWestX && t.CoordX < northEastX &&
                    t.CoordY < northEastY && t.CoordY > southWestY);

                var checkedTrees = ctx.Events.Select(e => e.Tree).Where(t =>
                    t.CoordX > southWestX && t.CoordX < northEastX &&
                    t.CoordY < northEastY && t.CoordY > southWestY).Take(treesCount).ToList();
                foreach (var v in checkedTrees)
                {
                    ret.Add(new EventTree()
                    {
                        IsAuthenticated = User.Identity.IsAuthenticated,
                        Id = v.Id,
                        CoordX = v.CoordX,
                        CoordY = v.CoordY,
                        IsEvent = true,
                        EventDate = ctx.Events.First(e => e.Tree.Id == v.Id).Date.ToString()
                    });
                }

                if (treesCount != ret.Count)
                {
                    int step = GetStepFromZoom(zoom);

                    var trees = ctx.Trees.Where(t => t.Id % step == 0 &&
                        t.CoordX > southWestX && t.CoordX < northEastX &&
                                                         t.CoordY < northEastY && t.CoordY > southWestY).ToList();
                    trees = trees.Where(t => !ret.Select(re => re.Id).Contains(t.Id)).ToList();

                    foreach (var v in trees)
                    {
                        ret.Add(new EventTree()
                        {
                            IsAuthenticated = User.Identity.IsAuthenticated,
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

        private int GetStepFromZoom(int zoom)
        {
            switch (zoom)
            {
                case 11:
                    return 1000;
                case 12:
                    return 700;
                case 13:
                    return 400;
                case 14:
                    return 150;
                case 15:
                    return 50;
                case 16:
                    return 10;
                case 17:
                    return 3;
                case 18:
                    return 1;
            }
            if (zoom > 18)
                return 1;
            else
                return 2000;
        }

    }
}