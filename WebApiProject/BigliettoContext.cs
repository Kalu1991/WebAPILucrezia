using Microsoft.EntityFrameworkCore;
using WebApiProject.Models;

namespace WebApiProject
{
    public class BigliettoContext : DbContext
    {
        public BigliettoContext(DbContextOptions<BigliettoContext> options): base(options)
        {
        }

        public DbSet<BigliettoConcerto> Biglietti { get; set; }
    }
}
