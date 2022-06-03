using System;

namespace Aeropuertos.Dominio.Interfaces{
  public interface ITransaccion{
    Task GuardarTodosLosCambios();
  }
}
