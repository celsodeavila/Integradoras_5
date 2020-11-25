using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace CaoLendario.Models
{
    public class EFProcedimentosPosAdocaoRepositorio : IProcedimentosPosAdocaoRepositorio
    {
        private ApplicationDbContext context;
        
        public EFProcedimentosPosAdocaoRepositorio(ApplicationDbContext ctx)
        {
            context = ctx;
        }
        public IQueryable<ProcedimentosPosAdocao> ProcedimentosPosAdocao => context.ProcedimentosPosAdocao;

        public void Create(ProcedimentosPosAdocao procedimentosPosAdocao)
        {
            context.Add(procedimentosPosAdocao);
            context.SaveChanges();
        }

        public void Delete(ProcedimentosPosAdocao procedimentosPosAdocao)
        {
            context.Remove(procedimentosPosAdocao);
            context.SaveChanges();
        }

        public void Edit(ProcedimentosPosAdocao procedimentosPosAdocao)
        {
            context.Entry(procedimentosPosAdocao).State = EntityState.Modified;
            context.SaveChanges();
        }

        public ProcedimentosPosAdocao ObterProcedimentosPosAdocao(int id)
        {
            var procedimentosposadocao = context.ProcedimentosPosAdocao.Find(id);
            return procedimentosposadocao;
        }
    }
}
