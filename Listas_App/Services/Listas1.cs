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

        public string EliminarNodoAlInicio()
        {
            if (EstaVacia())
            {
                return "La lista esta vacia.";
            }

            if (PrimerNodo == UltimoNodo)
            {
                PrimerNodo = UltimoNodo = null;
            }
            else
            {
                Nodo nodoAux;
                nodoAux = PrimerNodo;

                PrimerNodo = PrimerNodo.Referencia;
                nodoAux = null;
            }
            return "Nodo eliminado!!";
        }

        public string EliminarNodoAlFinal()
        {
            if (EstaVacia())
            {
                return "La lista esta vacia.";
            }

            if (PrimerNodo == UltimoNodo)
            {
                PrimerNodo = UltimoNodo = null;
            }
            else
            {
                Nodo nodoActual;
                Nodo nodoAux;

                nodoActual = PrimerNodo;
                nodoAux = nodoActual.Referencia;

                while (nodoAux.Referencia != null)
                {
                    
                    nodoActual = nodoActual.Referencia;
                    nodoAux = nodoActual.Referencia;                   
                }

                nodoAux = null;
                nodoActual.Referencia = null;
                UltimoNodo = nodoActual;
            }
            return "Nodo final, eliminado!!";
        }

        public void LimpiarLista()
        {
            UltimoNodo = null;
            PrimerNodo = null;
        }
    }
}
