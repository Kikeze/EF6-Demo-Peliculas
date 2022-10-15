namespace DemoEF6Peliculas.Servicios
{
    public interface IServicioUsuario
    {
        string ObtenerUsuarioId();
    }

    public class ServicioUsuario : IServicioUsuario
    {
        public string ObtenerUsuarioId()
        {
            var secs = DateTime.Now.Second.ToString();
            return "Alguien" + secs;
        }
    }

}
