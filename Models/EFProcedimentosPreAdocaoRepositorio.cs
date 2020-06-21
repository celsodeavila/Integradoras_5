using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CaoLendario.Models;

namespace CaoLendario.Models
{
    public class EFProcedimentosPreAdocaoRepositorio : IProcedimentosPreAdocaoRepositorio
    {
        private ApplicationDbContext context;

        public IQueryable<ProcedimentosPreAdocao> ProcedimentosPreAdocao => context.ProcedimentosPreAdocao;

        public EFProcedimentosPreAdocaoRepositorio(ApplicationDbContext ctx)
        {
            context = ctx;
        }
        public void Create(ProcedimentosPreAdocao procedimentosPreAdocao)
        {
            context.Add(procedimentosPreAdocao);
            context.SaveChanges();
        }

        public void Delete(ProcedimentosPreAdocao procedimentosPreAdocao)
        {
            context.Remove(procedimentosPreAdocao);
            context.SaveChanges();
        }

        public void Edit(ProcedimentosPreAdocao procedimentosPreAdocao)
        {
            context.Entry(procedimentosPreAdocao).State = EntityState.Modified;
            context.SaveChanges();
        }

        public ProcedimentosPreAdocao ObterProcedimentosPreAdocao(int id)
        {
            var procedimentosPreAdocao = context.ProcedimentosPreAdocao.Find(id);
            return procedimentosPreAdocao;
        }
    }
}

