using _2_ModeloParcialProfe2.Exeption;
using _2_ModeloParcialProfe2.Modelos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2_ModeloParcialProfe2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        ListaEstudiantes _ListaEstudiantes = new ListaEstudiantes();
        private void Form1_Load(object sender, EventArgs e)
        {
            // Suscripción correcta: se hace una sola vez
            _ListaEstudiantes.IdDuplicado += MostrarMensajeIdDuplicado;
        }
        public void ActualizarData()
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = _ListaEstudiantes.mostrarListaCompleta();

        }
        public void ActualizarDataFiltrado(List<Estudiante> ListaFiltrada)
        {
            dataGridView2.DataSource = null;
            dataGridView2.DataSource = ListaFiltrada;
        }
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                string nombre = txtNombre.Text;
                string apellido = txtApellido.Text;
                int id = Convert.ToInt32(txtId.Text);
                string curso = comboBoxCursoEstudiante.SelectedItem.ToString();

                Estudiante nuevoEstudiante = new Estudiante(id, apellido, nombre, curso);
                _ListaEstudiantes.AgregarEstudiante(nuevoEstudiante);
                
                ActualizarData();
            }
            catch (FormatException ex)
            {
                MessageBox.Show("Ocurrio un error al agregar, fijarse el id debe ser un numero: " + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrio un error al crear al estudiante: " + ex.Message);
            }
        }


        private void MostrarMensajeIdDuplicado(int id)
        {
            MessageBox.Show($"El ID {id} ya existe. No se puede agregar el estudiante.");
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                string eleccion = comboBoxEleccion.SelectedItem.ToString();
                //Curso
                if (eleccion == "Curso")
                {
                    string valorCurso = comboBoxEleccionFiltrarCurso.Text;
                    var ListaFiltrada = _ListaEstudiantes.Filtrar(eleccion, valorCurso);
                    if (ListaFiltrada.Count == 0) throw new AlumnoExeption(eleccion, valorCurso);

                    ActualizarDataFiltrado(ListaFiltrada);
                }
                //Apellido o Id
                else
                {
                    string valor_apellido_Id = txtApellidoId.Text;
                    var ListaFiltrada = _ListaEstudiantes.Filtrar(eleccion, valor_apellido_Id);
                    if (ListaFiltrada.Count == 0) throw new AlumnoExeption(eleccion, valor_apellido_Id);
                    ActualizarDataFiltrado(ListaFiltrada);
                }



            }
            catch (AlumnoExeption alumnoExeption)
            {
                MessageBox.Show(alumnoExeption.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Seleccione un metodo de busqueda : " + ex.Message);
            }

        }
    }
}
