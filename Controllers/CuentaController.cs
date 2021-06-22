using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace repaso_para_examen__1.Controllers
{
    public class CuentaController :Controller
    {
        private readonly SignInManager<IdentityUser> _sim;
        private readonly UserManager<IdentityUser> _um;
        
        public CuentaController(SignInManager<IdentityUser> sim,UserManager<IdentityUser> um)
        {
            _sim=sim;
            _um=um;
        }
        public IActionResult CrearCuenta(){
            return View();

        }
        public IActionResult InicioSesion(){
            return View();

        }
        [HttpPost]
        public IActionResult InicioSesion(string usuario,string password){

            var result =_sim.PasswordSignInAsync(usuario,password,false,false).Result;
            if(result.Succeeded)
            {
               return RedirectToAction("Index","Home");

            }
            ModelState.AddModelError("","los datos son incorrectos");
            return View();
            

        }
        public async Task<IActionResult> CerrarSesion(){
            await  _sim.SignOutAsync();
            return RedirectToAction("Index","Home");
            

        }
        [HttpPost]
        public IActionResult CrearCuenta(string email, string password){
            var usuario = new IdentityUser(email);
            //usuario.Email=email;
            var resultado=_um.CreateAsync(usuario,password).Result;
            if(resultado.Succeeded){
                return RedirectToAction("Index","Home");
            }
            foreach(var error in resultado.Errors){
                ModelState.AddModelError("",error.Description);
            }
            return View();
        }
    }
}