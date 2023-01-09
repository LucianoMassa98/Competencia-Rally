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
    public partial class CategoriasRemove : Form
    {
        CategoriasForm Anterior;
        Categoria cateX;
        public CategoriasRemove(ref CategoriasForm x, object categoria)
        {
            InitializeComponent();
            Anterior = x;
            cateX = (Categoria)categoria;
            if (cateX != null)
            {
                label5.Text = cateX.Id.ToString();
                label3.Text = cateX.Nombre;
            }
        }
     

        private void button2_Click(object sender, EventArgs e)
        {
           
           bool res = CategoriaService.delete(cateX.Id);
            if (res) {
                Form actual = this;

                Anterior.Enabled = true;
                Anterior.LoadData();
                actual.Close();
            }
            else
            {
                MessageBox.Show("No se pudo eliminar la categoria");
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
