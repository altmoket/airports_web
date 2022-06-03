using System;
using Aeropuertos.Dominio;
using Aeropuertos.Dominio.Interfaces.Repositorios;
using Aeropuertos.Aplicaciones.Interfaces;
namespace Aeropuertos.Aplicaciones.Servicios{
    public class ClienteServicio:IServicioBase<Cliente,Guid>{
        private readonly IRepositorioBase<Cliente,Guid> repoCliente;
        public ClienteServicio(IRepositorioBase<Cliente,Guid> _repoCliente)
        {
            repoCliente = _repoCliente; 
        }
        public async Task<Cliente> Agregar(Cliente entidad){
            if(entidad == null)
                throw new ArgumentNullException("El 'Cliente' es requerido");
            var resultCliente = await repoCliente.Agregar(entidad);
            await repoCliente.GuardarTodosLosCambios();
            return resultCliente;
        }
        public async Task Editar(Cliente entidad){
            if(entidad == null)
                throw new ArgumentNullException("El 'Cliente' es requerido");
            await repoCliente.Editar(entidad);
            await repoCliente.GuardarTodosLosCambios();
        }
        public async Task Eliminar(Guid entidadId){
            await repoCliente.Eliminar(entidadId);
            await repoCliente.GuardarTodosLosCambios();
        }
        public Task<List<Cliente>> Listar(){
            return repoCliente.Listar();
        }
        public Task<Cliente> SeleccionarPorID(Guid entidadId){
            return repoCliente.SeleccionarPorID(entidadId);
        }
    }
}