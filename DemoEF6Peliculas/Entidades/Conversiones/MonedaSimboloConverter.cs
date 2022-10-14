using Microsoft.EntityFrameworkCore.Storage.ValueConversion;


namespace DemoEF6Peliculas.Entidades.Conversiones
{
    public class MonedaSimboloConverter: ValueConverter<Moneda, string>
    {
        public MonedaSimboloConverter() : base(m => MonedaString(m), s => StringMoneda(s))
        {
            // Do nothing
        }

        private static string MonedaString(Moneda value)
        {
            return value switch
            {
                Moneda.Peso => "MXN",
                Moneda.Dolar => "USD",
                Moneda.Euro => "EUR",
                _ => ""
            };
        }

        private static Moneda StringMoneda(string value)
        {
            return value switch
            {
                "MXN" => Moneda.Peso,
                "USD" => Moneda.Dolar,
                "EUR" => Moneda.Euro,
                _ => Moneda.Ninguna
            };
        }
    }
}
