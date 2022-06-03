using System;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
using Aeropuertos.Dominio;
using Aeropuertos.Infraestructura.Datos.Contextos;
using Aeropuertos.Aplicaciones.Interfaces;
using Aeropuertos.Aplicaciones.Servicios;
using Aeropuertos.Infraestructura.Datos.Repositorios;
using Microsoft.EntityFrameworkCore;

namespace Aeropuertos.Infraestructura.API.Pages.NavePage{
    public class EditModel : PageModel
    {
        private readonly BaseContexto baseContexto;
        public EditModel(BaseContexto _baseContexto)
        {
            baseContexto = _baseContexto;
        }
        private IServicioBase<Nave,Guid> CrearServicio(){
            NaveRepositorio repo = new NaveRepositorio(baseContexto);
            NaveServicio servicio = new NaveServicio(repo);    
            return servicio;
        }
        [BindProperty]
        public Nave? Nave{ get; set; }

        public async Task<IActionResult> OnGetAsync(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }
            IServicioBase<Nave,Guid>servicio = CrearServicio();
            Nave = await servicio.SeleccionarPorID(id);
            
            if (Nave == null)
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

            if (Nave != null)
            {
                IServicioBase<Nave,Guid>servicio = CrearServicio();

                try
                {
                    await servicio.Editar(Nave);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NaveExists(Nave.numeroMatricula))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }

            return RedirectToPage("../NavePage/Index");
        }

        private bool NaveExists(Guid id)
        {
            return baseContexto.Naves.Any(e => e.numeroMatricula == id);
        }
    }

}