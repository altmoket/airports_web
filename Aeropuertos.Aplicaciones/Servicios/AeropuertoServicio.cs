using System;
using Aeropuertos.Dominio;
using Aeropuertos.Dominio.Interfaces.Repositorios;
using Aeropuertos.Aplicaciones.Interfaces;
namespace Aeropuertos.Aplicaciones.Servicios{
    public class AeropuertoServicio:IServicioBase<Aeropuerto,Guid>{
        private readonly IRepositorioBase<Aeropuerto,Guid> repoAeropuerto;
        public AeropuertoServicio(IRepositorioBase<Aeropuerto,Guid> _repoAeropuerto)
        {
            repoAeropuerto = _repoAeropuerto; 
        }
        public async Task<Aeropuerto> Agregar(Aeropuerto entidad){
            if(entidad == null)
                throw new ArgumentNullException("El 'Aeropuerto' es requerido");
            var resultAeropuerto = await repoAeropuerto.Agregar(entidad);
            await repoAeropuerto.GuardarTodosLosCambios();
            return resultAeropuerto;
        }
        public async Task Editar(Aeropuerto entidad){
            if(entidad == null)
                throw new ArgumentNullException("El 'Aeropuerto' es requerido");
            await repoAeropuerto.Editar(entidad);
            await repoAeropuerto.GuardarTodosLosCambios();
        }
        public async Task Eliminar(Guid entidadId){
            await repoAeropuerto.Eliminar(entidadId);
            await repoAeropuerto.GuardarTodosLosCambios();
        }
        public async Task<List<Aeropuerto>> Listar(){
            return await repoAeropuerto.Listar();
        }
        public async Task<Aeropuerto> SeleccionarPorID(Guid entidadId){
            return await repoAeropuerto.SeleccionarPorID(entidadId);
        }

    }
}