using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SelfHost
{
    public class MenuItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
    }

    public class MenuController : ApiController
    {

        static List<MenuItem> list = new List<MenuItem>
        {
            new MenuItem { Id = 1, Name = "Soup",  Price = 50 },  
            new MenuItem { Id = 2, Name = "Juice", Price = 20 },  
            new MenuItem { Id = 3, Name = "Dessert",  Price = 70 }  
        };


        public IEnumerable<MenuItem> Get()
        {
            return list;
        }


        public MenuItem Get(int id)
        {
            return list.FirstOrDefault(p => p.Id == id);
        }


        public HttpResponseMessage Post([FromBody]MenuItem p)
        {
            var menuItem = (from item in list where item.Id == p.Id select item).FirstOrDefault();
            if (menuItem == null)
            {
                list.Add(p);
                return Request.CreateResponse(HttpStatusCode.OK);

            }
            else
            {

                Console.WriteLine("Add Error - incorrect id");
                return Request.CreateResponse(HttpStatusCode.Forbidden);
            }

        }


        public HttpResponseMessage Put(int id, [FromBody]MenuItem item)
        {
            var menuItem = (from p in list where p.Id == id select p).FirstOrDefault();
            menuItem.Name = item.Name;
            menuItem.Price = item.Price;

            return Request.CreateResponse(HttpStatusCode.OK);

        }

        public HttpResponseMessage Delete(int id)
        {
            var item = (from p in list where p.Id == id select p).FirstOrDefault();
            if (item != null)
            {
                list.Remove(item);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.Forbidden);
            }

        }

    }
}

