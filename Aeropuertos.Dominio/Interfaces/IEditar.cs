using System;

namespace Aeropuertos.Dominio.Interfaces
{
  public interface IEditar<TEntidad>{
    Task Editar(TEntidad entidad);
    
  }
}
