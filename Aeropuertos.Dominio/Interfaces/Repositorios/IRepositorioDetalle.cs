using System;

using Aeropuertos.Dominio.Interfaces;

namespace Aeropuertos.Dominio.Interfaces.Repositorios{
  public interface IRepositorioDetalle<TEntidad,IMovimientoID>:IAgregar<TEntidad>, ITransaccion{
  }
}
