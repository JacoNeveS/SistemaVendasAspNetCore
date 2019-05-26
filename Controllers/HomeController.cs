using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaVendasAspNetCore.Models;
using System.Diagnostics;

namespace SistemaVendasAspNetCore.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Menu()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Login(int? id)
        {
            //realizar logout
            if (id != null)
            {
                if (id == 0)
                {
                    HttpContext.Session.SetString("IdUsuarioLogado", string.Empty);
                    HttpContext.Session.SetString("NomeUsuarioLogado", string.Empty);
                }
            }
            //fim
            return View();
        }
        [HttpPost]
        public IActionResult Login(LoginModel login)
        {
            if (ModelState.IsValid)
            {
                bool loginOk = login.ValidarLogin();
                if (loginOk)
                {
                    HttpContext.Session.SetString("IdUsuarioLogado", login.Id);
                    HttpContext.Session.SetString("NomeUsuarioLogado", login.Nome);
                    return RedirectToAction("Menu", "Home");
                }
                else
                {
                    TempData["ErrorLogin"] = "E-mail ou senha são inválidos!";
                }
            }

            return View();
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";
            return View();
        }
        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";
            return View();
        }
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
