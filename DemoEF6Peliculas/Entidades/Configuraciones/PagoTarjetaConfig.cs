using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace DemoEF6Peliculas.Entidades.Configuraciones
{
    public class PagoTarjetaConfig : IEntityTypeConfiguration<PagoTarjeta>
    {
        public void Configure(EntityTypeBuilder<PagoTarjeta> builder)
        {
            builder.Property(p => p.Ultimos4Digitos)
                .HasMaxLength(10)
                .IsRequired();

            var pago1 = new PagoTarjeta()
            {
                Id = 1,
                FechaTransaccion = DateTime.Now.AddDays(-12),
                Monto = 175,
                TipoPago = TipoPago.Tarjeta,
                Ultimos4Digitos = "1234"
            };
            var pago2 = new PagoTarjeta()
            {
                Id = 2,
                FechaTransaccion = DateTime.Now.AddDays(-8),
                Monto = 275,
                TipoPago = TipoPago.Tarjeta,
                Ultimos4Digitos = "4321"
            };

            builder.HasData(pago1, pago2);

        }
    }
}
