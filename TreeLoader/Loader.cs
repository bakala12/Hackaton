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
        int counter = 1;

        public void Load()
        {
          /*  for (double x = 52.12; x < 52.31; x+=0.01)
            {
                for (double y = 20.82; y < 21.18; y += 0.01)
                {
                    Load(x,y);
                }
            }*/
            for (char c = 'a'; c <= 'z'; c++)
            {
                Load(c);
            }
        }

        private void Load(char c)//(double x, double y)
        {
            //Console.WriteLine("ROZPOCZĘTO CZYTANIE DRZEW O Wsporzednych " + x + "||" + y);
            Console.WriteLine("ROZPOCZĘTO CZYTANIE DRZEW "+c);

            string json;
            using (WebClient webClient = new WebClient())
            {
               // string filters = @"&filters={""wiek_w_dni"":""" + a + @"""}";
                //string filters = "circle=21.02,52.21,1000";
               // string filters = "circle="+y+","+x+",0.0001";
               // filters += "&limit=50000";

                string filters = "&q=" + c;
                filters += "&limit=50000";

                json = webClient.DownloadString(apiUri + "&" + filters).Replace(@"\ufeff", "");
            }
            DeserializedObject result = (DeserializedObject)JsonConvert.DeserializeObject(json, typeof(DeserializedObject));
            var trees = result.result.records;
            Console.WriteLine("Znaleziono {0} drzew", trees.Count);
            int i = 1;
            using (ApplicationDbContext ctx = new ApplicationDbContext())
            {
                foreach (var tree in trees)
                {
                    InsertTree(tree, ctx, ref i);
                    if (i % 500 == 0)
                    {
                        Console.WriteLine("SaveChanges");
                        ctx.SaveChanges();
                    }
                }
                Console.WriteLine("SaveChanges");
                ctx.SaveChanges();
            }
            Console.WriteLine("ZAKOŃCZONO CZYTANIE OBSZARU DRZEW  " );
        }

        private void InsertTree(Tree tree, ApplicationDbContext ctx, ref int i)
        {
            counter++;
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
                Console.WriteLine("{4} || {0} || Dodano drzewo: {1} X: {2} Y:{3} ", i, tree.numer_inw, tree.x_wgs84, tree.y_wgs84, counter);
                i++;
            }
        }
    }
}
