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
    public partial class CategoriaUpdate : Form
    {
        CategoriasForm Anterior;
        Categoria cateX;
        public CategoriaUpdate(ref CategoriasForm x, object categoria)
        {
            InitializeComponent();
            Anterior = x;
            cateX = (Categoria)categoria;
            if (cateX != null)
            {
                label5.Text = cateX.Id.ToString();
                textBox1.Text = cateX.Nombre;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            cateX.Nombre = textBox1.Text;
            Categoria res = CategoriaService.update(cateX.Id,cateX);
            if (res!=null)
            {
                Form actual = this;

                Anterior.Enabled = true;
                Anterior.LoadData();
                actual.Close();
            }
            else
            {
                MessageBox.Show("");
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
