using System;
using Aeropuertos.Dominio.Interfaces;
namespace Aeropuertos.Aplicaciones.Interfaces{
    public interface IServicioBase<TEntidad,TEntidadID>
    : IAgregar<TEntidad>, IEditar<TEntidad>, IEliminar<TEntidadID>, IListar<TEntidad, TEntidadID>{

    }
}