using Microsoft.AspNetCore.Mvc;
using SistemaVendasAspNetCore.Models;

namespace SistemaVendasAspNetCore.Controllers
{
    public class VendedorController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.ListaVendedores = new VendedorModel().ListarTodosVendedores();
            return View();
        }

        [HttpGet]
        public IActionResult Cadastro(int? id)
        {
            if (id != null){
                //Carregar o registro do vendedor em uma viewbag.
                ViewBag.Vendedor = new VendedorModel().RetornarVendedor(id);
            }
            return View();
        }

        [HttpPost]
        public IActionResult Cadastro(VendedorModel vendedor)
        {
            if (ModelState.IsValid)
            {
                vendedor.Gravar();
                return RedirectToAction("Index");
            }
            return View();
        }
        public IActionResult Excluir(int id)
        {
            ViewData["IdExcluir"] = id;
            return View();
        }
        public IActionResult ExcluirVendedor(int id)
        {
            new VendedorModel().Excluir(id);
            return View();
        }
    }
}