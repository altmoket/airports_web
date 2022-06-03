using System;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
using Aeropuertos.Dominio;
using Aeropuertos.Infraestructura.Datos.Contextos;
using Aeropuertos.Aplicaciones.Interfaces;
using Aeropuertos.Aplicaciones.Servicios;
using Aeropuertos.Infraestructura.Datos.Repositorios;
namespace Aeropuertos.Infraestructura.API.Pages.NavePage{

    public class CreateModel : PageModel
    {
        private readonly BaseContexto baseContexto;
        public CreateModel(BaseContexto _baseContexto)
        {
            baseContexto = _baseContexto;
        }
        private IServicioBase<Nave,Guid> CrearServicio(){
            NaveRepositorio repo = new NaveRepositorio(baseContexto);
            NaveServicio servicio = new NaveServicio(repo);    
            return servicio;
        }
        public IList<Nave>? Naves { get; set; }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Nave? Nave { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            IServicioBase<Nave,Guid> servicio = CrearServicio();

            if (Nave != null) await servicio.Agregar(Nave);

            return RedirectToPage("../NavePage/Index");
        }
    }
}