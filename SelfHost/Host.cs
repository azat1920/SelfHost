using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.SelfHost;
using System.Text;
using System.Threading.Tasks;

namespace SelfHost
{
    public class Host
    {
        private string addr;

        public Host(string s)
        {
                addr = s;
        }

        public void StartSelfHost()
        {

            var config = new HttpSelfHostConfiguration(addr);

            config.Routes.MapHttpRoute(
                "API Default", "api/{controller}/{id}",
                new { id = RouteParameter.Optional });

            using (HttpSelfHostServer server = new HttpSelfHostServer(config))
            {
                Console.WriteLine("listen {0}", addr);
                server.OpenAsync().Wait();
                Console.WriteLine("Press Enter to quit.");
                Console.ReadLine();
            }
        }
    }
}
