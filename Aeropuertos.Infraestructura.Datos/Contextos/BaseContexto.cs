using Microsoft.EntityFrameworkCore;
using Aeropuertos.Dominio;

namespace Aeropuertos.Infraestructura.Datos.Contextos{
    public class BaseContexto : DbContext{
        public DbSet<Nave> Naves => Set<Nave>();
        public DbSet<Aeropuerto> Aeropuertos=> Set<Aeropuerto>();
        public DbSet<Cliente> Clientes => Set<Cliente>();
        public BaseContexto(DbContextOptions<BaseContexto> options):base(options){}
    }
}