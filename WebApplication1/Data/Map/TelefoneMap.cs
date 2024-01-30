using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApplication1.Models;

namespace WebApplication1.Data.Map
{
    public class TelefoneMap : IEntityTypeConfiguration<TelefoneModel>
    {
        public void Configure(EntityTypeBuilder<TelefoneModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x=> x.Tipo).IsRequired();
            builder.Property(x=> x.Numero).IsRequired();
            builder.Property(x=> x.PessoaId);

            builder.HasOne(x => x.Pessoa);
        }
    }
}
