using System;

namespace Aeropuertos.Dominio.Interfaces
{
  public interface IAgregar<TEntidad>{
    Task<TEntidad> Agregar(TEntidad entidad);
  }
}
