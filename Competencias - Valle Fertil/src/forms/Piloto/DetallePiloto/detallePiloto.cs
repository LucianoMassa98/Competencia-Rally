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
    public partial class detallePiloto : Form
    {
        Participacion participacion;
        public detallePiloto(object x)
        {
            InitializeComponent();
            participacion = (Participacion)x;
            loadData();
        }
        public void loadData() {

            label2.Text = "Piloto: "+participacion.PilotoX.NombreCompleto();
            label3.Text = "Vehiculo: "+ participacion.Vehiculo;
            label4.Text = "Categoría: "+participacion.CarreraY.Nombre;
         //   List<string> list = participacion.DetalleRondas();
            participacion.Arranques = participacion.AllArranques;
            participacion.Frenos = participacion.AllFrenos;
            participacion.Atascos = participacion.AllAtascados;
            textBox1.Text = participacion.Rondas().ToString();
            int n = participacion.Arranques.Count();

            if (n<participacion.Frenos.Count()) { n = participacion.Frenos.Count(); }

            for (int i =0; i<n;i++) {

                try { listBox1.Items.Add(participacion.Arranques[i].Escribir()); } 
                catch (Exception) { listBox1.Items.Add("pendiente"); }
                try { listBox2.Items.Add(participacion.Frenos[i].Escribir()); }
                catch (Exception)
                {
                    listBox2.Items.Add("pendiente");
                }
            }

            for (int i = 0; i<participacion.Atascos.Count();i++) {

                listBox3.Items.Add(participacion.Atascos[i].Escribir());

            }


            label7.Text = "Total: " + participacion.TiempoTotal();
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
                    if (participacion != null)
                    {
                        CrearTicket n = new CrearTicket(32);
                        n.datParticipacion(participacion);
                    }
                
        }


        private void button1_Click(object sender, EventArgs e)
        {
            Form k = this;
            k.Close();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        // eliminar largadas
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                string[] dat = listBox1.Items[listBox1.SelectedIndex].ToString().Split('|');
                Participacion_Arranque arranque = new Participacion_Arranque(dat);
                
                if (participacion.Restar("a", arranque))
                {
                    int ind = listBox1.SelectedIndex;
                    listBox1.Items.RemoveAt(ind);
                }

            }
            catch (Exception)
            {
                MessageBox.Show("Seleccionar largada");
            }
        }
        // eliminar llegadas
        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                int ind = listBox2.SelectedIndex;
                string[] dat = listBox2.Items[ind].ToString().Split('|');
                Participacion_Freno llegada= new Participacion_Freno(dat);
                if (participacion.Restar("f", llegada))
                {  
                    listBox2.Items.RemoveAt(ind);
                }

            }
            catch (Exception)
            {
                MessageBox.Show("Seleccionar llegada");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            detallePiloto k = this;
            k.Visible = false;
            new AddArranque(participacion, ref k).Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            detallePiloto k = this;
            k.Visible = false;
            new AddFreno(participacion, ref k).Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            detallePiloto k = this;
            k.Visible = false;
            new AddRonda(participacion, ref k).Show();
        }

        private void detallePiloto_Load(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {

            try
            {
                int ind = listBox3.SelectedIndex;
                string[] dat = listBox3.Items[ind].ToString().Split('|');
                Participacion_Atascado atasco = new Participacion_Atascado(dat);
                if (participacion.Restar("at", atasco))
                {
                    listBox3.Items.RemoveAt(ind);
                }

            }
            catch (Exception)
            {
                MessageBox.Show("Seleccionar Atasco");
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            try
            {
              
                Participacion_Atascado atasco = new Participacion_Atascado(new TimeSpan(0,0,0,0,0));
                participacion.Agregar("at", atasco);
            }
            catch (Exception)
            {
                MessageBox.Show("Error al agregar Atasco");
            }
        }
    }
}
