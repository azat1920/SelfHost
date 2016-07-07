using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SelfHost;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            Host h = new Host("http://localhost:8080");
            h.StartSelfHost();
        }
    }
}
