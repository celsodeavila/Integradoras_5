using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace CaoLendario.Models
{
	public class EFAdotanteRepositorio:IAdotanteRepositorio
	{
        private ApplicationDbContext context;

        public EFAdotanteRepositorio(ApplicationDbContext ctx)
        {
            context = ctx;
        }

        public IQueryable<Adotante> Adotantes => context.Adotantes;

        public void Create(Adotante adotante)
        {
            context.Add(adotante);
            context.SaveChanges();
        }
        public Adotante ObterAdotante(int id)
        {
            var adotante = context.Adotantes.FirstOrDefault();
            return adotante;
        }
        public void Edit(Adotante adotante)
        {
            context.Entry(adotante).State = EntityState.Modified;
            context.SaveChanges();
        }
        public void Delete(Adotante adotante)
        {
            context.Remove(adotante);
            context.SaveChanges();
        }
    }
}
