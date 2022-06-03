using System;
using System.Linq;
using Aeropuertos.Dominio;
using Aeropuertos.Dominio.Interfaces.Repositorios;
using Aeropuertos.Infraestructura.Datos.Contextos;
using Microsoft.EntityFrameworkCore;

namespace Aeropuertos.Infraestructura.Datos.Repositorios{
    public class NaveRepositorio: IRepositorioBase<Nave,Guid>{
        private BaseContexto db;
        public NaveRepositorio(BaseContexto _db){
            db = _db;
        }
        public async Task<Nave> Agregar(Nave entidad){
            entidad.numeroMatricula = Guid.NewGuid();
            await db.Naves.AddAsync(entidad);
            await GuardarTodosLosCambios();
            return entidad;
        } 
        public async Task Editar(Nave entidad){
            var naveSeleccionada = await SeleccionarPorID(entidad.numeroMatricula);
            if(naveSeleccionada != null){
                naveSeleccionada.capacidad = entidad.capacidad;
                naveSeleccionada.clasificacion = entidad.clasificacion;
                naveSeleccionada.numeroTripulantes = entidad.numeroTripulantes;
                naveSeleccionada.totalPlazasParaPasajeros = entidad.totalPlazasParaPasajeros;
                db.Entry(naveSeleccionada).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            }
        }
        public async Task Eliminar(Guid numeroMatricula){
            var naveSeleccionada = await SeleccionarPorID(numeroMatricula);
            if(naveSeleccionada != null){
                db.Naves.Remove(naveSeleccionada);
                await GuardarTodosLosCambios();
            }
        }
        public async Task GuardarTodosLosCambios(){
            await db.SaveChangesAsync();
        }
        public async Task<List<Nave>> Listar(){
            List<Nave> naves = await db.Naves.ToListAsync();
            return naves;
        }
        public async Task<Nave> SeleccionarPorID(Guid numeroMatricula){
            var naveSeleccionada = await db.Naves.FirstOrDefaultAsync(nave=>nave.numeroMatricula==numeroMatricula);
            return naveSeleccionada!;
        }
    }
}
