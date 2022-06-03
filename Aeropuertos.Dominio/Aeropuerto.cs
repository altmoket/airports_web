using System;
using System.ComponentModel.DataAnnotations;
namespace Aeropuertos.Dominio{
  public class Aeropuerto{
    [Key]
    public Guid aeropuertoId{get;set;}
    public string direccion{get;set;} = string.Empty;
    public string posicionGeografica{get;set;} = string.Empty;
    public string nombre{get;set;} = string.Empty;
  }
}