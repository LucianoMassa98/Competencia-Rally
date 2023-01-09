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
    public partial class CategoriasForm : Form
    {

         List<Categoria> listaCategorias;
        public CategoriasForm()
        {
            InitializeComponent();
          
            LoadData();
        }
        //
        public void LoadData() {
            listaCategorias = CategoriaService.findAll();
            comboBox1.Items.Clear();
            dataGridView1.Rows.Clear();
            int cntPiloto;
            if (listaCategorias!=null) {
                foreach (Categoria x in listaCategorias)
                {
                  

                    dataGridView1.Rows.Add(x.Id, x.Nombre);
                    comboBox1.Items.Add(x.Nombre);
                }
            }
            
        
        }

        //agregar categoria
        private void button1_Click(object sender, EventArgs e)
        {
            CategoriasForm formularioActual = this;
            new CategoriasAdd(ref formularioActual).Show();
            formularioActual.Enabled = false;

        }
        //eliminar categoria
        private void button3_Click(object sender, EventArgs e)
        {
            int i = dataGridView1.CurrentRow.Index;
            Categoria x = CategoriaService.findOneId(int.Parse(dataGridView1.Rows[i].Cells[0].Value.ToString()));
            if (x!=null) {
               // x.ListaPilotos = PilotoService.findAllforCategoria(x.Id);
                CategoriasForm formularioActual = this;
                new CategoriasRemove(ref formularioActual, x).Show();
                formularioActual.Enabled = false;
            }
        }
        //actualizar categoria
        private void button2_Click(object sender, EventArgs e)
        {
            int i = dataGridView1.CurrentRow.Index;
            Categoria x = CategoriaService.findOneId(int.Parse(dataGridView1.Rows[i].Cells[0].Value.ToString()));
            if (x != null)
            {
                CategoriasForm formularioActual = this;
                new CategoriaUpdate(ref formularioActual, x).Show();
                formularioActual.Enabled = false;
            }

        }
        // buscar categoria
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int i = 0;
            while ((i < dataGridView1.RowCount)
                && (dataGridView1.Rows[i].Cells[1].Value.ToString() != comboBox1.Text)) { i++; }
            if (i < dataGridView1.RowCount)
            {
                dataGridView1.CurrentCell = dataGridView1.Rows[i].Cells[0];
            }

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
