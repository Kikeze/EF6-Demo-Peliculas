using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using DemoEF6Peliculas.Entidades.Conversiones;


namespace DemoEF6Peliculas.Entidades.Configuraciones
{
    public class SalaCineConfig : IEntityTypeConfiguration<SalaCine>
    {
        public void Configure(EntityTypeBuilder<SalaCine> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Precio)
                .HasPrecision(precision: 9, scale: 2);

            builder.Property(p => p.Tipo)
                .HasDefaultValue(TipoSalaCine.NoDefinida)
                .HasConversion<string>();

            builder.Property(p => p.Moneda)
                .HasConversion<MonedaSimboloConverter>();
        }
    }
}
