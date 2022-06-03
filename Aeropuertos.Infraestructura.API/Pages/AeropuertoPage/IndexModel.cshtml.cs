using System;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
using Aeropuertos.Dominio;
using Aeropuertos.Infraestructura.Datos.Contextos;
using Aeropuertos.Aplicaciones.Interfaces;
using Aeropuertos.Aplicaciones.Servicios;
using Aeropuertos.Infraestructura.Datos.Repositorios;
namespace Aeropuertos.Infraestructura.API.Pages.AeropuertoPage{
    public class IndexModel : PageModel
    {
        private readonly BaseContexto baseContexto;
        public IndexModel(BaseContexto _baseContexto)
        {
            baseContexto = _baseContexto;
        }
        private IServicioBase<Aeropuerto,Guid> CrearServicio(){
            AeropuertoRepositorio repo = new AeropuertoRepositorio(baseContexto);
            AeropuertoServicio servicio = new AeropuertoServicio(repo);    
            return servicio;
        }
        public IList<Aeropuerto>? Aeropuertos { get; set; }


        public async Task OnGetAsync()
        {
            IServicioBase<Aeropuerto,Guid> servicio = CrearServicio();
            Aeropuertos = await servicio.Listar();
        }

        public async Task<IActionResult> OnPostDeleteAsync(Guid id)
        {
            IServicioBase<Aeropuerto,Guid> servicio = CrearServicio();
            await servicio.Eliminar(id);
            return RedirectToPage();
        }
    }
}