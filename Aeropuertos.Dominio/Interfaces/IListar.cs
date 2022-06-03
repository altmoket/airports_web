using System;

namespace Aeropuertos.Dominio.Interfaces{
  public interface IListar<TEntidad, TEntidadID>{
    Task<List<TEntidad>> Listar();

    Task<TEntidad> SeleccionarPorID(TEntidadID entidadId);
  }
}
