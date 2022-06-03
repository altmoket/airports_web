using System;
using System.Linq;
using Aeropuertos.Dominio;
using Aeropuertos.Dominio.Interfaces.Repositorios;
using Aeropuertos.Infraestructura.Datos.Contextos;
using Microsoft.EntityFrameworkCore;

namespace Aeropuertos.Infraestructura.Datos.Repositorios{
    public class AeropuertoRepositorio: IRepositorioBase<Aeropuerto,Guid>{
        private BaseContexto db;
        public AeropuertoRepositorio(BaseContexto _db){
            db = _db;
        }
        public async Task<Aeropuerto> Agregar(Aeropuerto entidad){
            entidad.aeropuertoId = Guid.NewGuid();
            await db.Aeropuertos.AddAsync(entidad);
            await GuardarTodosLosCambios();
            return entidad;
        } 
        public async Task Editar(Aeropuerto entidad){
            var aeropuertoseleccionado = await SeleccionarPorID(entidad.aeropuertoId);
            if(aeropuertoseleccionado != null){
                aeropuertoseleccionado.nombre = entidad.nombre;
                aeropuertoseleccionado.direccion= entidad.direccion;
                aeropuertoseleccionado.posicionGeografica = entidad.posicionGeografica;
                db.Entry(aeropuertoseleccionado).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            }
        }
        public async Task Eliminar(Guid numeroMatricula){
            var aeropuertoseleccionado = await SeleccionarPorID(numeroMatricula);
            if(aeropuertoseleccionado != null){
                db.Aeropuertos.Remove(aeropuertoseleccionado);
                await GuardarTodosLosCambios();
            }
        }
        public async Task GuardarTodosLosCambios(){
            await db.SaveChangesAsync();
        }
        public async Task<List<Aeropuerto>> Listar(){
            List<Aeropuerto> aeropuertos = await db.Aeropuertos.ToListAsync();
            return aeropuertos;
        }
        public async Task<Aeropuerto> SeleccionarPorID(Guid aeropuertoId){
            var aeropuertoseleccionado = await db.Aeropuertos.FirstOrDefaultAsync(aeropuerto=>aeropuerto.aeropuertoId==aeropuertoId);
            return aeropuertoseleccionado!;
        }
    }
}
