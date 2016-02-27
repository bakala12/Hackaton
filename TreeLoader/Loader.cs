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
                if (!ctx.Trees.Any())
            }        
}
    }
}
