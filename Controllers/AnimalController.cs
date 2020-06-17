using CaoLendario.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace CaoLendario.Controllers
{
    public class AnimalControllers : Controller
    {
        private ApplicationDbContext context;

        private IAnimalRepositorio repositorio;
        public AnimalControllers(IAnimalRepositorio repo, ApplicationDbContext ctx)
        {
            repositorio = repo;
            context = ctx;
        }

        public ViewResult List() => View(repositorio.Animais);

        #region Cadastro de Animais
        [HttpGet]
        public IActionResult New()
        {
            return View();
        }
        [HttpPost]
        public IActionResult New(Animal animal)
        {
            repositorio.Create(animal);
            return RedirectToAction("List");
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
            return RedirectToAction("List");
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
            return RedirectToAction("List");
        }
        #endregion

        public IActionResult Details(int id)
        {
            var animal = repositorio.ObterAnimal(id);
            return View(animal);
        }

    }
}
