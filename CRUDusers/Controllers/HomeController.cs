using CRUDusers.Helper;
using CRUDusers.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace CRUDusers.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        UsuersAPI _api = new UsuersAPI();

        public async Task<IActionResult> Index()
        {
            List<UsersData> usuarios = new List<UsersData>();
            HttpClient client = _api.Initial();
            HttpResponseMessage res = await client.GetAsync("Users");
            if (res.IsSuccessStatusCode)
            {
                var results = res.Content.ReadAsStringAsync().Result;
                usuarios = JsonConvert.DeserializeObject<List<UsersData>>(results);
            }
            return View(usuarios);

        }

        public async Task<IActionResult> Details(int Id)
        {
            var usuarios = new UsersData();
            HttpClient client = _api.Initial();
            HttpResponseMessage res = await client.GetAsync("Users/"+Id);
            if (res.IsSuccessStatusCode)
            {
                var results = res.Content.ReadAsStringAsync().Result;
                usuarios = JsonConvert.DeserializeObject<UsersData>(results);
            }
            return View(usuarios);

        }

        public ActionResult create()
        {
            return View();
        }

        public async Task<IActionResult> Put(int Id)
        {
            var usuarios = new UsersData();
            HttpClient client = _api.Initial();
            HttpResponseMessage res = await client.GetAsync("Users/" + Id);
            if (res.IsSuccessStatusCode)
            {
                var results = res.Content.ReadAsStringAsync().Result;
                usuarios = JsonConvert.DeserializeObject<UsersData>(results);
            }
            return View(usuarios);

        }

        [HttpPost]
        public IActionResult create(UsersData user)
        {
            HttpClient client = _api.Initial();

            var postTask = client.PostAsJsonAsync<UsersData>("Users", user);
            postTask.Wait();

            var result = postTask.Result;
            if (result.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View();
        }

        [HttpPost]
        public IActionResult put(int Id, UsersData user)
        {
            HttpClient client = _api.Initial();

            var putTask = client.PutAsJsonAsync<UsersData>("Users/" + Id, user);
            putTask.Wait();

            var result = putTask.Result;
            if (result.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View();
        }

        public async Task<IActionResult> Delete(int Id)
        {
            var usuarios = new UsersData();
            HttpClient client = _api.Initial();
            HttpResponseMessage res = await client.DeleteAsync("Users/" + Id);
            return RedirectToAction("Index");
        }

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
