using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CaoLendario.Models
{
    public class ProcedimentosPosAdocao
    {
        private string descricao;
        private DateTime data;
        public int ProcedimentosPosAdocaoID { get; set; }

        public string Descricao { get => descricao; set => descricao = value; }
        public DateTime Data { get => data; set => data = value; }
    }
}
