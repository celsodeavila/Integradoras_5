using CaoLendario.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CaoLendario.Models.ViewModels
{
    public class AnimalListViewModel
    {
        public Animal animal { get; set; }
        public IEnumerable<Animal> Animais { get; set; }
        public PagingInfo PagingInfo { get; set; }
    }
}
