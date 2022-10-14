using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace DemoEF6Peliculas.Entidades.Configuraciones
{
    public class PagoPaypalConfig : IEntityTypeConfiguration<PagoPaypal>
    {
        public void Configure(EntityTypeBuilder<PagoPaypal> builder)
        {
            builder.Property(p => p.EMail)
                .HasMaxLength(150)
                .IsRequired();

            var pago1 = new PagoPaypal()
            {
                Id = 3,
                FechaTransaccion = DateTime.Now.AddDays(-15),
                Monto = 150,
                TipoPago = TipoPago.Paypal,
                EMail = @"prueba1@correo.com"
            };
            var pago2 = new PagoPaypal()
            {
                Id = 4,
                FechaTransaccion = DateTime.Now.AddDays(-10),
                Monto = 250,
                TipoPago = TipoPago.Paypal,
                EMail = @"prueba2@correo.com"
            };

            builder.HasData(pago1, pago2);
        }
    }
}
