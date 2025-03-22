using Listas_App.Models;

namespace Listas_App.Services
{
    public class Listas1
    {
        public Nodo? PrimerNodo { get; set; }
        public Nodo? UltimoNodo { get; set; }


        public Listas1()
        {
            PrimerNodo = null;
            UltimoNodo = null;
        }

        // Metodo para determinar si la lista esta vacia.
        bool EstaVacia()
        {
            return PrimerNodo == null;
        }

        // Metodos para agregar al final e inicio de la lista.
        public string AgregarAlFinal(Nodo nuevoNodo)
        {
            if (EstaVacia())
            {
                PrimerNodo = nuevoNodo;
            }
            else
            {
                UltimoNodo.Referencia = nuevoNodo;
            }

            UltimoNodo = nuevoNodo;
            return "Nodo agregado al final de la lista";
        }

        public string AgregarAlInicio(Nodo nuevoNodo)
        {
            if (EstaVacia())
            {
                UltimoNodo = nuevoNodo;
            }
            else
            {
                nuevoNodo.Referencia = PrimerNodo;
            }

            PrimerNodo = nuevoNodo;
            return "Nodo agregado al inicio de la lista";
        }

        public void LimpiarLista()
        {
            UltimoNodo = new Nodo();
            PrimerNodo = new Nodo();
        }
    }
}
