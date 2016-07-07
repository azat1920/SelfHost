using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using SelfHost;

namespace SelfHost
{
    internal class Program
    {
        private static HttpClient client = new HttpClient();

        private static void Main(string[] args)
        {   
            var item1 = new MenuItem { Id = 4, Name = "Item", Price = 45 };

            var item2 = new MenuItem { Id = 4, Name = "Item2", Price = 54 };

            string addr = "http://localhost:8080";
            Console.WriteLine("client for {0}", addr);

            client.BaseAddress = new Uri(addr);
            Console.WriteLine("----------\nGet menu list\n----------");
            GetMenu();
            Console.WriteLine("----------\nGet menu items by id\n----------");
            GetMenuItem(3);
            GetMenuItem(1);
            GetMenuItem(6);
           
            Console.WriteLine("----------\nAdd new item\n----------");
            AddMenuItem(item1);
            Console.WriteLine("----------\nGet menu list\n----------");
            GetMenu();
            Console.WriteLine("----------\nEdit menu item\n-----------");
            EditMenuItem(4, item2);
            Console.WriteLine("----------\nGet menu list\n----------");
            GetMenu();
            Console.WriteLine("----------\nDelete menu item\n-----------");
            DeleteMenuItem(4);
            Console.WriteLine("----------\nGet menu list\n----------");
            GetMenu();
            
            Console.WriteLine("Press Enter to quit.");
            Console.ReadLine();
        }
     

        
        private static void GetMenu()
        {
            HttpResponseMessage resp =  client.GetAsync("api/menu").Result;
            resp.EnsureSuccessStatusCode();

            var menu = resp.Content.ReadAsAsync<IEnumerable<SelfHost.MenuItem>>().Result.ToList();
            if (menu.Any())
            {
                foreach (var p in menu)
                {
                    Console.WriteLine("{0}\t{1}\t{2} ", p.Id, p.Name, p.Price);
                }
            }
        }

        private static void GetMenuItem(int id)
        {
            HttpResponseMessage resp = client.GetAsync(String.Format("api/menu/{0}", id)).Result;
            resp.EnsureSuccessStatusCode();

            var menuItem = resp.Content.ReadAsAsync<SelfHost.MenuItem>().Result;
            if (menuItem != null)
            {
                Console.WriteLine("{0}\t{1}\t{2} ", menuItem.Id, menuItem.Name, menuItem.Price);
            }
            else
            {
                Console.WriteLine("Error get menu by id = {0}", id);
            }
            
        }

        private static void AddMenuItem(MenuItem item)
        {
            var resp = client.PostAsJsonAsync("api/menu", item);
            resp.Wait();
            if (resp.Result.IsSuccessStatusCode)
            {
                Console.WriteLine("{0}\t{1}\t{2} added", item.Id, item.Name, item.Price);
            }
            else
            {
                Console.WriteLine("Add error");
            }
        }

        private static void EditMenuItem(int id, MenuItem item)
        {
            var resp = client.PutAsJsonAsync("api/menu/" + id, item);
            resp.Wait();
            if (resp.Result.IsSuccessStatusCode)
            {
                Console.WriteLine("Item by id = {0} edited", id);
            }

        }

        private static void DeleteMenuItem(int id)
        {
            var resp = client.DeleteAsync("api/menu/" + id);
            resp.Wait();
            if (resp.Result.IsSuccessStatusCode)
            {
                Console.WriteLine("Item by id = {0} deleted", id);
            }
            else
            {
                Console.WriteLine("Delete error");
            }



        }

    }
}
