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
    public partial class CarrerasAdd : Form
    {
        CarrerasForm Anterior;
        public CarrerasAdd(ref CarrerasForm x)
        {
            InitializeComponent();
            Anterior = x;
            loadData();
        }

        public void loadData()
        {
            List<Categoria> lista = CategoriaService.findAll();
            if (lista!=null) {
            foreach(Categoria x in lista)
                {
                    comboBox1.Items.Add(x.Nombre);
                }
            }


        }
        //confirmar
        private void button2_Click(object sender, EventArgs e)
        {
            Carrera newCarrera = new Carrera();
            newCarrera.Id = 0;
            newCarrera.Nombre = textBox1.Text;
            newCarrera.Fecha = DateTime.Now;
            newCarrera.Categoria = CategoriaService.findOneNombre(comboBox1.Text);
            if (newCarrera.Categoria!=null) {
                //MessageBox.Show("1");
                newCarrera = CarreraService.create(newCarrera);
                //MessageBox.Show("2");
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
