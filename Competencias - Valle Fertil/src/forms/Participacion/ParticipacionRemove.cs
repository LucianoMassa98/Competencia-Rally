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
    public partial class ParticipacionRemove : Form
    {
        ParticipacionesForm Anterior;
        Participacion participacion;
        public ParticipacionRemove(ref ParticipacionesForm x,object participacion)
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
            label10.Text = this.participacion.Vehiculo.ToString();
            label11.Text = this.participacion.AllArranques[0].Value.ToString();
            
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
           if (ParticipacionService.delete(this.participacion.Id))
            {
                Form actual = this;
                Anterior.Enabled = true;
                Anterior.LoadData();
                actual.Close();
            }

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }
    }
}
