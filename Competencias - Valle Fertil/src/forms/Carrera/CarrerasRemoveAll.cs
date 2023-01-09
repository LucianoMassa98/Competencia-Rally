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
    public partial class CarrerasRemoveAll : Form
    {
        CarrerasForm Anterior;
        public CarrerasRemoveAll(ref CarrerasForm x)
        {
            InitializeComponent();
            Anterior = x;
            loadData();
        }

        public void loadData()
        {
            lNombre.Text = "Total: "+CarreraService.findAll().Count();
            lCategoria.Text = "Total: " + ParticipacionService.findAll().Count();
        }
        //confirmar
        private void button2_Click(object sender, EventArgs e)
        {
           
            
                bool band = CarreraService.deleteAll();
            if (band) {
                Form actual = this;
                Anterior.Enabled = true;
                Anterior.LoadData();
                actual.Close();
            }
            else
            {
                MessageBox.Show("No se pudo eliminar");
            }
                
          

        }
        //cancelar
        private void button3_Click(object sender, EventArgs e)
        {
            Form actual = this;

            Anterior.Enabled = true;
            actual.Close();

        }

        private void CarrerasRemoveAll_Load(object sender, EventArgs e)
        {

        }
    }
}
