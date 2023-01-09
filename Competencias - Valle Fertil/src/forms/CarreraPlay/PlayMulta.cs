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
    public partial class PlayMulta : Form
    {
       
        public PlayMulta( )
        {
            InitializeComponent();
            loadData();
        }
        private void loadData() {
            foreach (Participacion x in ParticipacionService.findAll()) {
                comboBox1.Items.Add(x.Vehiculo.ToString());
            }
        }
        // Agregar Multa
        private void button1_Click(object sender, EventArgs e)
        {
            int min = int.Parse(numericUpDown2.Value.ToString());
            int seg = int.Parse(numericUpDown3.Value.ToString());
            int mls = int.Parse(numericUpDown1.Value.ToString());
            TimeSpan tiempo = new TimeSpan(0,0, min, seg,mls);
            Participacion_Multa newMulta = new Participacion_Multa(tiempo);

            try {
                Participacion participacion = ParticipacionService.findVehiculo(int.Parse(comboBox1.Text));
                if (participacion != null)
                {
                    if (participacion.Agregar("m", newMulta))
                    {
                        MessageBox.Show("Multa creda");
                        numericUpDown1.Value = numericUpDown2.Value = numericUpDown3.Value = 0;
                        comboBox1.Text = "";
                        listBox1.Items.Clear();
                    }
                    else
                    {
                        MessageBox.Show("No se pudo agregar la multa");
                    }
                }
                else
                {
                    MessageBox.Show("Seleccionar vehiculo");
                }
            } catch (Exception) { }
            
        }
        //eliminar multa
        private void button2_Click(object sender, EventArgs e)
        {
            try { 
                string[] dat = label9.Text.Split('|');
                string[] dat2 = dat[2].Split(':');
                int day = 0;
                int hour = 0;
                int min = int.Parse(dat2[2]);
                int seg = int.Parse(dat2[3]);
                int mls = int.Parse(dat2[4]);
                Participacion participacion= ParticipacionService.findVehiculo(int.Parse(comboBox1.Text));
                Participacion_Multa multa = new Participacion_Multa(new TimeSpan(0,0,min, seg,mls));
                multa.Id = int.Parse(dat[0]);
                if (participacion.Restar("m", multa)) {
                    int ind = listBox1.SelectedIndex;
                    listBox1.Items.RemoveAt(ind);
                }
                
            } catch (Exception) {
                MessageBox.Show("Error al eliminar multa");
            }
        }
        // seleccionar vehiculo
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            mostrarParticipacion(ParticipacionService.findVehiculo(int.Parse(comboBox1.Text)));
        }
        //
        private void mostrarParticipacion(Participacion participacion) {

            listBox1.Items.Clear();
            foreach(Participacion_Multa x in participacion.AllMultas) {
                listBox1.Items.Add(x.Escribir());
            }
        }

        private void numericUpDown3_ValueChanged(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int ind = listBox1.SelectedIndex;
                label9.Text = listBox1.Items[ind].ToString();
            }
            catch (Exception) { }
        }
    }
}
