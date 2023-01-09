using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
namespace Competencias___Valle_Fertil
{
    public partial class PlayPosiciones : Form
    {
        Carrera carrera;
        List<Participacion> listaOrdenada;
        public PlayPosiciones(int idCarrera)
        {
            InitializeComponent();
            carrera = CarreraService.findOneId(idCarrera);
            label2.Text = "Posiciones de " + carrera.Nombre;
            this.listaOrdenada = carrera.ListaPilotos.OrderBy(x => x.TiempoTotal()).ToList();
            loadData();
        }
        public void loadData()
        {
            int pos = 1;


            List<Participacion> listaFaltante = new List<Participacion>();
                for (int i =0; i<listaOrdenada.Count();i++) {
                TimeSpan dif = new TimeSpan();
                if (i>0) {
                    dif = ParticipacionService.diferencia(
                        listaOrdenada[i].TiempoTotal(), 
                        listaOrdenada[i-1].TiempoTotal()); 
                    }

                if (listaOrdenada[i].TiempoTotal().ToString()!="00:00:00") {
                    dataGridView1.Rows.Add(
                      pos.ToString(),
                      listaOrdenada[i].Vehiculo,
                      listaOrdenada[i].PilotoX.NombreCompleto(),
                      listaOrdenada[i].TiempoMulta().ToString(),
                      listaOrdenada[i].TiempoNeto().ToString(),
                      listaOrdenada[i].TiempoTotal().ToString()
                      );

                    for (int j = 0;j< listaOrdenada[i].DetalleRondas().Count();j+=3) {
                        dataGridView1.Rows.Add(listaOrdenada[i].DetalleRondas()[j], listaOrdenada[i].DetalleRondas()[j + 1], listaOrdenada[i].DetalleRondas()[j + 2]);
                    }

                    dataGridView1.Rows.Add();

                    bool band = false;
                    dataGridView2.Rows.Add(
                        listaOrdenada[i].Vehiculo,
                        listaOrdenada[i].Rondas(ref band).ToString(),
                        listaOrdenada[i].AllArranques.Count(),
                        listaOrdenada[i].AllFrenos.Count(),
                        listaOrdenada[i].AllMultas.Count()
                        );

                    if (band)
                    {
                        dataGridView2.Rows[dataGridView2.RowCount - 1].DefaultCellStyle.BackColor = Color.PaleTurquoise;
                    }
                    pos++;
                }
                else
                {
                    listaFaltante.Add(listaOrdenada[i]);
                }

                  
            }

            for (int i = 0; i< listaFaltante.Count;i++) {

                dataGridView1.Rows.Add(
                      "Incompleto",
                      listaFaltante[i].Vehiculo,
                      listaFaltante[i].PilotoX.NombreCompleto(),
                      listaFaltante[i].TiempoMulta().ToString(),
                      listaFaltante[i].TiempoNeto().ToString(),
                      listaFaltante[i].TiempoTotal().ToString()
                
                      );
            }
                         
            

        }
        // imprimir total
        private void button4_Click(object sender, EventArgs e)
        {
            CrearPdf.PosicionesPDF(carrera,dataGridView1);
           
        }
        //volver
        private void button1_Click(object sender, EventArgs e)
        {
            
        }
        //ticket piloto
        private void button2_Click(object sender, EventArgs e)
        {
            try {

                if (dataGridView1.RowCount > 0)
                {
                    int ind = dataGridView1.CurrentRow.Index;
                    int vehiculo = int.Parse(dataGridView1.Rows[ind].Cells[1].Value.ToString());
                    Participacion newPart = ParticipacionService.findVehiculo(vehiculo);
                    if (newPart != null)
                    {
                        new detallePiloto(newPart).Show();
                    }
                }
            } catch (Exception err) { MessageBox.Show(err.Message); }
        }

        private void button3_Click(object sender, EventArgs e)
        {

            // buscar tiempos de ronda 
            List<TimeSpan> listMayores = new List<TimeSpan>();

            for(int i =0; i < dataGridView1.RowCount; i++)
            {
                if (dataGridView1.Rows[i].Cells[2].Value!=null) {
                    try
                    {
                        string dat = dataGridView1.Rows[i].Cells[2].Value.ToString();

                        TimeSpan s = TimeSpan.Parse(dat);

                        if (dataGridView1.Rows[i+1].Cells[2].Value == null) { listMayores.Add(s); }
                        


                    }
                    catch (Exception) { }
                }
                
            }
            

            if (listMayores.Count>0) {
                listMayores = listMayores.OrderBy(x => x.TotalMinutes).ToList();

                TimeSpan mayor = listMayores[listMayores.Count - 1];
                MessageBox.Show("Mayor tiempo: "+mayor.ToString());

               TimeSpan nuevo =  mayor.Add(new TimeSpan(0,0,5,0,0));
                MessageBox.Show("Mayor tiempo + Adicional agregado: " + nuevo.ToString());

                for (int i = 0; i < dataGridView1.RowCount; i++)
                {
                    if (dataGridView1.Rows[i].Cells[0].Value != null)
                    {
                        try
                        {
                            string dat = dataGridView1.Rows[i].Cells[0].Value.ToString();

                            

                            if (dat== "Incompleto") {


                                // completar ronda
                                string vehiculo = dataGridView1.Rows[i].Cells[1].Value.ToString();

                                Participacion newPart = ParticipacionService.findVehiculo(int.Parse(vehiculo));

                                if (newPart!=null) {

                                    newPart.Arranques = newPart.AllArranques;
                                    newPart.Frenos = newPart.AllFrenos;
                                    newPart.Atascos = newPart.AllAtascados;


                                    if (newPart.Arranques.Count == newPart.Frenos.Count + 1)
                                    {



                                        if (newPart.Atascos.Count>0)
                                        {
                                            if (newPart.Atascos[newPart.Atascos.Count - 1].Value.ToString() == "00:00:00")
                                            {

                                                TimeSpan nuevox = newPart.Arranques[newPart.Arranques.Count - 1].Value.Add(nuevo);

                                               // MessageBox.Show("agregar nuevo: " + nuevox.ToString());

                                                // crearfreno
                                                Participacion_Freno newFreno = new Participacion_Freno(nuevox);
                                                newPart.Agregar("f",newFreno);
                                                //actualizar atasco
                                                Participacion_Atascado newAtasco = new Participacion_Atascado(nuevox);
                                                newPart.Restar("at", newPart.Atascos[newPart.Atascos.Count - 1]);
                                                newPart.Agregar("at", newAtasco);

                                            }
                                            else
                                            {
                                                MessageBox.Show("El vehiculo: " + newPart.Vehiculo + " No tiene atascos agregados");
                                            }
                                        }
                                        else
                                        {
                                            MessageBox.Show("El vehiculo: " + newPart.Vehiculo + " No tiene atascos agregados");

                                        }

                                    }
                                    else
                                    {
                                        MessageBox.Show("verificar detalles del vehiculo: " + newPart.Vehiculo);
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("no se encontro vehiculo");
                                }

                            }



                        }
                        catch (Exception) { }
                    }

                }

            }
            

        }

        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            int i = e.RowIndex;

            string vehiculo = dataGridView1.Rows[i].Cells[1].Value.ToString();

            int j = 0;

            while ((j < dataGridView2.RowCount) && (vehiculo != dataGridView2.Rows[j].Cells[0].Value.ToString())) { j++; }

            if (j < dataGridView2.RowCount)
            {
                dataGridView2.CurrentCell = dataGridView2.Rows[j].Cells[0];
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void PlayPosiciones_Load(object sender, EventArgs e)
        {

        }
    }
}
