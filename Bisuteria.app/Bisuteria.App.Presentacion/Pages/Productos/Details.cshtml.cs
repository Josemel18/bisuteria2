using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using Bisuteria.App.Dominio;
using Bisuteria.App.Persistencia.AppRepositorios;

namespace Bisuteria.App.Presentacion.Pages
{
    public class DetailsModel : PageModel
    {
        private readonly IRepositorios _appContext;
        public Producto producto { get; set; }

        public DetailsModel()
        {
            this._appContext=new Repositorios(new Bisuteria.App.Persistencia.AppRepositorios.AppContext());
        }
        public IActionResult OnGet(int productoId)
        {
            producto = _appContext.GetProducto(productoId);
            if(producto == null)
            {
                return RedirectToPage("./NotFound");
            }
            else
            return Page();
        }

        public IActionResult OnPost()
        {
            if(!ModelState.IsValid)
            {
                return Page();
            }
            if(producto.id > 0)
            {
               _appContext.DeleteProducto(producto.id);
            }
            return Page();
        }
    }
}