using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CaoLendario.Models;
using CaoLendario.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CaoLendario.Controllers
{
    public class ProcedimentosPreAdocaoController : Controller
    {
        private ApplicationDbContext context;
        private IProcedimentosPreAdocaoRepositorio repositorio;
        public int PageSize = 2;
        public ProcedimentosPreAdocaoController(IProcedimentosPreAdocaoRepositorio repo, ApplicationDbContext ctx)
        {
            repositorio = repo;
            context = ctx;
        }

        [HttpGet]
        public IActionResult New(int pag = 1)
        {
            ViewBag.Animais = new SelectList(context.Animais.OrderBy(a => a.NomeAnimal), "AnimalID", "NomeAnimal");
            return View(new ProcedimentosPreAdocaoListViewModel
            {
                ProcedimentosPreAdocao = repositorio.ProcedimentosPreAdocao
                .OrderBy(p => p.ProcedimentosPreAdocaoID)
                .Skip((pag - 1) * PageSize)
                .Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    PaginaAtual = pag,
                    ItensPorPagina = PageSize,
                    TotalItens = repositorio.ProcedimentosPreAdocao.Count()
                }
            });
        }
        [HttpPost]
        public IActionResult New(ProcedimentosPreAdocao procedimentoPreAdocao)
        {
            repositorio.Create(procedimentoPreAdocao);
            return RedirectToAction("New");
        }

        public IActionResult Details(int id)
        {
            var procedimentoPreAdocao = repositorio.ObterProcedimentosPreAdocao(id);
            return View(procedimentoPreAdocao);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var procedimentoPreAdocao = context.ProcedimentosPreAdocao.Find(id);
            /*ViewBag.FabricanteId = new SelectList(context.Fabricantes.OrderBy(f
           => f.Nome), "FabricanteID", "Nome");*/
            return View(procedimentoPreAdocao);
        }
        [HttpPost]
        public IActionResult Edit(ProcedimentosPreAdocao procedimentoPreAdocao)
        {
            repositorio.Edit(procedimentoPreAdocao);
            return RedirectToAction("Details", "ProcedimentosPreAdocaoController", new { id = procedimentoPreAdocao.ProcedimentosPreAdocaoID });
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var procedimentoPreAdocao = repositorio.ObterProcedimentosPreAdocao(id);
            return View(procedimentoPreAdocao);
        }
        [HttpPost]
        public IActionResult Delete(ProcedimentosPreAdocao procedimentoPreAdocao)
        {
            repositorio.Delete(procedimentoPreAdocao);
            return RedirectToAction("List");
        }
    }
}