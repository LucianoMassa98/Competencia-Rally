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
    public partial class CarrerasForm : Form
    {
        List<Carrera> listaCarreras;
        public CarrerasForm()
        {
            InitializeComponent();
            LoadData();
        }
        public void LoadData() {
            listaCarreras = CarreraService.findAll();
            comboBox1.Items.Clear();
            dataGridView1.Rows.Clear();
            if (listaCarreras != null)
            {
                foreach (Carrera x in listaCarreras)
                {
                    dataGridView1.Rows.Add(
                            x.Id,
                            x.Nombre,
                            x.Fecha.ToString(),
                            x.Categoria.Nombre,
                            x.ListaPilotos.Count().ToString()
                                );
                    comboBox1.Items.Add(x.Nombre);
                    
                }
            }
        }
        //agregar
        private void button1_Click(object sender, EventArgs e)
        {
            CarrerasForm formularioActual = this;
             new CarrerasAdd(ref formularioActual).Show();
            formularioActual.Enabled = false;
        }
        //modificar
        private void button2_Click(object sender, EventArgs e)
        {
            int i = dataGridView1.CurrentRow.Index;
            Carrera x = CarreraService.findOneId(int.Parse(dataGridView1.Rows[i].Cells[0].Value.ToString()));
            if (x != null)
            {
                CarrerasForm formularioActual = this;
                new CarrerasUpdate(ref formularioActual, x).Show();
                formularioActual.Enabled = false;
            }
        }
        //eliminar
        private void button3_Click(object sender, EventArgs e)
        {
            try {
                int i = dataGridView1.CurrentRow.Index;
                Carrera x = CarreraService.findOneId(int.Parse(dataGridView1.Rows[i].Cells[0].Value.ToString()));
                if (x != null)
                {
                    CarrerasForm formularioActual = this;
                    new CarrerasRemove(ref formularioActual, x).Show();
                    formularioActual.Enabled = false;
                }
            } catch (Exception) { }
            
        }
        //buscar
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

      

       

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                CarrerasForm k = this;

                new CarrerasRemoveAll(ref k).Show();
            }
            catch (Exception err) { MessageBox.Show(err.Message); }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            CrearPdf.PosicionesPorCategoria();
        }

        private void CarrerasForm_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            CrearPdf.PosicionesParaRadio();
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            CrearPdf.CronometrajeManual();
        }
    }
}
