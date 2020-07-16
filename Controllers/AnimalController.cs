using CaoLendario.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using CaoLendario.Models.ViewModels;

namespace CaoLendario.Controllers
{
    public class AnimalController : Controller
    {
        private ApplicationDbContext context;

        private IAnimalRepositorio repositorio;
        public int PageSize = 2;
        public AnimalController(IAnimalRepositorio repo, ApplicationDbContext ctx)
        {
            repositorio = repo;
            context = ctx;
        }

        public ViewResult List() => View(repositorio.Animais);

        #region Cadastro de Animais
        [HttpGet]
        public IActionResult New(int pag = 1)
        {
            ViewBag.Animais = new SelectList(context.Animais.OrderBy(a => a.NomeAnimal), "AnimalID", "NomeAnimal");
            return View(new AnimalListViewModel
            {
                Animais = repositorio.Animais
               .OrderBy(p => p.NomeAnimal)
               .Skip((pag - 1) * PageSize)
               .Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    PaginaAtual = pag,
                    ItensPorPagina = PageSize,
                    TotalItens = repositorio.Animais.Count()
                }
            });
        }
        [HttpPost]
        public IActionResult New(Animal animal)
        {
            repositorio.Create(animal);
            return RedirectToAction("New");
        }
        #endregion

        #region Editar Animais
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var animal = context.Animais.Find(id);
            return View(animal);

        }
        [HttpPost]
        public IActionResult Edit(Animal animal)
        {
            repositorio.Edit(animal);
            return RedirectToAction("New");
        }
        #endregion

        #region Deletar Animais
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var animal = repositorio.ObterAnimal(id);
            return View(animal);
        }
        [HttpPost]
        public IActionResult Delete(Animal animal)
        {
            repositorio.Delete(animal);
            return RedirectToAction("New");
        }
        #endregion

        public IActionResult Details(int id)
        {
            var pre = context.ProcedimentosPreAdocao.Find(id);
            var pos = context.ProcedimentosPosAdocao.Find(id);
            var animal = repositorio.ObterAnimal(id);
            return View(animal);
        }

    }
}
