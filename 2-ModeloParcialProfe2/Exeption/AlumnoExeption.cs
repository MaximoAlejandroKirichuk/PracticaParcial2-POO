using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2_ModeloParcialProfe2.Exeption
{
    public class AlumnoExeption : Exception
    {
        public string Condicion { get; set; }
        public string Valor { get; set; }
        public AlumnoExeption(string condicion, string valor)
        {
            this.Condicion = condicion;
            this.Valor = valor;
        }
        public override string Message => $"No se puso encontrar el valor : {Valor} con la condicion: {Condicion}.";
    }
}
