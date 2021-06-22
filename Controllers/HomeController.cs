using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using repaso_para_examen__1.Models;

namespace repaso_para_examen__1.Controllers
{
    public class HomeController : Controller
    {
       private readonly ILogger<HomeController> _logger;
        private readonly FailsContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public HomeController(ILogger<HomeController> logger,
            FailsContext context,
            UserManager<IdentityUser> userManager)
        {
            _context = context;
            _logger = logger;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
           var fail = _context.fails.OrderBy(r => r.FechaRegistro).ToList();
            return View(fail);
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
        

         public IActionResult CrearFails() {
            ViewBag.Fails = _context.fails.ToList().Select(r => new SelectListItem(r.Titulo, r.Id.ToString()));
            return View();
        }

        [HttpPost]
        public IActionResult CrearFails(Fails r) {
            if (ModelState.IsValid) {
                _context.Add(r);
                _context.SaveChanges();
                return RedirectToAction("CrearFailsConfirmacion");
            }
            return View(r);
        }

        public IActionResult CrearFailsConfirmacion() {
            return View();
        }
      
      

        /****************************/
        public async Task<IActionResult> Comentarios(int? id)
        {
            var userID = _userManager.GetUserName(User);
            if(userID == null){
                ViewData["Message"] = "Por favor debe loguearse antes de agregar un producto";
               
                return  View("Index");
            }else{
              
             var fail=_context.fails.Find(id);

            return View(fail);
            }  
            
        }
    }
}
