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

        public static Principal Intancia
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

        private List<Pantalla> Pantallas = new List<Pantalla>();
        private List<Computadora> Computadoras = new List<Computadora>();

        public int ObtenerCantidadPantallas()
        {
            return Pantallas.Count();
        }
        public int ObtenerCantidadPC()
        {
            return Computadoras.Count();
        }
        public int ObtenerCantidadDispositivos()
        {
            return ObtenerLista().Count();
        }

        public List<string> ObtenerListaString()
        {
            return ObtenerLista().Select(x => x.ObtenerDescripcion()).ToList();
        }

        public EventHandler<AgregarEliminar> agregarEliminar;

        public void Evento(string id, Tipo tipo)
        {
            this.agregarEliminar(this, new AgregarEliminar()
            {
                Id = id,
                Tipo = tipo
            });
        }

        public void Agregar(string marca, string modelo, int nroSerie, int año, int pulgadas)
        {
            Pantalla pantalla = new Pantalla(marca, modelo, nroSerie, año, pulgadas);

            Pantallas.Add(pantalla);
            Evento(pantalla.Id, Tipo.Monitor);
        }

        public void Agregar(string marca, string modelo, int nroSerie, string cpu, short ram, string fabricante)
        {
            Computadora computadora = new Computadora(marca, modelo, nroSerie, cpu, ram, fabricante);

            Computadoras.Add(computadora);
            Evento(computadora.Id, Tipo.Computadora);
        }

        public void Eliminar(string id)
        {
            Tipo tipo;

            if(Buscar(id) != null)
            {
                if (Buscar(id).GetType() == typeof(Pantalla))
                {
                    Pantallas.Remove((Pantalla)Buscar(id));
                    tipo = Tipo.Monitor;
                }
                else
                {
                    Computadoras.Remove((Computadora)Buscar(id));
                    tipo = Tipo.Computadora;
                }
                Evento(id, tipo);
            }
            else
            {
                throw new Exception(" El ID pasado no existe");
            }
        }

        public string ObtenerDescripcion(string id)
        {
            return Buscar(id).ObtenerDescripcion();
        }

        private List<Dispositivo> ObtenerLista()
        {
            List<Dispositivo> lista = new List<Dispositivo>();

            lista.AddRange(Computadoras);
            lista.AddRange(Pantallas);

            return lista.OrderBy(x => x.GetType() == typeof(Pantalla)).ToList();
        }

        private Dispositivo Buscar(string id)
        {
            return ObtenerLista().FirstOrDefault( x => x.Id == id);
        }
    }
}
