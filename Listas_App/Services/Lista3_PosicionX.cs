using Listas_App.Models;

namespace Listas_App.Services
{
    public class Lista3_PosicionX
    {
        public Nodo? PrimerNodo { get; set; }
        public Nodo? UltimoNodo { get; set; }
        public string ListaRec { get; set; }
        public Lista3_PosicionX()
        {
            PrimerNodo = null;
            UltimoNodo = null;
            ListaRec = string.Empty;
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

        public void InsertarEnPosicicion(Nodo referencia, Nodo nuevoNodo)
        {
            PrimerNodo = InsertarEnPosicionX(PrimerNodo, Convert.ToInt32(referencia.Informacion), nuevoNodo, 0);
        }

        private Nodo InsertarEnPosicionX(Nodo? actual, int referencia, Nodo nuevoNodo, int contador)
        {
            // Valida si la lista esta vacia o si llegamos al final.
            if (actual == null)
                return null;

            
                // Si encontramos el nodo con el valor de referencia, insertamos el nuevo nodo antes de el.
                if (contador == referencia && actual != null)
                {
                    Nodo nodoNuevo = new Nodo(nuevoNodo);
                    nodoNuevo.Referencia = actual.Referencia; // Hacemos que el nuevo nodo apunte al actual.
                    actual = nodoNuevo;
                    return actual; // Retornamos el nuevo nodo para que se vincule.
                }          

            // Llamada recursiva para seguir buscando.
            actual.Referencia = InsertarEnPosicionX(actual.Referencia, referencia, nuevoNodo, contador + 1);
            return actual;
        }

        public void InsertarAntesDePosicicion(Nodo referencia, Nodo nuevoNodo)
        {
            PrimerNodo = InsertarAntesPosicionX(PrimerNodo, Convert.ToInt32(referencia.Informacion), nuevoNodo, 0);
        }

        private Nodo InsertarAntesPosicionX(Nodo? actual, int referencia, Nodo nuevoNodo, int contador)
        {
            // Valida si la lista esta vacia o si llegamos al final.
            if (actual == null)
                return null;

            if (contador.Equals(referencia) && actual != null)
            {                
                if (contador == 0)
                {
                    Nodo nodoNuevo = new Nodo(nuevoNodo);
                    nodoNuevo.Referencia = actual; // Hacemos que el nuevo nodo apunte al actual.
                    return nodoNuevo; // Retornamos el nuevo nodo para que se vincule.
                }

                Nodo nuevoNodoAntes = new Nodo(nuevoNodo);
                nuevoNodoAntes.Referencia = actual; // Hacemos que el nuevo nodo apunte al actual.
                return nuevoNodoAntes; // Retornamos el nuevo nodo para que se vincule.
            }


            // Llamada recursiva para seguir buscando.
            actual.Referencia = InsertarAntesPosicionX(actual.Referencia, referencia, nuevoNodo, contador + 1);
            return actual;
        }

        public void InsertarDespuesDePosicicion(Nodo referencia, Nodo nuevoNodo)
        {
            PrimerNodo = InsertarDespuesPosicionX(PrimerNodo, Convert.ToInt32(referencia.Informacion), nuevoNodo, 0);
        }

        private Nodo InsertarDespuesPosicionX(Nodo? actual, int referencia, Nodo nuevoNodo, int contador)
        {
            // Valida si la lista esta vacia o si llegamos al final.
            if (actual == null)
                return null;

            if (contador.Equals(referencia) && actual != null)
            {
                // Si encontramos el nodo con el valor de referencia, insertamos el nuevo nodo antes de el.
                Nodo nodoNuevo = new Nodo(nuevoNodo);
                nodoNuevo.Referencia = actual.Referencia; // Hacemos que el nuevo nodo apunte al actual.
                actual.Referencia = nodoNuevo;
                return actual; // Retornamos el nuevo nodo para que se vincule.
            }


            // Llamada recursiva para seguir buscando.
            actual.Referencia = InsertarDespuesPosicionX(actual.Referencia, referencia, nuevoNodo, contador + 1);
            return actual;
        }

        public void LimpiarLista()
        {
            UltimoNodo = null;
            PrimerNodo = null;
        }
    }
}
