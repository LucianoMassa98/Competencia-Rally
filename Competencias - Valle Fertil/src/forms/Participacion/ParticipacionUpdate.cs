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
    public partial class ParticipacionUpdate : Form
    {
        ParticipacionesForm Anterior;
        Participacion participacion;
        public ParticipacionUpdate(ref ParticipacionesForm x, object participacion)
        {
            InitializeComponent();
            Anterior = x;
            this.participacion = (Participacion)participacion;
            loadData();
        }
        public void loadData()
        {
            label8.Text = this.participacion.PilotoX.NombreCompleto();
            label9.Text = this.participacion.CarreraY.Nombre;
            numericUpDown3.Value = this.participacion.Vehiculo;
           // dateTimePicker1.Value = this.participacion.AllArranques[0].Value;

        }
        //cancelar
        private void button3_Click(object sender, EventArgs e)
        {
            Form actual = this;

            Anterior.Enabled = true;
            actual.Close();
        }
        //confirmar
        private void button2_Click(object sender, EventArgs e)
        {
            participacion.Vehiculo = int.Parse(numericUpDown3.Value.ToString());
            
            participacion.Agregar("a", new Participacion_Arranque(new TimeSpan(0,0,0,0,0)));


            if (ParticipacionService.update(participacion.Id, participacion)!=null) {
                Anterior.Enabled = true;
                Anterior.LoadData();
                Form actual = this;
                actual.Close();
            }
            else
            {
                MessageBox.Show("No se pudo modificar la inscripción");
            }
            

        }
    }
}
