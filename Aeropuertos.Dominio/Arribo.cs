using System;

namespace Aeropuertos.Dominio{
  public class Arribo{
      public Guid clienteId{get;set;}
      public Guid aeropuertoId{get;set;}
      public Guid naveMatricula{get;set;}
      public DateTime fechaEntrada{get;set;}
      public string caracter{get;set;} = string.Empty;
      public Aeropuerto aeropuerto{get;set;} = null!;
      public Nave nave{get;set;} = null!;
      public Cliente cliente{get;set;} = null!;
  }
}