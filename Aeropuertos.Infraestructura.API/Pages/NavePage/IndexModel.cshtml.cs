using System;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
using Aeropuertos.Dominio;
using Aeropuertos.Infraestructura.Datos.Contextos;
using Aeropuertos.Aplicaciones.Interfaces;
using Aeropuertos.Aplicaciones.Servicios;
using Aeropuertos.Infraestructura.Datos.Repositorios;
namespace Aeropuertos.Infraestructura.API.Pages.NavePage{
    public class IndexModel : PageModel
    {
        private readonly BaseContexto baseContexto;
        public IndexModel(BaseContexto _baseContexto)
        {
            baseContexto = _baseContexto;
        }
        private IServicioBase<Nave,Guid> CrearServicio(){
            NaveRepositorio repo = new NaveRepositorio(baseContexto);
            NaveServicio servicio = new NaveServicio(repo);    
            return servicio;
        }
        public IList<Nave>? Naves { get; set; }


        public async Task OnGetAsync()
        {
            IServicioBase<Nave,Guid> servicio = CrearServicio();
            Naves = await servicio.Listar();
        }

        public async Task<IActionResult> OnPostDeleteAsync(Guid id)
        {
            IServicioBase<Nave,Guid> servicio = CrearServicio();
            await servicio.Eliminar(id);
            return RedirectToPage();
        }
        public async Task CargarDB(){
            int[] capacidades = {200,100,150,400,100,130,88,23,5};
            string[] clasificaciones = {
                "Aeroplano", "Avion", "AeroplanoAmarillo", "AeroplanoVerdePollito", "A-100",
                "B-13","T-50","B-234","A-K"
            };
            int[] numeroTripulantes= {200,100,150,400,100,130,88,23,5};
            int[] totalPlazas= {200,100,150,400,100,130,88,23,5};
            Nave nave;
            IServicioBase<Nave,Guid> servicio = CrearServicio();
            for (int i = 0; i < 9; i++)
            {
                nave = new Nave();
                nave.capacidad = capacidades[i];
                nave.clasificacion = clasificaciones[i];
                nave.numeroTripulantes = numeroTripulantes[i];
                nave.totalPlazasParaPasajeros = totalPlazas[i];
                await servicio.Agregar(nave);
            }
        }
    }

}