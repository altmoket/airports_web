using System;
using System.Linq;
using Aeropuertos.Dominio;
using Aeropuertos.Dominio.Interfaces.Repositorios;
using Aeropuertos.Infraestructura.Datos.Contextos;
using Microsoft.EntityFrameworkCore;

namespace Aeropuertos.Infraestructura.Datos.Repositorios{
    public class ClienteRepositorio: IRepositorioBase<Cliente,Guid>{
        private BaseContexto db;
        public ClienteRepositorio(BaseContexto _db){
            db = _db;
        }
        public async Task<Cliente> Agregar(Cliente entidad){
            entidad.clienteId = Guid.NewGuid();
            await db.Clientes.AddAsync(entidad);
            await GuardarTodosLosCambios();
            return entidad;
        } 
        public async Task Editar(Cliente entidad){
            var clienteseleccionado = await SeleccionarPorID(entidad.clienteId);
            if(clienteseleccionado != null){
                clienteseleccionado.nombre = entidad.nombre;
                clienteseleccionado.nacionalidad= entidad.nacionalidad;
                clienteseleccionado.tipo = entidad.tipo;
                db.Entry(clienteseleccionado).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            }
        }
        public async Task Eliminar(Guid numeroMatricula){
            var clienteseleccionado = await SeleccionarPorID(numeroMatricula);
            if(clienteseleccionado != null){
                db.Clientes.Remove(clienteseleccionado);
                await GuardarTodosLosCambios();
            }
        }
        public async Task GuardarTodosLosCambios(){
            await db.SaveChangesAsync();
        }
        public async Task<List<Cliente>> Listar(){
            List<Cliente> clientes = await db.Clientes.ToListAsync();
            return clientes;
        }
        public async Task<Cliente> SeleccionarPorID(Guid clienteId){
            var clienteseleccionado = await db.Clientes.FirstOrDefaultAsync(cliente=>cliente.clienteId==clienteId);
            return clienteseleccionado!;
        }
    }
}
