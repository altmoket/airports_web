using System;
using Aeropuertos.Dominio.Interfaces;
namespace Aeropuertos.Dominio.Interfaces.Repositorios{
  public interface IRepositorioBase<TEntidad, TEntidadID>
    : IAgregar<TEntidad>, IEditar<TEntidad>, IEliminar<TEntidadID>, IListar<TEntidad,TEntidadID>, ITransaccion{
  }
}
