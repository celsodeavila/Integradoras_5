using CaoLendario.Models;
using CaoLendario.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CaoLendario.Controllers
{
	public class AdotanteController : Controller
	{
        private IAdotanteRepositorio repositorio;
        private ApplicationDbContext context;
        public int PageSize = 2;

        public AdotanteController(IAdotanteRepositorio repo, ApplicationDbContext ctx)
        {
            repositorio = repo;
            context = ctx;
        }

        //Edit
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var adotante = context.Adotantes.Find(id);
            ViewBag.UserID = new SelectList(context.Adotantes.OrderBy(a => a.nome), "UserID", "Nome");
            return View(adotante);
        }
        [HttpPost]
        public IActionResult Edit(Adotante adotante)
        {
            repositorio.Edit(adotante);
            return RedirectToAction("List");
        }

        //Delete
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var adotante = repositorio.ObterAdotante(id);
            return View(adotante);
        }
        [HttpPost]
        public IActionResult Delete(Adotante adotante)
        {
            repositorio.Delete(adotante);
            return RedirectToAction("List");
        }

        //Create
        [HttpGet]
        public IActionResult New(int pag = 1)
        {
            return View(new AdotantesListViewModel
            {
                adotantes = repositorio.Adotantes
                .OrderBy(p => p.UserID)
                .Skip((pag - 1) * PageSize)
                .Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    PaginaAtual = pag,
                    ItensPorPagina = PageSize,
                    TotalItens = repositorio.Adotantes.Count()
                }
            });
        }

        [HttpPost]
        public IActionResult New(Adotante adotante)
        {
            repositorio.Create(adotante);
            return RedirectToAction("Details");
        }

        //Consulta/Exibe
        [HttpGet]
        public IActionResult Details(int id)
        {
            var Adotante = repositorio.ObterAdotante(id);
            return View(Adotante);
        }
    }
}
