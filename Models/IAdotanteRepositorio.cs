using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CaoLendario.Models
{
	public interface IAdotanteRepositorio
	{
		IQueryable<Adotante> Adotantes { get; }
		public Adotante ObterAdotante(int id);
		public void Create(Adotante adotante);
		public void Edit(Adotante adotante);
		public void Delete(Adotante adotante);

	}
}
