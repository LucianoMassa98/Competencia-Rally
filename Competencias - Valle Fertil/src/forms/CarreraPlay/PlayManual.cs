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
    public partial class PlayManual : Form
    {

       
        public PlayManual()
        {
            InitializeComponent();
            timer1.Start();
        }

      
        private void timer1_Tick(object sender, EventArgs e)
        {
            
            string vl = DateTime.Now.ToString("tt", CultureInfo.InvariantCulture);

            if (vl == "PM")
            {
                string[] dat = DateTime.Now.ToString("dd:hh:mm:ss:fff").Split(':');
                 if (int.Parse(dat[1]) < 12) {
                    dat[1] = (int.Parse(dat[1]) + 12).ToString();
                }
                
                labelTime.Text = dat[0] + ":" + dat[1] + ":" + dat[2] + ":" + dat[3] + ":" + dat[4];
            }
            else { labelTime.Text = DateTime.Now.ToString("dd:hh:mm:ss:fff"); }


        }
        // agregar  tiempoLlegada
        private void button2_Click(object sender, EventArgs e)
        {
            string tiempoLlegada= labelTime.Text;
            listBox1.Items.Add(tiempoLlegada);
        }
 
        // asignar tiempos al piloto
        private void button1_Click(object sender, EventArgs e)
        {
            int vehiculo = int.Parse(numericUpDown1.Value.ToString());
            bool band = false;
            TimeSpan tiempoFreno = seleccioMeta(ref band);
            string[] dat = dateTimePicker1.Value.ToString("dd:hh:mm:ss").Split(':');
           
            if (dateTimePicker1.Value.ToString("tt", CultureInfo.InvariantCulture) == "PM")
            {
                if (int.Parse(dat[1]) < 12)
                { dat[1] = (int.Parse(dat[1]) + 12).ToString(); }
                   
            }
            TimeSpan tiemLargada = new TimeSpan(
                int.Parse(dat[0]),
                int.Parse(dat[1]),
                int.Parse(dat[2]),
                int.Parse(dat[3]),
                0
                );
            if (band) {
                if (tiempoFreno.TotalMinutes > tiemLargada.TotalMinutes)
                {
                    Participacion_Arranque m = new Participacion_Arranque(tiemLargada);
                    Participacion_Freno fre = new Participacion_Freno(tiempoFreno);
                    Participacion participacion;

                    if ((participacion = ParticipacionService.findVehiculo(vehiculo)) != null)
                    {
                        if (participacion.Agregar("a", m))
                        {

                            if (participacion.Agregar("f", fre))
                            {
                                listBox1.Items.RemoveAt(listBox1.SelectedIndex);
                            }
                            else { MessageBox.Show("Este vehiculo ya tien un freno"); }

                            CrearTicket n = new CrearTicket(32);
                            n.datParticipacion(participacion);

                        }
                        else { MessageBox.Show("Este vehiculo ya tiene una largada"); }
                        
                    }
                    else { MessageBox.Show("Número del vehiculo no válido!!"); }
                }
                else
                {
                    MessageBox.Show("Error, la llegada debe ser despues de la largada");
                }
                   

            }
            else { MessageBox.Show("Error, llegada no seleccionada!!"); }
           
        }
           // retorna tiempoArramque segun el modo
        public TimeSpan seleccioMeta(ref bool band)
        {
          
                if (listBox1.Items.Count > 0) {
                    band = true;
                    try
                    {
                    string[] dat = labelSeleccion.Text.Split(':');

                    return new TimeSpan(
                        int.Parse(dat[0]),
                        int.Parse(dat[1]),
                        int.Parse(dat[2]),
                        int.Parse(dat[3]),
                        int.Parse(dat[4])
                                         );
                }
                    catch (Exception) { }
                }
            band = false;
                return new TimeSpan();  
        }

        // seleccion del tiempo automatico
        private void listBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

            int ind = listBox1.SelectedIndex;
            try { labelSeleccion.Text = listBox1.Items[ind].ToString(); } catch (Exception) { labelSeleccion.Text = "--:--:--:--:---"; }

        }

       

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
