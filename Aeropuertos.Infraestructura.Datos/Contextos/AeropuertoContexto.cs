using Microsoft.EntityFrameworkCore;
using Aeropuertos.Dominio;

namespace Aeropuertos.Infraestructura.Datos.Contextos{
    public class AeropuertoContexto : DbContext{
        public DbSet<Aeropuerto> Aeropuerto => Set<Aeropuerto>();
        public AeropuertoContexto(DbContextOptions<AeropuertoContexto> options):base(options){}
    }
}