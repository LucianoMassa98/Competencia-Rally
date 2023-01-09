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
    public partial class CategoriasAdd : Form
    {
        CategoriasForm Anterior;
        public CategoriasAdd(ref CategoriasForm x)
        {
            InitializeComponent();
            Anterior = x;
        }
     

        private void button2_Click(object sender, EventArgs e)
        {
            Categoria newCategoria = new Categoria();
            newCategoria.Id = 0;
            newCategoria.Nombre = textBox1.Text;
            newCategoria = CategoriaService.create(newCategoria);

            Form actual = this;
            
            Anterior.Enabled = true;
            Anterior.LoadData();
            actual.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form actual = this;
            
            Anterior.Enabled = true;
            actual.Close();
        }
    }
}
