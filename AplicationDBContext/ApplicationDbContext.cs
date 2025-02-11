using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using SmartCash.Models;

namespace SmartCash.ApplicationDBContext
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Transacao> Transacoes { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Categoria> Categorias { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) {}
    }
}