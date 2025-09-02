using AppMultiUsos.Modelos.CalculadoraDivisas;
using CalculadoraDePrestamos.Modelos.CalculadoraPrestamos;
using CalculadoraDePrestamos.Modelos.CalculadoraPrestamosUsuarios;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CalculadoraDePrestamos.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<SolicitudPrestamoUsuario>()
                .Property(x => x.Monto)
                .HasColumnType("decimal(18,2)");


            modelBuilder.Entity<SolicitudPrestamoUsuario>()
               .HasOne(x => x.Usuario) // usuario de Identity
               .WithMany()
               .HasForeignKey(x => x.UsuarioId);


        }
        public DbSet<SolicitudPrestamoUsuario> SolicitudPrestamos { get; set; }





    }
}
