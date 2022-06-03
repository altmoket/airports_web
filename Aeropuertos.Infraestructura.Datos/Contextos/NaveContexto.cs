using Microsoft.EntityFrameworkCore;
using Aeropuertos.Dominio;

namespace Aeropuertos.Infraestructura.Datos.Contextos{
    public class NaveContexto : DbContext{
        public DbSet<Nave> Naves => Set<Nave>();
        public NaveContexto(DbContextOptions<NaveContexto> options):base(options){}
    }
}