using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using CaoLendario.Models.ViewModels;

namespace CaoLendario.Infraestrutura
{
    [HtmlTargetElement("div", Attributes = "page-model")]
    public class PageLinkTagHelper : TagHelper
    {
        private IUrlHelperFactory urlHelperFactory;
        public PageLinkTagHelper(IUrlHelperFactory helperFactory)
        {
            urlHelperFactory = helperFactory;
        }
        [ViewContext]
        [HtmlAttributeNotBound]
        public ViewContext ViewContext { get; set; }
        public PagingInfo PageModel { get; set; }
        public string PageAction { get; set; }

        //definições para s atributos da tag <a> correspondentes aos links da paginação
        public bool PageClassesEnabled { get; set; } = false;
        public string PageClass { get; set; }
        public string PageClassNormal { get; set; }
        public string PageClassSelected { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput
       output)
        {
            //Elementos para o renderizador HTML ViewContext
            IUrlHelper urlHelper = urlHelperFactory.GetUrlHelper(ViewContext);

            //Modificar a renderização do elemento div da View
            TagBuilder result = new TagBuilder("div");
            //insere os links para a paginação da View
            for (int i = 1; i <= PageModel.TotalDePaginas; i++)
            {
                //insere um link com o atributo href correspondente à paginação
                TagBuilder tag = new TagBuilder("a");
                tag.Attributes["href"] = urlHelper.Action(PageAction, new
                {
                    pag = i,
                    PageModel.filter,
                    PageModel.query,
                });

                //ações para a formatação dos números de páginas na div de paginação
                if (PageClassesEnabled)
                {
                    tag.AddCssClass(PageClass);
                    tag.AddCssClass(i == PageModel.PaginaAtual ?
                    PageClassSelected : PageClassNormal);
                }
                //insere o número da página
                tag.InnerHtml.Append(i.ToString());
                //insere o link
                result.InnerHtml.AppendHtml(tag);
            }
            //insere a div com os links da paginação
            output.Content.AppendHtml(result.InnerHtml);
        }
    }
}
