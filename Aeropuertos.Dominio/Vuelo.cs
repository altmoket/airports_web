using System;

namespace Aeropuertos.Dominio{
  public class Vuelo{
      public Guid aeropuertoId{get;set;}
      public Guid naveMatricula{get;set;}
      public DateTime fechaEntrada{get;set;}
      public DateTime fechaSalida{get;set;}
      public string estadoNave{get;set;} = string.Empty;
      public Aeropuerto aeropuerto{get;set;} = null!;
      public Nave nave{get;set;} = null!;
  }
}