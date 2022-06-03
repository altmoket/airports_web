
using Microsoft.EntityFrameworkCore;
using Aeropuertos.Dominio;

namespace Aeropuertos.Infraestructura.Datos.Contextos{
    public class ClienteContexto : DbContext{
        public DbSet<Cliente> Cliente => Set<Cliente>();
        public ClienteContexto(DbContextOptions<ClienteContexto> options):base(options){}
    }
}