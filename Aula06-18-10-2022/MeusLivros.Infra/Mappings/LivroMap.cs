using MeusLivros.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MeusLivros.Infra.Mappings;

public class LivroMap : IEntityTypeConfiguration<Livro>
{
    public void Configure(EntityTypeBuilder<Livro> builder)
    {
        //configurando o nome da tabela
        builder.ToTable("Livro");

        //configurando a chave primaria
        builder.HasKey(x => x.Id);

        //configurando o autogenerate (Identity)
        builder.Property(x => x.Id)
            .ValueGeneratedOnAdd()
            .UseIdentityColumn();

        //configurando o campo Nome
        builder.Property(x => x.Nome)
            .HasColumnName("Nome")
            .HasColumnType("VARCHAR")
            .HasMaxLength(150)
            .IsRequired();

        //configurando os relacionamentos
        builder
            .HasOne(x => x.Editora)
            .WithMany(x => x.Livros)
            .HasConstraintName("FK_Livro_Editora");
    }
}