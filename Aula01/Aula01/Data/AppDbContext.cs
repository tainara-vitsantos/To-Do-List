using Aula01.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Aula01.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options)
        : base(options) { }

        // Informar a model para o nosso contexto
        // E como ela irá ser criada ao executar
        // as migrations

        public DbSet<Tarefa> Tarefas { get; set; }

        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tarefas>()
                .HasOne(t => t.Usuario)
                .WithMany(u => u.Tarefas)
                .HasForeignKey(t => t.UsuarioId)
                .OnDelete(DeleteBehavior.Cascade);

            base.OnModelCreating(modelBuilder);
        }
    }
}
