using System;
using Aeropuertos.Dominio.Interfaces;
namespace Aeropuertos.Dominio.Interfaces.Repositorios{
  public interface IRepositorioMovimiento<TEntidad, TEntidadID>: IAgregar<TEntidad>, IListar<TEntidad,TEntidadID>, ITransaccion
  {
    void Anular(TEntidadID entidadId);
  }
}


