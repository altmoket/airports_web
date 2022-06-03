using System;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
using Aeropuertos.Dominio;
using Aeropuertos.Infraestructura.Datos.Contextos;
using Aeropuertos.Aplicaciones.Interfaces;
using Aeropuertos.Aplicaciones.Servicios;
using Aeropuertos.Infraestructura.Datos.Repositorios;
using Microsoft.EntityFrameworkCore;

namespace Aeropuertos.Infraestructura.API.Pages.AeropuertoPage{
    public class EditModel : PageModel
    {
        private readonly BaseContexto baseContexto;
        public EditModel(BaseContexto _baseContexto)
        {
            baseContexto = _baseContexto;
        }
        private IServicioBase<Aeropuerto,Guid> CrearServicio(){
            AeropuertoRepositorio repo = new AeropuertoRepositorio(baseContexto);
            AeropuertoServicio servicio = new AeropuertoServicio(repo);    
            return servicio;
        }
        [BindProperty]
        public Aeropuerto? Aeropuerto{ get; set; }

        public async Task<IActionResult> OnGetAsync(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }
            IServicioBase<Aeropuerto,Guid>servicio = CrearServicio();
            Aeropuerto = await servicio.SeleccionarPorID(id);
            
            if (Aeropuerto == null)
            {
                return NotFound();
            }
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (Aeropuerto != null)
            {
                IServicioBase<Aeropuerto,Guid>servicio = CrearServicio();

                try
                {
                    await servicio.Editar(Aeropuerto);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AeropuertoExists(Aeropuerto.aeropuertoId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }

            return RedirectToPage("../AeropuertoPage/Index");
        }

        private bool AeropuertoExists(Guid id)
        {
            return baseContexto.Aeropuertos.Any(e => e.aeropuertoId == id);
        }
    }

}