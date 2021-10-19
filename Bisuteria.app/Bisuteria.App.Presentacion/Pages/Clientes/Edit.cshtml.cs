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
    public class EditModel : PageModel
    { 
        private readonly IRepositorios _appContext;

        [BindProperty]
        public Cliente cliente  { get; set; } 

        public EditModel()
        {
            this._appContext  =new Repositorios(new Bisuteria.App.Persistencia.AppRepositorios.AppContext());
        }
        public IActionResult OnGet(int? clienteId)
        {
            if (clienteId.HasValue)
            {
                cliente = _appContext.GetCliente(clienteId.Value);
            }
            else
            {
                cliente = new Cliente();
            }

            if (cliente == null)
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
               cliente = _appContext.UpdateCliente( cliente );               
            }
            else
            {
               _appContext.AddCliente( cliente );
            }
            return Page();
        }
    }
}
