using CaoLendario.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CaoLendario.Models.ViewModels
{
    public class ProcedimentosPosAdocaoListViewModel
    {
        public ProcedimentosPosAdocao procedimentosPosAdocao { get; set; }
        public IEnumerable<ProcedimentosPosAdocao> ProcedimentosPosAdocao { get; set; }
        public PagingInfo PagingInfo { get; set; }
    }
}
