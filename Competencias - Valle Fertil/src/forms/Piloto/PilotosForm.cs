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
    public partial class PilotosForm : Form
    {
        List<Piloto> listaPilotos;
        public PilotosForm()
        {
            InitializeComponent();

            LoadData();
        }
        public void LoadData()
        {
            listaPilotos = PilotoService.findAll();
            comboBox1.Items.Clear();
            dataGridView1.Rows.Clear();
            if (listaPilotos != null)
            {
                foreach (Piloto x in listaPilotos)
                {
                    dataGridView1.Rows.Add(
                            x.Id, 
                            x.Nombre, 
                            x.Apellido, 
                            x.Nacimiento, 
                            x.Sexo, 
                            x.Domicilio, 
                            x.Email, 
                            x.Alojamiento, 
                            x.Alergias, 
                            x.Nacionalidad, 
                            x.Edad, 
                            x.Dni, 
                            x.Celular
                                );
                    comboBox1.Items.Add(x.Dni);
                }
            }


        }

        // agregar piloto
        private void button1_Click(object sender, EventArgs e)
        {
            PilotosForm formularioActual = this;
            new PilotosAdd(ref formularioActual).Show();
            formularioActual.Enabled = false;
        }
        // modficiar piloto
        private void button2_Click(object sender, EventArgs e)
        {
            int i = dataGridView1.CurrentRow.Index;
            Piloto x = PilotoService.findOneId(int.Parse(dataGridView1.Rows[i].Cells[0].Value.ToString()));
            if (x != null)
            {
                PilotosForm formularioActual = this;
                 new PilotosUpdate(ref formularioActual, x).Show();
                formularioActual.Enabled = false;
            }
        }
        //eliminar piloto
        private void button3_Click(object sender, EventArgs e)
        {
            int i = dataGridView1.CurrentRow.Index;
            Piloto x = PilotoService.findOneId(int.Parse(dataGridView1.Rows[i].Cells[0].Value.ToString()));
            if (x != null)
            {
                PilotosForm formularioActual = this;
                new PilotosRemove(ref formularioActual, x).Show();
                formularioActual.Enabled = false;
            }
        }
        // seleccionar piloto
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int i = 0;
            while ((i < dataGridView1.RowCount)
                && (dataGridView1.Rows[i].Cells[11].Value.ToString() != comboBox1.Text)) { i++; }
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
