using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CaoLendario.Models
{
	public class MedicoVeterinario : User
	{
        public string CRMV { get; set; }
        public DateTime Data { get; set; }

    }
}
