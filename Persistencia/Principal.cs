using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia
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
    }
}
