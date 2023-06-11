using AppMvcBasica.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Mappings
{
    public class FornecedorMapping : IEntityTypeConfiguration<Fornecedor>
    {
        public void Configure(EntityTypeBuilder<Fornecedor> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Nome)
                .IsRequired()
                .HasColumnType("varchar(200)");

            builder.Property(p => p.Documento)
               .IsRequired()
               .HasColumnType("varchar(14)");

            //1 : 1 => Fornecedor : Endereço
            builder.HasOne(f => f.Endereco)
                .WithOne(e => e.Fornecedor);

            //1 : N => Fornecedor : Produtos
            builder.HasMany(f => f.Produtos)
                .WithOne(p => p.Fornecedor)
                .HasForeignKey(e => e.FornecedorId);

            builder.ToTable("Fornecedor");

        }
    }
}
