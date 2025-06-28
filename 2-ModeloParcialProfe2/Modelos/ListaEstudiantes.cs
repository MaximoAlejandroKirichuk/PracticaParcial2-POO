using _2_ModeloParcialProfe2.Exeption;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2_ModeloParcialProfe2.Modelos
{
    public class ListaEstudiantes: IABM<Estudiante>,IFiltrado<string,string>
    {
        private List<Estudiante> _listaEstudiantes = new List<Estudiante>();
        // Delegado y evento para ID duplicado
        public delegate void IdDuplicadoEventHandler(int id);
        public event IdDuplicadoEventHandler IdDuplicado;
        public List<Estudiante> mostrarListaCompleta()
        {
            return _listaEstudiantes;
        }

        public void AgregarEstudiante(Estudiante nuevoEstudiante)
        {
            // Validación de ID duplicado
            if (_listaEstudiantes.Any(e => e.Id == nuevoEstudiante.Id))
            {
                // Disparar evento si el ID ya existe
                IdDuplicado?.Invoke(nuevoEstudiante.Id);
            }
            else
            {
                _listaEstudiantes.Add(nuevoEstudiante);
                MessageBox.Show($"Se creo el alumno {nuevoEstudiante.Apellido}");
            }
        }

        public List<Estudiante> Filtrar(string condicion, string valor)
        {
            try
            {
                if (condicion == "Curso")
                {
                    var lista = _listaEstudiantes.Where(e => e.Curso == valor);
                    return lista.ToList();
                }
                if (condicion == "Id")
                {
                    var lista = _listaEstudiantes.Where(e => e.Id == Convert.ToInt32(valor));
                    return lista.ToList();
                }
                if (condicion == "Apellido")
                {
                    var lista = _listaEstudiantes.Where(e => e.Apellido == valor);
                    return lista.ToList();
                }
                throw new AlumnoExeption(condicion, valor);
            }
            catch (AlumnoExeption ex)
            {
                MessageBox.Show(ex.Message);
            }
            return null;
        }

    }
}
