using _2_ModeloParcialProfe2.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_ModeloParcialProfe2
{
    interface IFiltrado<T,P>
    {
        List<Estudiante> Filtrar(T condicion, P valor);
    }
}
