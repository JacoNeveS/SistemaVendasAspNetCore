using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaVendasAspNetCore.Models;

namespace SistemaVendasAspNetCore.Controllers
{
    public class VendaController : Controller
    {
        private IHttpContextAccessor httpContext;
        public VendaController(IHttpContextAccessor HttpContextAccessor)
        {
            httpContext = HttpContextAccessor;
        }

        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.ListaVendas = new VendaModel().ListagemVendas();
            return View();
        }

        [HttpGet]
        public IActionResult Registrar()
        {
            CarregarDados();
            return View();
        }
        [HttpPost]
        public IActionResult Registrar(VendaModel venda)
        {
            //Pega ID do Vendedor logado.
            venda.Vendedor_Id = httpContext.HttpContext.Session.GetString("IdUsuarioLogado");
            venda.Inserir();
            CarregarDados();
            return View();
        }

        private void CarregarDados()
        {
            ViewBag.ListaClientes = new VendaModel().RetornarListaClientes();
            ViewBag.ListaVendedores = new VendaModel().RetornarListaVendedores();
            ViewBag.ListaProdutos = new VendaModel().RetornarListaProdutos();
        }
    }
}