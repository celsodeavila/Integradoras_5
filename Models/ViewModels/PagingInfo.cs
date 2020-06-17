using System;

namespace CaoLendario.Models.ViewModels
{
    public class PagingInfo
    {
        public int TotalItens { get; set; }
        public int ItensPorPagina { get; set; }
        public int PaginaAtual { get; set; }
        public int TotalDePaginas => (int)Math.Ceiling((decimal)TotalItens / ItensPorPagina);
    }
}