using System;
using Aeropuertos.Dominio.Interfaces;
namespace Aeropuertos.Aplicaciones.Interfaces{
    public interface IServicioMovimiento<TEntidad, TEntidadID>
    : IAgregar<TEntidad>, IListar<TEntidad,TEntidadID>{
        void Anular(TEntidadID entidadId);
    }
}