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
    public partial class PilotosRemove : Form
    {
        PilotosForm Anterior;
        Piloto piloto;
        public PilotosRemove(ref PilotosForm x, object piloto)
        {
            InitializeComponent();
            Anterior = x;
            this.piloto = (Piloto)piloto;
            loadData();
        }
        public void loadData() {
            lNombre.Text = piloto.Nombre;
            lApellido.Text = piloto.Apellido;
            lNacimineto.Text = piloto.Nacimiento;
            lSexo.Text = piloto.Sexo;
            lDomicilio.Text = piloto.Domicilio;
            lEmail.Text = piloto.Email;
            lAlojamiento.Text = piloto.Alojamiento;
            lAlergias.Text = piloto.Alergias;
            lNacionalidad.Text = piloto.Nacionalidad;
            lEdad.Text = piloto.Edad.ToString();
            lDni.Text = piloto.Dni.ToString();
            lCelular.Text = piloto.Celular.ToString();


        }

        // eliminar
        private void button2_Click(object sender, EventArgs e)
        {
            bool res = PilotoService.delete(piloto.Id);
            if (res)
            {
                Form actual = this;

                Anterior.Enabled = true;
                Anterior.LoadData();
                actual.Close();
            }
            else
            {
                MessageBox.Show("No se pudo eliminar el piloto");
            }

        }
        //cancelar
        private void button3_Click(object sender, EventArgs e)
        {
            Form actual = this;

            Anterior.Enabled = true;
            actual.Close();
        }
    }
}
