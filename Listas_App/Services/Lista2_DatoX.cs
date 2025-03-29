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
                return;

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

        public string EliminarAntesDatoX(Nodo valorRef)
        {
            Nodo nodoActual = PrimerNodo;
            Nodo nodoAnterior = PrimerNodo;
            Nodo nodoAnterior2 = PrimerNodo;

            while (nodoActual != null && !nodoActual.Informacion.Equals(valorRef.Informacion))
            {
                nodoAnterior2 = nodoAnterior;
                nodoAnterior = nodoActual;
                nodoActual = nodoActual.Referencia;
            }

            if (nodoActual != null)
            {
                if (nodoActual == PrimerNodo)
                {
                    return "No hay nodos para eliminar";
                }
                else if (nodoAnterior == nodoAnterior2)
                {
                    EliminarNodoAlInicio();
                }
                else
                {
                    nodoAnterior2.Referencia = nodoAnterior.Referencia;
                    nodoAnterior = null;
                }

                return "Nodo eliminado!!";
            }
            else
            {
                return $"El valor de referencia {valorRef} no fue encontrado!";
            }

        }

        public string EliminarDespuesDatoX(Nodo valorRef)
        {
            if (PrimerNodo == null) 
            {
                return "No hay nodos para eliminar";
            }

            Nodo nodoActual = PrimerNodo;

            while (nodoActual != null && !nodoActual.Informacion.Equals(valorRef.Informacion))
            {
                nodoActual = nodoActual.Referencia; 
            }

            if (nodoActual == null)
            {
                return $"El valor de referencia {valorRef.Informacion} no fue encontrado!";
            }

            if (nodoActual.Referencia != null)
            {
                Nodo nodoAEliminar = nodoActual.Referencia;
                nodoActual.Referencia = nodoAEliminar.Referencia;
                nodoAEliminar = null; 

                return "Nodo eliminado!!";
            }
            else
            {
                return "No hay nodos después del nodo con el valor de referencia.";
            }

        }

        public string EliminarNodoEnPosicion(int posicion)
        {
            if (PrimerNodo == null)
            {
                return "No hay nodos para eliminar.";
            }

            if (posicion == 0)
            {
                PrimerNodo = PrimerNodo.Referencia;
                return "Nodo eliminado en la posición 0.";
            }

            Nodo nodoActual = PrimerNodo;
            Nodo nodoAnterior = null;
            int indice = 0;

            while (nodoActual != null && indice < posicion)
            {
                nodoAnterior = nodoActual;
                nodoActual = nodoActual.Referencia;
                indice++;
            }

            if (nodoActual == null)
            {
                return $"No se encontró un nodo en la posición {posicion}.";
            }

            nodoAnterior.Referencia = nodoActual.Referencia;

            return $"Nodo eliminado en la posición {posicion}.";
        }

        public void OrdenarLista()
        {
            if (PrimerNodo == null || PrimerNodo.Referencia == null) 
            {
                return; 
            }

            Nodo nuevaCabeza = null; 

            Nodo nodoActual = PrimerNodo;

            while (nodoActual != null)
            {
                Nodo siguienteNodo = nodoActual.Referencia;

                nuevaCabeza = InsertarOrdenado(nuevaCabeza, nodoActual);

                nodoActual = siguienteNodo;
            }

            PrimerNodo = nuevaCabeza;
        }

        private Nodo InsertarOrdenado(Nodo cabeza, Nodo nuevoNodo)
        {
          
            if (cabeza == null || Convert.ToString(nuevoNodo.Informacion).CompareTo(cabeza.Informacion) < 0)
            {
                nuevoNodo.Referencia = cabeza; 
                return nuevoNodo; 
            }

           
            Nodo nodoActual = cabeza;

            while (nodoActual.Referencia != null &&
                   Convert.ToString(nuevoNodo.Informacion).CompareTo(nodoActual.Referencia.Informacion) >= 0)
            {
                nodoActual = nodoActual.Referencia;
            }

            nuevoNodo.Referencia = nodoActual.Referencia;
            nodoActual.Referencia = nuevoNodo;

            return cabeza;
        }
        public void LimpiarLista()
        {
            UltimoNodo = null;
            PrimerNodo = null;
        }
    }
}
