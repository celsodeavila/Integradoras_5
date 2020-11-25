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
        public IActionResult New(int pag = 1, string filter = "name", string query = "")
        {
            ViewBag.Animais =  new SelectList(context.Animais.OrderBy(a => a.NomeAnimal), "AnimalID", "NomeAnimal");
            ViewBag.isEdit = false;

            IQueryable<ProcedimentosPosAdocao> filteredList;

            if (!string.IsNullOrEmpty(query))
            {
                switch (filter)
                {
                    case "date":
                        filteredList = repositorio.ProcedimentosPosAdocao.Where(p => p.data.ToShortDateString().Contains(query));
                        break;
                    case "id":
                        filteredList = repositorio.ProcedimentosPosAdocao.Where(p => p.ProcedimentosPosAdocaoID.ToString().Contains(query));
                        break;
                    case "aid":
                        filteredList = repositorio.ProcedimentosPosAdocao.Where(p => p.AnimalID.ToString().Contains(query));
                        break;
                    default:
                        filteredList = repositorio.ProcedimentosPosAdocao.Where(p => p.Animal.NomeAnimal.Contains(query));
                        break;
                }
            }
            else filteredList = repositorio.ProcedimentosPosAdocao;

            return View(new ProcedimentosPosAdocaoListViewModel
            {
                ProcedimentosPosAdocao = filteredList
                .OrderBy(p => p.ProcedimentosPosAdocaoID)
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
            }); ;
        }

        [HttpPost]
        public IActionResult New(ProcedimentosPosAdocao procedimentoPosAdocao, int pag = 1)
        {
            repositorio.Create(procedimentoPosAdocao);
            return RedirectToAction("New", new { pag });
        }

        [HttpGet]
        public IActionResult Edit(int id, int pag = 1)
        {
            ViewBag.Animais = new SelectList(context.Animais.OrderBy(a => a.NomeAnimal), "AnimalID", "NomeAnimal");
            ViewBag.isEdit = true;
            return View("New", new ProcedimentosPosAdocaoListViewModel
            {
                procedimentoPosAdocao = context.ProcedimentosPosAdocao.Find(id),
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
        public IActionResult Edit(ProcedimentosPosAdocao procedimentoPosAdocao, int pag = 1)
        {
            procedimentoPosAdocao.Animal = context.Animais.Find(procedimentoPosAdocao.AnimalID);
            repositorio.Edit(procedimentoPosAdocao);
            return RedirectToAction("New", new { pag });
        }

        [HttpGet]
        public IActionResult Delete(int id, int pag = 1)
        {
            var procedimentoPosAdocao = repositorio.ObterProcedimentosPosAdocao(id);
            repositorio.Delete(procedimentoPosAdocao);
            return RedirectToAction("New", new { pag });
        }
    }
}