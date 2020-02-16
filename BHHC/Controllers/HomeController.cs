using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BHHC.Views.Home.Models;
using Microsoft.AspNetCore.Mvc;

namespace BHHC.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var vm = new IndexViewModel()
            {
                HomeViewProperty = ".NET Core MVC + AngularJS SPA by DJ Hubka",
                PageTitle = "DJ Hubka's Simple Sample - SPA"
            };

            return this.View(vm);
        }
    }
}