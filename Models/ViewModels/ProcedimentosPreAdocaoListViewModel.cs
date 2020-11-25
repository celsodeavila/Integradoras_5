using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CaoLendario.Models.ViewModels
{
    public class ProcedimentosPreAdocaoListViewModel
    {
        public ProcedimentosPreAdocao procedimentoPreAdocao { get; set; }
        public IEnumerable<ProcedimentosPreAdocao> ProcedimentosPreAdocao { get; set; }
        public PagingInfo PagingInfo { get; set; }
    }
}
