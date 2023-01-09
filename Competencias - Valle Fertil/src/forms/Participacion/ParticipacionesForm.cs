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
    public partial class ParticipacionesForm : Form
    {
        List<Participacion> listaParticipaciones;
        public ParticipacionesForm()
        {
            InitializeComponent();
            LoadData();
        }
        public void LoadData()
        {
            listaParticipaciones = ParticipacionService.findAll();
            dataGridView1.Rows.Clear(); comboBox1.Items.Clear();
                foreach (Participacion x in listaParticipaciones) {
                    dataGridView1.Rows.Add(
                        x.Id,
                        x.PilotoX.NombreCompleto(),
                        x.Vehiculo.ToString(),
                        x.CarreraY.Nombre
                        );
                comboBox1.Items.Add(x.Vehiculo.ToString());
                }
            
        }

        //agregar
        private void button1_Click(object sender, EventArgs e)
        {
            ParticipacionesForm k = this;
            new ParticipacionAdd(ref k).Show();
        }
        //modificar
        private void button2_Click(object sender, EventArgs e)
        {
            int i = dataGridView1.CurrentRow.Index;
            Participacion x = ParticipacionService.findOneId(int.Parse(dataGridView1.Rows[i].Cells[0].Value.ToString()));
            if (x != null)
            {
                //x.Arranques = PilotoService.findAllforCategoria(x.Id);
                ParticipacionesForm formularioActual = this;
                new ParticipacionUpdate(ref formularioActual, x).Show();
                formularioActual.Enabled = false;
            }
        }
        //eliminar
        private void button3_Click(object sender, EventArgs e)
        {
            int i = dataGridView1.CurrentRow.Index;
            Participacion x = ParticipacionService.findOneId(int.Parse(dataGridView1.Rows[i].Cells[0].Value.ToString()));


           
            if (x != null)
            {

                ParticipacionesForm k = this;
                new ParticipacionRemove(ref k, x).Show();

                k.Enabled = false;
            }
        }
        //buscar
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int i = 0;
            while ((i < dataGridView1.RowCount)
                && (dataGridView1.Rows[i].Cells[2].Value.ToString() != comboBox1.Text)) { i++; }
            if (i < dataGridView1.RowCount)
            {
                dataGridView1.CurrentCell = dataGridView1.Rows[i].Cells[0];
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ParticipacionesForm k = this;
            new ParticipacionRemoveAll(ref k).Show();

            k.Enabled = false;
        }
    }
}
