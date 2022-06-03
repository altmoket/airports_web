using System;

namespace Aeropuertos.Dominio.Interfaces
{
  public interface IEliminar<TEntidadID>{
    Task Eliminar(TEntidadID entidadId);
  }
}
