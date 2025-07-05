using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using RadFBApp.Areas.Panel.Repository;
using RadFBApp.Models.Data;

namespace RadFBApp.Areas.Panel.Controllers
{
    [Area("Panel")]
    [Authorize]
    public class bookController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
