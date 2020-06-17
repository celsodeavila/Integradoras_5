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
    public class ProcedimentosPosAdocaoController : Controller
    {
        private ApplicationDbContext context;
        private IProcedimentosPosAdocaoRepositorio repositorio;
        public int PageSize = 2;
        public ProcedimentosPosAdocaoController(IProcedimentosPosAdocaoRepositorio repo, ApplicationDbContext ctx)
        {
            repositorio = repo;
            context = ctx;
        }
        
        [HttpGet]
        public IActionResult New(int pag = 1)
        {
            ViewBag.Animais =  new SelectList(context.Animais.OrderBy(a => a.NomeAnimal), "AnimalID", "NomeAnimal");
            return View(new ProcedimentosPosAdocaoListViewModel
            {
                ProcedimentosPosAdocao = repositorio.ProcedimentosPosAdocao
                .OrderBy(p => p.ProcedimentosPosAdocaoID)
                .Skip((pag - 1) * PageSize)
                .Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    PaginaAtual = pag,
                    ItensPorPagina = PageSize,
                    TotalItens = repositorio.ProcedimentosPosAdocao.Count()
                }
            });
        }

        [HttpPost]
        public IActionResult New(ProcedimentosPosAdocao procedimentosPosAdocao)
        {
            repositorio.Create(procedimentosPosAdocao);
            return Redirect("New");
        }

        public IActionResult Details(int id)
        {
            var procedimentosPosAdocao = repositorio.ObterProcedimentosPosAdocao(id);
            return View(procedimentosPosAdocao);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var procedimentoPosAdocao = context.ProcedimentosPosAdocao.Find(id);
            /*ViewBag.FabricanteId = new SelectList(context.Fabricantes.OrderBy(f
           => f.Nome), "FabricanteID", "Nome");*/
            return View(procedimentoPosAdocao);
        }
        [HttpPost]
        public IActionResult Edit(ProcedimentosPosAdocao procedimentoPosAdocao)
        {
            repositorio.Edit(procedimentoPosAdocao);
            return RedirectToAction("Details", "ProcedimentosPosAdocaoController", new { id = procedimentoPosAdocao.ProcedimentosPosAdocaoID });
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var procedimentosPosAdocao = repositorio.ObterProcedimentosPosAdocao(id);
            return View(procedimentosPosAdocao);
        }
        [HttpPost]
        public IActionResult Delete(ProcedimentosPosAdocao procedimentoPosAdocao)
        {
            repositorio.Delete(procedimentoPosAdocao);
            return RedirectToAction("List");
        }
    }
}