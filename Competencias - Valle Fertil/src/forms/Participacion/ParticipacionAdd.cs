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
    public partial class ParticipacionAdd : Form
    {
        ParticipacionesForm Anterior;
        public ParticipacionAdd(ref ParticipacionesForm x)
        {
            InitializeComponent();
            Anterior = x;
            loadData();
        }
        public void loadData()
        {
            List<Piloto> litaP = PilotoService.findAll();
            foreach(Piloto x in litaP)
            {
                comboBox1.Items.Add(x.Dni);
            }
            List<Carrera> listaC = CarreraService.findAll();
            foreach (Carrera x in listaC)
            {
                comboBox2.Items.Add(x.Nombre);
            }

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
            string com = comboBox3.Text;
            /*MonoPlaza
            MonoPlaza-Kids
            Binomio*/
            switch (com) { 
            case "MonoPlaza": { break; }
            case "MonoPlaza-Kids": { break; }
            case "Binomio": { break; }
            default: { com = "no"; break; }
            }

            if (com!="no") {
                Participacion newParticipacion = new Participacion();

                newParticipacion.Id = 0;
                newParticipacion.PilotoX = PilotoService.findOneDni(int.Parse(comboBox1.Text));
                newParticipacion.Vehiculo = int.Parse(numericUpDown3.Value.ToString());
                newParticipacion.CarreraY = CarreraService.findOneNombre(comboBox2.Text);
                Participacion parCreated = ParticipacionService.create(newParticipacion);

                if (parCreated != null)
                {
                    

                    switch (com)
                    {
                        case "MonoPlaza": { CrearPdf.InscripcionPDF(parCreated); break; }
                        case "MonoPlaza-Kids": { CrearPdf.InscripcionPDF2(parCreated);  break; }
                        case "Binomio": { CrearPdf.InscripcionPDF3(parCreated);  break; }
                    }
                    Form actual = this;
                    Anterior.Enabled = true;
                    Anterior.LoadData();
                    actual.Close();
                }
            }
            

        }

        private void ParticipacionAdd_Load(object sender, EventArgs e)
        {

        }
    }
}
