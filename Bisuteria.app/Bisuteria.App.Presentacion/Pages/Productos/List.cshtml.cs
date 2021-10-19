using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using Bisuteria.App.Dominio;
using Bisuteria.App.Persistencia.AppRepositorios;

namespace Bisuteria.App.Presentacion
{
    public class ListModel : PageModel
    {
        private readonly IRepositorios _appContext;
        public IEnumerable<Producto> productos {get; set;} 

        public string searchString;     

        public ListModel()
        {
            this._appContext = new Repositorios(new Bisuteria.App.Persistencia.AppRepositorios.AppContext());
        }
        public void OnGet()
        {
            productos =_appContext.GetAllProductos(searchString);
        }

        public IActionResult OnPost(string? searchString)
        {
            if(!ModelState.IsValid)
            {
                return Page();
            }
            productos = _appContext.GetAllProductos(searchString);
            return Page();
        }
    }
}