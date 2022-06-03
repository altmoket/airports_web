using System;
using System.ComponentModel.DataAnnotations;
namespace Aeropuertos.Dominio{
  public class Nave{
    [Key]
    public Guid numeroMatricula{get;set;}
    public string clasificacion{get;set;} = string.Empty;
    public int capacidad{get;set;}
    public int numeroTripulantes{get;set;}
    public int totalPlazasParaPasajeros{get;set;}
  }
}
