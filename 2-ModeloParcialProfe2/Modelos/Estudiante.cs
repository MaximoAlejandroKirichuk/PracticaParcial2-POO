using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_ModeloParcialProfe2.Modelos
{
    public class Estudiante
    {
        public int Id { get; set; }
        public string Apellido { get; set; }
        public string Nombre { get; set; }
        public string Curso { get; set; }

		public Estudiante(int id, string apellido, string nombre, string curso)
		{
			this.Id = id;
			this.Apellido = apellido;
			this.Nombre = nombre;
			this.Curso = curso;
		}
    }
}
