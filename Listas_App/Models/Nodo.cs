namespace Listas_App.Models
{
    public class Nodo
    {
        public object Informacion { get; set; }
        public Nodo? Referencia { get; set; }
        public Nodo()
        {
            Informacion = string.Empty;
            Referencia = null;
        }

        public Nodo(object informacion)
        {
            Informacion = informacion;
            Referencia = null;
        }

        public override string ToString()
        {
            return $"{Informacion}";
        }
    }
}
