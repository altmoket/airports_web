using System;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
using Aeropuertos.Dominio;
using Aeropuertos.Infraestructura.Datos.Contextos;
using Aeropuertos.Aplicaciones.Interfaces;
using Aeropuertos.Aplicaciones.Servicios;
using Aeropuertos.Infraestructura.Datos.Repositorios;
namespace Aeropuertos.Infraestructura.API.Pages.AeropuertoPage{

    public class CreateModel : PageModel
    {
        private readonly BaseContexto baseContexto;
        public CreateModel(BaseContexto _baseContexto)
        {
            baseContexto = _baseContexto;
        }
        private IServicioBase<Aeropuerto,Guid> CrearServicio(){
            AeropuertoRepositorio repo = new AeropuertoRepositorio(baseContexto);
            AeropuertoServicio servicio = new AeropuertoServicio(repo);    
            return servicio;
        }
        public IList<Aeropuerto>? Aeropuertos { get; set; }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Aeropuerto? Aeropuerto { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            IServicioBase<Aeropuerto,Guid> servicio = CrearServicio();

            if (Aeropuerto != null) await servicio.Agregar(Aeropuerto);

            return RedirectToPage("../AeropuertoPage/Index");
        }
    }
}