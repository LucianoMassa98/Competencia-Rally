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
    public partial class PilotosAdd : Form
    {
        PilotosForm Anterior;
        public PilotosAdd(ref PilotosForm x)
        {
            InitializeComponent();
            Anterior = x;
           
        }
      
        private void button2_Click(object sender, EventArgs e)
        {
            Piloto newPiloto = new Piloto();
            newPiloto.Id = 0;
            newPiloto.Nombre = BoxNombre.Text;
            newPiloto.Apellido= BoxApellido.Text;
            newPiloto.Nacimiento = BoxNacimiento.Text;
            newPiloto.Sexo = BoxSexo.Text;
            newPiloto.Domicilio = BoxDomicilio.Text;
            newPiloto.Email = BoxEmail.Text;
            newPiloto.Alojamiento = BoxAlojamiento.Text;
            newPiloto.Alergias = BoxAlergias.Text;
            newPiloto.Nacionalidad = BoxNacionalidad.Text;
            newPiloto.Celular = BoxCelular.Text;
            try {

                if (BoxEdad.Text=="") {
                    newPiloto.Edad = 0;
                } else { newPiloto.Edad = int.Parse(BoxEdad.Text); }
                

                if (BoxDNI.Text=="") { newPiloto.Dni = 0; } else {
                    newPiloto.Dni = int.Parse(BoxDNI.Text);
                }
                newPiloto = PilotoService.create(newPiloto);

                    if (newPiloto!=null) {
                        Form actual = this;

                        Anterior.Enabled = true;
                        Anterior.LoadData();
                        actual.Close();
                    }
                    else
                    {
                        MessageBox.Show("No se pudo agregar el piloto");
                    }
                   

                
            } catch (Exception err) {
               
                MessageBox.Show("Error en la carga de Edad, Dni y/o Celular, deben ser datos numericos");

            }

         

           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form actual = this;

            Anterior.Enabled = true;
            actual.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
