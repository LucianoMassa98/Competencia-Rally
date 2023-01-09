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
    public partial class AddRonda : Form
    {
        
        Stopwatch arranqueAutomatico;
        Participacion piloto;
        detallePiloto formPiloto;
        public AddRonda(object x, ref detallePiloto anterior)
        {
            InitializeComponent();
           
            arranqueAutomatico = new Stopwatch();
            piloto = (Participacion)x;
            formPiloto = anterior;
            label6.Text = "Vehículo: " + piloto.Vehiculo;
            dateTimePicker1.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day,0,0,0);
        }
       
        
        // asignar arranque al piloto
        private void button1_Click(object sender, EventArgs e)
        {
            int vehiculo = piloto.Vehiculo;
            bool band=false;
            
            TimeSpan tiempoFreno= seleccioTiempo();
            TimeSpan tiempoArranque = new TimeSpan(tiempoFreno.Days, 12, 0, 0, 0);
            Participacion_Arranque nA = new Participacion_Arranque(tiempoArranque);
                    if (piloto.Agregar("a", nA))
                    {
                Participacion_Freno n = new Participacion_Freno(tiempoFreno);
                if (piloto.Agregar("f",n))
                {
                    Form k = this;
                    formPiloto.Close();
                    k.Close();
                }
                else
                {
                    MessageBox.Show("Error al agregar llegada");
                }
              
                    }
                    else {
                    MessageBox.Show("Error al agregar largada");
                    }
        }
         
        public TimeSpan seleccioTiempo()
        {
            string[] dat = dateTimePicker1.Value.ToString("dd:hh:mm:ss").Split(':');
            if (dateTimePicker1.Value.ToString("tt",CultureInfo.InvariantCulture)=="PM") {

                if (int.Parse(dat[1]) < 12)
                {
                    dat[1] = (int.Parse(dat[1]) + 12).ToString();
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

        private void button6_Click(object sender, EventArgs e)
        {
            Form k = this;
            formPiloto.Visible = true;
            k.Close();
        }
    }
}
