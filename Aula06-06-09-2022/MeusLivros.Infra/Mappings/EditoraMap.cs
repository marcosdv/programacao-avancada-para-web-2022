using MeusLivros.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MeusLivros.Infra.Mappings;

public class EditoraMap : IEntityTypeConfiguration<Editora>
{
    public void Configure(EntityTypeBuilder<Editora> builder)
    {
        //Configura o nome da tabela
        builder.ToTable("Editora");

        //configura a chave primaria
        builder.HasKey(x => x.Id);

        //configurando o autogenerate (Identity)
        builder.Property(x => x.Id)
            .ValueGeneratedOnAdd()
            .UseIdentityColumn();

        //configurando o campo Nome
        builder.Property(x => x.Nome)
            .HasColumnName("Nome") //opcional se for o mesmo nome do obj
            .IsRequired()
            .HasColumnType("VARCHAR")
            .HasMaxLength(80);
    }
}