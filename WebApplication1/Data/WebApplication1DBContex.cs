using Microsoft.EntityFrameworkCore;
using WebApplication1.Data.Map;
using WebApplication1.Models;

namespace WebApplication1.Data
{
    public class WebApplication1DBContex : DbContext
    {
        public WebApplication1DBContex(DbContextOptions<WebApplication1DBContex> options)
            : base(options)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PessoaMap());
            modelBuilder.ApplyConfiguration(new TelefoneMap());

            modelBuilder.Entity<PessoaModel>()
            .HasMany(a => a.Telefones)
            .WithOne(b => b.Pessoa)
            .HasForeignKey(b => b.PessoaId);

            base.OnModelCreating(modelBuilder);
        }
        public DbSet<PessoaModel> Pessoas { get; set; }
        public DbSet<TelefoneModel> Telefones { get; set; }
    }
}
