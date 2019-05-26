using Microsoft.AspNetCore.Mvc;
using SistemaVendasAspNetCore.Models;

namespace SistemaVendasAspNetCore.Controllers
{
    public class ClienteController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.ListaClientes = new ClienteModel().ListarTodosClientes();
            return View();
        }

        [HttpGet]
        public IActionResult Cadastro(int? id)
        {
            if (id != null){
                //Carregar o registro do cliente em uma viewbag.
                ViewBag.Cliente = new ClienteModel().RetornarCliente(id);
            }
            return View();
        }

        [HttpPost]
        public IActionResult Cadastro(ClienteModel cliente)
        {
            if (ModelState.IsValid)
            {
                cliente.Gravar();
                return RedirectToAction("Index");
            }
            return View();
        }
        public IActionResult Excluir(int id)
        {
            ViewData["IdExcluir"] = id;
            return View();
        }
        public IActionResult ExcluirCliente(int id)
        {
            new ClienteModel().Excluir(id);
            ViewData["IdExcluir"] = id;
            return View();
        }
    }
}