using System;

using System.ComponentModel.DataAnnotations;
namespace Aeropuertos.Dominio{
  public class Cliente{
    [Key]
    public Guid clienteId{get;set;}
    public string nombre{get;set;} = string.Empty;
    public string tipo{get;set;} = string.Empty;
    public string nacionalidad{get;set;} = string.Empty;
  }
}