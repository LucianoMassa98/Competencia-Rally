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
    public partial class PlayFreno  : Form
    {

       
        public PlayFreno()
        {
            InitializeComponent();
            timer1.Start();
        }

        // check Modo Automatico
        private void ModoAutomatico_CheckedChanged(object sender, EventArgs e)
        {
            panelAutomatico.Enabled = true;
            panel1.Enabled = ModoManual.Checked =checkBox1.Checked= false;
            

        }
        // check Modo Manual
        private void ModoManual_CheckedChanged(object sender, EventArgs e)
        {
            panel1.Enabled = true;
            panelAutomatico.Enabled = ModoAutomatico.Checked= checkBox1.Checked = false;
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (ModoAutomatico.Checked) {
               // labelTime.Text = DateTime.Now.ToString("dd:hh:mm:ss:fff");
                string vl = DateTime.Now.ToString("tt", CultureInfo.InvariantCulture);

                if (vl == "PM")
                {
                    string[] dat = DateTime.Now.ToString("dd:hh:mm:ss:fff").Split(':');
                    if (int.Parse(dat[1])<12) {
                        dat[1] = (int.Parse(dat[1]) + 12).ToString();
                    }
                    labelTime.Text = dat[0] + ":" + dat[1] + ":" + dat[2] + ":" + dat[3] + ":" + dat[4];
                }
                else {

                    string[] dat = DateTime.Now.ToString("dd:hh:mm:ss:fff").Split(':');

                    if (int.Parse(dat[1]) >= 12)
                    {
                        dat[1] = (int.Parse(dat[1]) - 12).ToString();
                    }
                    labelTime.Text = dat[0] + ":" + dat[1] + ":" + dat[2] + ":" + dat[3] + ":" + dat[4];

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
            string band="";
            TimeSpan tiempoFreno= seleccioModo(ref band);


            switch (band) {

                case "true": {
                        Participacion_Freno n = new Participacion_Freno(tiempoFreno);
                        Participacion participacion;

                        if ((participacion = ParticipacionService.findVehiculo(vehiculo)) != null)
                        {
                            if (participacion.Agregar("f", n))
                            {
                                MessageBox.Show("Freno creado exitosamente");
                                try { listBox1.Items.RemoveAt(listBox1.SelectedIndex); } catch (Exception) { }

                                numericUpDown1.Value = 0;
                                CrearTicket nw = new CrearTicket(32);
                                nw.datParticipacion(participacion);
                            }
                            else { MessageBox.Show("Este vehiculo ya tien un freno"); }
                        }
                        else { MessageBox.Show("Número del vehiculo no válido!!"); }
                        break; }
                case "false": {
                        MessageBox.Show("Error al asignar el tiempo");
                        break; }
                case "at": {
                        Participacion_Atascado n = new Participacion_Atascado(tiempoFreno);
                        Participacion participacion;

                        if ((participacion = ParticipacionService.findVehiculo(vehiculo)) != null)
                        {
                            if (participacion.Agregar("at", n))
                            {
                                MessageBox.Show("Vehiculo atascado");
                                try { listBox1.Items.RemoveAt(listBox1.SelectedIndex); } catch (Exception) { }

                                numericUpDown1.Value = 0;
                                CrearTicket nw = new CrearTicket(32);
                                nw.datParticipacion(participacion);
                            }
                            else { MessageBox.Show("Error al agregar atasco"); }
                        }
                        else { MessageBox.Show("Número del vehiculo no válido!!"); }
                        break; }
                default: { break; }
            }
           
        }
           // retorna tiempoArramque segun el modo
        public TimeSpan seleccioModo(ref string band)
        {
            // modo automatico
            if (ModoAutomatico.Checked)
            {  

                if (listBox1.Items.Count > 0) {
                  
                    try
                    {
                        string[] datx = labelSeleccion.Text.Split(':');
                        band = "true";
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
                band = "false";
                return new TimeSpan();   
               
            }
            // modo manual
            if (ModoManual.Checked) {
                
                
                string[] dat = dateTimePicker1.Value.ToString("dd:hh:mm:ss").Split(':');
                if (dateTimePicker1.Value.ToString("tt", CultureInfo.InvariantCulture) == "PM")
                {
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

                band = "true";
                return new TimeSpan(
                    int.Parse(dat[0]),
                    int.Parse(dat[1]),
                    int.Parse(dat[2]),
                    int.Parse(dat[3]),
                    0
                    );
            }

            // Atascado
            band = "at";
            return new TimeSpan(0, 0, 0, 0, 0);

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            
        }

        private void PlayFreno_Load(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            
           panel1.Enabled = panelAutomatico.Enabled = ModoAutomatico.Checked = ModoManual.Checked = false;
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
