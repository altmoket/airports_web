using System;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
using Aeropuertos.Dominio;
using Aeropuertos.Infraestructura.Datos.Contextos;
using Aeropuertos.Aplicaciones.Interfaces;
using Aeropuertos.Aplicaciones.Servicios;
using Aeropuertos.Infraestructura.Datos.Repositorios;
using Microsoft.EntityFrameworkCore;

namespace Aeropuertos.Infraestructura.API.Pages.ClientePage{
    public class EditModel : PageModel
    {
        private readonly BaseContexto baseContexto;
        public EditModel(BaseContexto _baseContexto)
        {
            baseContexto = _baseContexto;
        }
        private IServicioBase<Cliente,Guid> CrearServicio(){
            ClienteRepositorio repo = new ClienteRepositorio(baseContexto);
            ClienteServicio servicio = new ClienteServicio(repo);    
            return servicio;
        }
        [BindProperty]
        public Cliente? Cliente{ get; set; }

        public async Task<IActionResult> OnGetAsync(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }
            IServicioBase<Cliente,Guid>servicio = CrearServicio();
            Cliente = await servicio.SeleccionarPorID(id);
            
            if (Cliente == null)
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

            if (Cliente != null)
            {
                IServicioBase<Cliente,Guid>servicio = CrearServicio();

                try
                {
                    await servicio.Editar(Cliente);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClienteExists(Cliente.clienteId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }

            return RedirectToPage("../ClientePage/Index");
        }

        private bool ClienteExists(Guid id)
        {
            return baseContexto.Clientes.Any(e => e.clienteId == id);
        }
    }

}