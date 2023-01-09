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
    public partial class CarrerasUpdate : Form
    {
        CarrerasForm Anterior;
        Carrera carrera;
        public CarrerasUpdate(ref CarrerasForm x, object carrera)
        {
            InitializeComponent();
            Anterior = x;
            this.carrera = (Carrera)carrera;
            loadData();
        }

        public void loadData()
        {
            textBox1.Text = carrera.Nombre;
           dateTimePicker1.Value = carrera.Fecha;
            comboBox1.Text = carrera.Categoria.Nombre;


        }
        //confirmar
        private void button2_Click(object sender, EventArgs e)
        {
            Carrera newCarrera = new Carrera();
            newCarrera.Id = carrera.Id;
            newCarrera.Nombre = textBox1.Text;
            newCarrera.Fecha = DateTime.Parse(dateTimePicker1.Value.ToString());
            newCarrera.Categoria = carrera.Categoria;
            if (newCarrera.Categoria!=null) {
                newCarrera = CarreraService.update(carrera.Id,newCarrera);

                Form actual = this;

                Anterior.Enabled = true;
                Anterior.LoadData();
                actual.Close();
            }
            else
            {
                MessageBox.Show("No se pudo crear la carrera");
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
