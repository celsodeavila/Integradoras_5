using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CaoLendario.Models
{
    public class ProcedimentosPreAdocao
    {
        public string descricao { get; set; }
        public DateTime data { get; set; }
        public int ProcedimentosPreAdocaoID { get; set; }
        public int AnimalID { get; set; }
        public Animal Animal { get; set; }
    }
}
