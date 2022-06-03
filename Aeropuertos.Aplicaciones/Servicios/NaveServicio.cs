using System;
using Aeropuertos.Dominio;
using Aeropuertos.Dominio.Interfaces.Repositorios;
using Aeropuertos.Aplicaciones.Interfaces;
namespace Aeropuertos.Aplicaciones.Servicios{
    public class NaveServicio:IServicioBase<Nave,Guid>{
        private readonly IRepositorioBase<Nave,Guid> repoNave;
        public NaveServicio(IRepositorioBase<Nave,Guid> _repoNave)
        {
            repoNave = _repoNave; 
        }
        public async Task<Nave> Agregar(Nave entidad){
            if(entidad == null)
                throw new ArgumentNullException("El 'Nave' es requerido");
            var resultNave = await repoNave.Agregar(entidad);
            await repoNave.GuardarTodosLosCambios();
            return resultNave;
        }
        public async Task Editar(Nave entidad){
            if(entidad == null)
                throw new ArgumentNullException("El 'Nave' es requerido");
            await repoNave.Editar(entidad);
            await repoNave.GuardarTodosLosCambios();
        }
        public async Task Eliminar(Guid entidadId){
            await repoNave.Eliminar(entidadId);
            await repoNave.GuardarTodosLosCambios();
        }
        public async Task<List<Nave>> Listar(){
            return await repoNave.Listar();
        }
        public Task<Nave> SeleccionarPorID(Guid entidadId){
            return repoNave.SeleccionarPorID(entidadId);
        }
    }
}