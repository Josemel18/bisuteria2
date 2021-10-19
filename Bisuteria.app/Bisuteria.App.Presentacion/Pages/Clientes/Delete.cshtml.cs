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
    public class DeleteModel : PageModel
    {
         private readonly IRepositorios _appContext;

        [BindProperty]
        public Cliente cliente  { get; set; } 

        public DeleteModel()
        {
            this._appContext  =new Repositorios(new Bisuteria.App.Persistencia.AppRepositorios.AppContext());
        }
        public IActionResult OnGet(int clienteId)
        {
            cliente = _appContext.GetCliente(clienteId);
            if(cliente == null)
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
            if(cliente.id > 0)
            {
               _appContext.DeleteCliente(cliente.id);
            }
            return Page();
        }
    }
}
