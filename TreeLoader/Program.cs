using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeLoader
{
    class Program
    {
        static void Main(string[] args)
        {
            /*  Task t = MainAsync(args);
              t.Wait();*/

            Loader loader = new Loader();
            loader.Load();
        }

        static async Task MainAsync(string[] args)
        {
           /* Loader loader = new Loader();
            var s = await loader.Load();*/
        }
    }
}
