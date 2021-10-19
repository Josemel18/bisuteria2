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
    public class ListModel : PageModel
    {
        private readonly IRepositorios _appContext;
        public IEnumerable<Cliente> clientes {get; set;} 

        public string searchString;     

        public ListModel()
        {
            this._appContext = new Repositorios(new Bisuteria.App.Persistencia.AppRepositorios.AppContext());
        }
        public void OnGet()
        {
            clientes =_appContext.GetAllClientes(searchString);
        }

        public IActionResult OnPost(string? searchString)
        {
            if(!ModelState.IsValid)
            {
                return Page();
            }
            clientes = _appContext.GetAllClientes(searchString);
            return Page();
        }
    }
}
