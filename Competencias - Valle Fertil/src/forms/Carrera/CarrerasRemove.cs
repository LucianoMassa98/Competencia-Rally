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
    public partial class CarrerasRemove: Form
    {
        CarrerasForm Anterior;
        Carrera carrera;
        public CarrerasRemove(ref CarrerasForm x, object carrera)
        {
            InitializeComponent();
            Anterior = x;
            this.carrera = (Carrera)carrera;
            loadData();
        }

        public void loadData()
        {
            lNombre.Text = carrera.Nombre;
            lFecha.Text = carrera.Fecha.ToString();
            lCategoria.Text = carrera.Categoria.Nombre;


        }
        //confirmar
        private void button2_Click(object sender, EventArgs e)
        {
           
            
                bool band = CarreraService.delete(carrera.Id);
            if (band) {
                Form actual = this;

                Anterior.Enabled = true;
                Anterior.LoadData();
                actual.Close();
            }
            else
            {
                MessageBox.Show("No se pudo eliminar la carrera");
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
