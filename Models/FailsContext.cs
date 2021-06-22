using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace repaso_para_examen__1.Models

{
    public class FailsContext : IdentityDbContext
    {
        public DbSet<Fails> fails { get; set; }
        public DbSet<Comentario> comentario { get; set; }
        public FailsContext(DbContextOptions dco):base (dco){
            
        }

    }
}