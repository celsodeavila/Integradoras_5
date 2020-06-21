using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CaoLendario.Models;
using Microsoft.AspNetCore.Mvc;

namespace CaoLendario.Controllers
{
    public class ProcedimentosPreAdocaoController : Controller
    {
        private ApplicationDbContext context;
        private IProcedimentosPreAdocaoRepositorio repositorio;
        public int PageSize = 4;
        public ProcedimentosPreAdocaoController(IProcedimentosPreAdocaoRepositorio repo, ApplicationDbContext ctx)
        {
            repositorio = repo;
            context = ctx;
        }

        //public ViewResult List(int pag = 1) => View(new ProdutosListViewModel
        //{
        //    Produtos = repositorio.ProcedimentosPosAdocao
        //    .OrderBy(p => p.ProdutoID)
        //    .Skip((pag - 1) * PageSize)
        //    .Take(PageSize),
        //    PagingInfo = new PagingInfo
        //    {
        //        PaginaAtual = pag,
        //        ItensPorPagina = PageSize,
        //        TotalItens = repositorio.Produtos.Count()
        //    }
        //});

        [HttpGet]
        public IActionResult New()
        {
            /* ViewBag.ProcedimentosPosAdocaoID = new SelectList(context.Fabricantes.OrderBy(f
            => f.Nome), "FabricanteID", "Nome");*/
            return View();
        }
        [HttpPost]
        public IActionResult New(ProcedimentosPreAdocao procedimentoPreAdocao)
        {
            repositorio.Create(procedimentoPreAdocao);
            return RedirectToAction("List");
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