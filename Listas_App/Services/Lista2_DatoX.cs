using Listas_App.Models;
using System.Reflection;

namespace Listas_App.Services
{
    public class Lista2_DatoX
    {
        public Nodo? PrimerNodo { get; set; }
        public Nodo? UltimoNodo { get; set; }

        public Lista2_DatoX()
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

        public void InsertarAntesDe(Nodo referencia, Nodo nuevoNodo)
        {            
            PrimerNodo = InsertarAntesDatoX(PrimerNodo, referencia, nuevoNodo);
        }

        
        private Nodo InsertarAntesDatoX(Nodo? actual, Nodo referencia, Nodo nuevoNodo)
        {   // Valida si la lista esta vacia o si llegamos al final.
            if (actual == null)
                return null;

            // Si encontramos el nodo con el valor de referencia, insertamos el nuevo nodo antes de el.
            if (actual.Informacion.Equals(referencia.Informacion))
            {
                Nodo nodoNuevo = new Nodo(nuevoNodo);
                nodoNuevo.Referencia = actual; // Hacemos que el nuevo nodo apunte al actual.
                return nodoNuevo; // Retornamos el nuevo nodo para que se vincule.
            }

            // Llamada recursiva para seguir buscando.
            actual.Referencia = InsertarAntesDatoX(actual.Referencia, referencia, nuevoNodo);
            return actual;
        }

        public void InsertarDespuesDe(Nodo referencia, Nodo nuevoNodo)
        {
            InsertarDespuesDatoX(PrimerNodo, referencia, nuevoNodo);
        }


        private void InsertarDespuesDatoX(Nodo? actual, Nodo referencia, Nodo nuevoNodo)
        {   // Valida si la lista esta vacia o si llegamos al final.
            if (actual == null)
                return ;

            // Si encontramos el nodo con el valor de referencia, insertamos el nuevo nodo antes de el.
            if (actual.Informacion.Equals(referencia.Informacion))
            {
                Nodo nodoNuevo = new Nodo(nuevoNodo);
                nodoNuevo.Referencia = actual.Referencia; // Hacemos que el nuevo nodo apunte al actual.
                actual.Referencia = nodoNuevo; 
            }

            // Llamada recursiva para seguir buscando.
            InsertarDespuesDatoX(actual.Referencia, referencia, nuevoNodo);
            
        }

        public void LimpiarLista()
        {
            UltimoNodo = new Nodo();
            PrimerNodo = new Nodo();
        }
    }
}
