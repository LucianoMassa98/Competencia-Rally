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
using System.Diagnostics;
using System.IO.Ports;
using System.Threading;
namespace Competencias___Valle_Fertil
{
    public partial class PlayArranque : Form
    {
        SemaforoLargada semaforo;
        Stopwatch arranqueAutomatico;
        public PlayArranque()
        {
            InitializeComponent();
            timer1.Start();
            arranqueAutomatico = new Stopwatch();
           semaforo= new SemaforoLargada();
            semaforo.Show();
        }

        // check Modo Automatico
        private void ModoAutomatico_CheckedChanged(object sender, EventArgs e)
        {
            panelAutomatico.Enabled = ModoAutomatico.Checked;
            panel1.Enabled = ModoManual.Checked = !ModoAutomatico.Checked;
            
            if (ModoAutomatico.Checked) {
            
            }

        }
        // check Modo Manual
        private void ModoManual_CheckedChanged(object sender, EventArgs e)
        {
            panel1.Enabled = ModoManual.Checked;
            panelAutomatico.Enabled = ModoAutomatico.Checked= !ModoManual.Checked;
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            bool bandTT = false;
            if (ModoAutomatico.Checked) {

                string vl = DateTime.Now.ToString("tt",CultureInfo.InvariantCulture);
             
                if (vl=="PM") {
                    string[] dat = DateTime.Now.ToString("dd:hh:mm:ss:fff").Split(':');
                    bandTT = true;
                    if (int.Parse(dat[1])<12) {
                        dat[1] = (int.Parse(dat[1]) + 12).ToString();
                    }
                    labelTime.Text = dat[0] + ":" + dat[1] + ":" + dat[2] + ":" + dat[3] + ":" + dat[4];



                }
                else {
                    string[] dat = DateTime.Now.ToString("dd:hh:mm:ss:fff").Split(':');
                    bandTT = true;
                    if (int.Parse(dat[1]) >= 12)
                    {
                        dat[1] = (int.Parse(dat[1]) - 12).ToString();
                    }
                    labelTime.Text = dat[0] + ":" + dat[1] + ":" + dat[2] + ":" + dat[3] + ":" + dat[4];

                //    labelTime.Text = DateTime.Now.ToString("dd:hh:mm:ss:fff"); 
                }

                semaforo.timeNow(labelTime.Text);
            }
          
            if (arranqueAutomatico.IsRunning) {
                
                int seg = int.Parse(numericUpDown2.Value.ToString());
                int min = seg / 60;
             
                if ((arranqueAutomatico.Elapsed.Seconds == 0) 
                    && (arranqueAutomatico.Elapsed.Minutes == 0)
                    && (arranqueAutomatico.Elapsed.Milliseconds > 0)
                    && (arranqueAutomatico.Elapsed.Milliseconds < 500))
                {
                    DateTime sig1 = DateTime.Now.AddSeconds(double.Parse(seg.ToString()));
                    /*if (bandTT) {
                        string[] dat = sig1.ToString("hh:mm:ss").Split(':');

                        if (int.Parse(dat[0])<12) {
                            dat[0] = (int.Parse(dat[0]) + 12).ToString();
                        }
                        label8.Text = dat[0] + ":" + dat[1] + ":" + dat[2];

                        dat[2] = (int.Parse(dat[2]) + seg).ToString();
                        label9.Text = dat[0] + ":" + dat[1] + ":" + dat[2];
                    }
                    else
                    {
                        label8.Text = sig1.ToString("hh:mm:ss");
                        label9.Text = sig1.AddSeconds(double.Parse(seg.ToString())).ToString("hh:mm:ss");
                    }*/

                    label8.Text = sig1.ToString("hh:mm:ss");
                    label9.Text = sig1.AddSeconds(double.Parse(seg.ToString())).ToString("hh:mm:ss");
                    semaforo.setLargada(label8.Text);
                    
                }



                label7.Text = (seg - ((arranqueAutomatico.Elapsed.Minutes*60)+arranqueAutomatico.Elapsed.Seconds)).ToString();
                semaforo.onCounter(label7.Text);
                if (arranqueAutomatico.Elapsed.TotalSeconds 
                    >= seg){
                    string tiempoArranque = labelTime.Text;
                    label7.BackColor = Color.Transparent;
                    listBox1.Items.Add(tiempoArranque);
                    arranqueAutomatico.Restart();
                }

                if (arranqueAutomatico.Elapsed.TotalMinutes+1
                    >= min) {
                    
                    if (arranqueAutomatico.Elapsed.Seconds>=seg-10) {
                       
                        label7.BackColor = Color.Red;
                       //Console.Beep();
                    }
                }
                else
                {
                    
                    label7.BackColor = Color.Transparent;
                }
            }
            
        }
        // agregar arranque
        private void button2_Click(object sender, EventArgs e)
        {
            string tiempoArranque = labelTime.Text;
            listBox1.Items.Add(tiempoArranque);
        }
     
        // seleccion del tiempo automatico
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int ind = listBox1.SelectedIndex;
            try { labelSeleccion.Text = listBox1.Items[ind].ToString(); } catch (Exception) { labelSeleccion.Text = "--:--:--:--:---"; }
           
        }
        // refresh tiempo manual
        private void button3_Click(object sender, EventArgs e)
        {
            dateTimePicker1.Value = DateTime.Now;
        }
        // asignar arranque al piloto
        private void button1_Click(object sender, EventArgs e)
        {
            int vehiculo = int.Parse(numericUpDown1.Value.ToString());
            bool band=false;
            TimeSpan tiempoArranque = seleccioModo(ref band);
            
            if (band) {

                Participacion_Arranque n = new Participacion_Arranque(tiempoArranque);
                Participacion participacion;

                if ((participacion = ParticipacionService.findVehiculo(vehiculo)) != null)
                {
                    if (participacion.Agregar("a", n))
                    {
                       
                        try {listBox1.Items.RemoveAt(listBox1.SelectedIndex);  } catch (Exception) { }

                    }
                    else {  }
                }
                else { MessageBox.Show("Número del vehiculo no válido!!"); }

            }
            else { MessageBox.Show("Error al seleccionar tiempo en automatico"); }
           
        }
           // retorna tiempoArramque segun el modo
        public TimeSpan seleccioModo(ref bool band)
        {
            if (ModoAutomatico.Checked)
            {  // modo automatico

                if (listBox1.Items.Count >0) {
                    band = true;
                    try
                    {
                        string[] datx = labelSeleccion.Text.Split(':');

                        return new TimeSpan(
                            int.Parse(datx[0]),
                            int.Parse(datx[1]),
                            int.Parse(datx[2]),
                            int.Parse(datx[3]),
                            int.Parse(datx[4])
                            );
                    }
                    catch (Exception) { }
                }
                band = false;
                return new TimeSpan();   
               
            }
            // modo manual
                band = true;
            string[] dat = dateTimePicker1.Value.ToString("dd:hh:mm:ss").Split(':');
            if (dateTimePicker1.Value.ToString("tt",CultureInfo.InvariantCulture)=="PM") {

                if (int.Parse(dat[1]) < 12)
                {
                    dat[1] = (int.Parse(dat[1]) + 12).ToString();
                }

            }
            else
            {
                if (int.Parse(dat[1]) >= 12)
                {
                    dat[1] = (int.Parse(dat[1]) - 12).ToString();
                }
            }


                return new TimeSpan(
                    int.Parse(dat[0]),
                    int.Parse(dat[1]),
                    int.Parse(dat[2]),
                    int.Parse(dat[3]),
                    0
                    );
            
        }
        // asignar minutos automaticos
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked) {
                arranqueAutomatico.Start();
            }
            else
            {
                arranqueAutomatico.Restart();
                arranqueAutomatico.Stop();
                label7.Text = "xx Seg";
                label7.BackColor = Color.Transparent;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            CrearTicket nw = new CrearTicket(32);
            nw.datParticipacion(label8);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            CrearTicket nw = new CrearTicket(32);
            nw.datParticipacion(label9);
        }


        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void PlayArranque_FormClosing(object sender, FormClosingEventArgs e)
        {
            semaforo.Close();
        }
    }
}
