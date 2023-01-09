using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Competencias___Valle_Fertil
{
    public partial class PilotosUpdate: Form
    {
        PilotosForm Anterior;
        Piloto piloto;
        public PilotosUpdate(ref PilotosForm x, object piloto)
        {
            InitializeComponent();
            Anterior = x;
            this.piloto = (Piloto)piloto;
            loadData();
        }
        public void loadData() {
          
            BoxNombre.Text=piloto.Nombre;
            BoxApellido.Text = piloto.Apellido;
            BoxNacimiento.Text = piloto.Nacimiento;
            BoxSexo.Text = piloto.Sexo;
            BoxDomicilio.Text = piloto.Domicilio;
            BoxEmail.Text = piloto.Email;
            BoxAlojamiento.Text = piloto.Alojamiento;
            BoxAlergias.Text = piloto.Alergias;
            BoxNacionalidad.Text = piloto.Nacionalidad;
            BoxEdad.Text = piloto.Edad.ToString();
            BoxDNI.Text = piloto.Dni.ToString();
            BoxCelular.Text = piloto.Celular.ToString();
            List<Categoria> lista = CategoriaService.findAll();
            if (lista != null)
            {
                foreach (Categoria x in lista)
                {
                    comboBox1.Items.Add(x.Nombre);
                }
            }


        }
        private void button2_Click(object sender, EventArgs e)
        {
            Piloto newPiloto = new Piloto();
            newPiloto.Id = piloto.Id;
            newPiloto.Nombre = BoxNombre.Text;
            newPiloto.Apellido= BoxApellido.Text;
            newPiloto.Nacimiento = BoxNacimiento.Text;
            newPiloto.Sexo = BoxSexo.Text;
            newPiloto.Domicilio = BoxDomicilio.Text;
            newPiloto.Email = BoxEmail.Text;
            newPiloto.Alojamiento = BoxAlojamiento.Text;
            newPiloto.Alergias = BoxAlergias.Text;
            newPiloto.Nacionalidad = BoxNacionalidad.Text;

            try {
                newPiloto.Edad = int.Parse(BoxEdad.Text);
                newPiloto.Dni = int.Parse(BoxDNI.Text);
                newPiloto.Celular = BoxCelular.Text;

             
                    newPiloto = PilotoService.update(piloto.Id, newPiloto);

                    Form actual = this;

                    Anterior.Enabled = true;
                    Anterior.LoadData();
                    actual.Close();

            } catch (Exception) {
                MessageBox.Show("Error en la carga de Edad, Dni y/o Celular, deben ser datos numericos");

            }

         

           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form actual = this;

            Anterior.Enabled = true;
            actual.Close();
        }
    }
}
