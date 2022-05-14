using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using ArgEventos;

namespace Logica
{
    public sealed class Principal
    {
        private static Principal instancia = null;

        private Principal() { }

        public static Principal principal
        {
            get
            {
                if (instancia == null)
                {
                    instancia = new Principal();
                }
                return instancia;
            }
        }

        static List<Pantalla> Pantallas = new List<Pantalla>();
        static List<Computadora> Computadoras = new List<Computadora>();

        public EventHandler<AgregarEliminar> agregarEliminar;

        public void Evento(Dispositivo dispositivo)
        {
            this.agregarEliminar(this, new AgregarEliminar()
            {
                Id = dispositivo.Id,
                Tipo = dispositivo.GetType() == typeof(Pantalla) ? Tipo.Monitor : Tipo.Computadora
            });
        }

        public void Agregar(Pantalla monitor)
        {
            Pantallas.Add(monitor);
            Evento(monitor);
        }

        public void Agregar(Computadora computadora)
        {
            Computadoras.Add(computadora);
            Evento(computadora);
        }

        public void Eliminar(string id)
        {
            if(Buscar(id) != null)
            {
                if (Buscar(id).GetType() == typeof(Pantalla))
                {
                    Pantallas.Remove((Pantalla)Buscar(id));
                }
                else
                {
                    Computadoras.Remove((Computadora)Buscar(id));
                }
            }

            Evento(Buscar(id));
        }

        public string ObtenerDescripcion(string id)
        {
            return Buscar(id).ObtenerDescripcion();
        }

        public List<Dispositivo> ObtenerLista()
        {
            List<Dispositivo> lista = new List<Dispositivo>();

            lista.AddRange(Computadoras);
            lista.AddRange(Pantallas);

            return lista.OrderBy(x => x.GetType()).ToList();
        }

        public Dispositivo Buscar(string id)
        {
            return ObtenerLista().FirstOrDefault( x => x.Id == id);
        }
    }
}
