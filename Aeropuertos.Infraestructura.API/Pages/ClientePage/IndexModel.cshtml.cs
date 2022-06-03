using System;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
using Aeropuertos.Dominio;
using Aeropuertos.Infraestructura.Datos.Contextos;
using Aeropuertos.Aplicaciones.Interfaces;
using Aeropuertos.Aplicaciones.Servicios;
using Aeropuertos.Infraestructura.Datos.Repositorios;
namespace Aeropuertos.Infraestructura.API.Pages.ClientePage{
    public class IndexModel : PageModel
    {
        private readonly BaseContexto baseContexto;
        public IndexModel(BaseContexto _baseContexto)
        {
            baseContexto = _baseContexto;
        }
        private IServicioBase<Cliente,Guid> CrearServicio(){
            ClienteRepositorio repo = new ClienteRepositorio(baseContexto);
            ClienteServicio servicio = new ClienteServicio(repo);    
            return servicio;
        }
        public IList<Cliente>? Clientes { get; set; }


        public async Task OnGetAsync()
        {
            IServicioBase<Cliente,Guid> servicio = CrearServicio();
            Clientes = await servicio.Listar();
        }

        public async Task<IActionResult> OnPostDeleteAsync(Guid id)
        {
            IServicioBase<Cliente,Guid> servicio = CrearServicio();
            await servicio.Eliminar(id);
            return RedirectToPage();
        }
    }
}