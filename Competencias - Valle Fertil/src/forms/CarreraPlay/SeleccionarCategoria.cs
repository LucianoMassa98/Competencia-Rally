using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;
namespace Competencias___Valle_Fertil
{
    public partial class SeleccionarCategoria : Form
    {
        CarreraPlay anterior;
        public SeleccionarCategoria(ref CarreraPlay anterior)
        {
            InitializeComponent();
            loadData();
            this.anterior = anterior;
        }
        private void loadData() {
            foreach (Carrera x in CarreraService.findAll()) {
                comboBox1.Items.Add(x.Nombre);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Seleccionar(comboBox1.Text);
           
        }

        public void Seleccionar(string nomCarre)
        {
            Carrera carre = CarreraService.findOneNombre(nomCarre);
            if (carre != null)
            {
               
                anterior.openChildForm(new PlayPosiciones(carre.Id));
                
            }
        }
    }
}
