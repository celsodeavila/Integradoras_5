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
        public IActionResult New(int pag = 1, string filter = "name", string query = "")
        {
            ViewBag.Animais = new SelectList(context.Animais.OrderBy(a => a.NomeAnimal), "AnimalID", "NomeAnimal");
            ViewBag.isEdit = false;
            IQueryable<ProcedimentosPreAdocao> filteredList;

            if (!string.IsNullOrEmpty(query))
            {
                switch (filter)
                {
                    case "date":
                        filteredList = repositorio.ProcedimentosPreAdocao.Where(p => p.data.ToShortDateString().Contains(query));
                        break;
                    case "id":
                        filteredList = repositorio.ProcedimentosPreAdocao.Where(p => p.ProcedimentosPreAdocaoID.ToString().Contains(query));
                        break;
                    case "aid":
                        filteredList = repositorio.ProcedimentosPreAdocao.Where(p => p.AnimalID.ToString().Contains(query));
                        break;
                    default:
                        filteredList = repositorio.ProcedimentosPreAdocao.Where(p => p.Animal.NomeAnimal.Contains(query));
                        break;
                }
            }
            else filteredList = repositorio.ProcedimentosPreAdocao;
            return View(new ProcedimentosPreAdocaoListViewModel
            {
                ProcedimentosPreAdocao = filteredList
                .OrderBy(p => p.ProcedimentosPreAdocaoID)
                .Skip((pag - 1) * PageSize)
                .Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    PaginaAtual = pag,
                    ItensPorPagina = PageSize,
                    TotalItens = filteredList.Count(),
                    filter = filter,
                    query = query
                }
            });
        }
        [HttpPost]
        public IActionResult New(ProcedimentosPreAdocao procedimentoPreAdocao, int pag = 1)
        {
            repositorio.Create(procedimentoPreAdocao);
            return RedirectToAction("New", new { pag });
        }

        [HttpGet]
        public IActionResult Edit(int id, int pag = 1)
        {
            ViewBag.Animais = new SelectList(context.Animais.OrderBy(a => a.NomeAnimal), "AnimalID", "NomeAnimal");
            ViewBag.isEdit = true;
            return View("New", new ProcedimentosPreAdocaoListViewModel
            {
                procedimentoPreAdocao = context.ProcedimentosPreAdocao.Find(id),
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
        public IActionResult Edit(ProcedimentosPreAdocao procedimentoPreAdocao, int pag = 1)
        {
            procedimentoPreAdocao.Animal = context.Animais.Find(procedimentoPreAdocao.AnimalID);
            repositorio.Edit(procedimentoPreAdocao);
            return RedirectToAction("New", new { pag });
        }

        [HttpGet]
        public IActionResult Delete(int id, int pag = 1)
        {
            var procedimentoPreAdocao = repositorio.ObterProcedimentosPreAdocao(id);
            repositorio.Delete(procedimentoPreAdocao);
            return RedirectToAction("New", new { pag });
        }
    }
}