using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CaoLendario.Models
{
    public class ProcedimentosPreAdocao
    {
        private string descricao;
        private DateTime data;
        public int ProcedimentosPreAdocaoID { get; set; }

        public string Descricao { get => descricao; set => descricao = value; }
        public DateTime Data { get => data; set => data = value; }
    }
}
