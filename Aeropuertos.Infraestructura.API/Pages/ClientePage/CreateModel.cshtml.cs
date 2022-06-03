using System;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
using Aeropuertos.Dominio;
using Aeropuertos.Infraestructura.Datos.Contextos;
using Aeropuertos.Aplicaciones.Interfaces;
using Aeropuertos.Aplicaciones.Servicios;
using Aeropuertos.Infraestructura.Datos.Repositorios;
namespace Aeropuertos.Infraestructura.API.Pages.ClientePage{

    public class CreateModel : PageModel
    {
        private readonly BaseContexto baseContexto;
        public CreateModel(BaseContexto _baseContexto)
        {
            baseContexto = _baseContexto;
        }
        private IServicioBase<Cliente,Guid> CrearServicio(){
            ClienteRepositorio repo = new ClienteRepositorio(baseContexto);
            ClienteServicio servicio = new ClienteServicio(repo);    
            return servicio;
        }
        public IList<Cliente>? Clientes { get; set; }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Cliente? Cliente { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            IServicioBase<Cliente,Guid> servicio = CrearServicio();

            if (Cliente != null) await servicio.Agregar(Cliente);

            return RedirectToPage("../ClientePage/Index");
        }
    }
}