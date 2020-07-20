using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CaoLendario.Models.ViewModels
{
    public class AdotantesListViewModel
    {
        public Adotante adotante { get; set; }
        public IEnumerable<Adotante> adotantes { get; set; }
        public PagingInfo PagingInfo { get; set; }


    }
}
