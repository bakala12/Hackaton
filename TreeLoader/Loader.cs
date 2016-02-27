using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Hackaton.DataAccess;
using Newtonsoft.Json;
using TreeLoader.Objects;

namespace TreeLoader
{
    public class Loader
    {
        private readonly string apiUri = ConfigurationManager.AppSettings["ApiUri"];
        private readonly string apiUsername = ConfigurationManager.AppSettings["ApiUsername"];
        private readonly string apiPassword = ConfigurationManager.AppSettings["ApiPassword"];

        public void Load()
        {
            string json;
            using (WebClient webClient = new WebClient())
            {
                json = webClient.DownloadString(apiUri).Replace(@"\ufeff", "");
            }
            DeserializedObject result = (DeserializedObject)JsonConvert.DeserializeObject(json, typeof(DeserializedObject));
            var trees = result.result.records;

            foreach (var tree in trees)
            {
                InsertTree(tree);
            }
        }

        private void InsertTree(Tree tree)
        {
            using (ApplicationDbContext ctx = new ApplicationDbContext())
            {
                if (!ctx.Trees.Any(t => t.InventoryNumber == tree.numer_inw))
                {
                    ctx.Trees.Add(new Hackaton.DataAccess.Entities.Tree()
                    {
                        InventoryNumber = tree.numer_inw,
                        Address = tree.adres,
                        CoordX = tree.x_wgs84,
                        CoordY = tree.y_wgs84,
                        Location = tree.lokalizacja,
                        Type = tree.gatunek
                    });
                    Console.WriteLine("Dodano drzewo: X: {0} Y:{1} Gatunek: {2} Adres: {3}", tree.x_wgs84, tree.y_wgs84, tree.gatunek, tree.adres);
                }
            }
        }
    }
}
