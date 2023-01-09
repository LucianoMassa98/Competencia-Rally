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
    public partial class PlayGenerales : Form
    {
        Carrera carrera;
        
        List<Participacion> listaOrdenada;
        public PlayGenerales()
        {
            InitializeComponent();
            
            label2.Text = "Posiciones Generales ";

             this.listaOrdenada = ParticipacionService.findAll().OrderBy(x=>x.TiempoTotal()).ToList();
            

            loadData();
        }
        public void loadData()
        {
            List<Participacion> listaIncompletos = new List<Participacion>();
            int pos = 1;
            for (int i = 0; i < listaOrdenada.Count(); i++)
            {
                TimeSpan dif = new TimeSpan();
                if (i > 0)
                {
                    /*  dif = ParticipacionService.diferencia(
                          listaOrdenada[i].TiempoTotal(),
                          listaOrdenada[i - 1].TiempoTotal());*/
                }

                if (listaOrdenada[i].TiempoTotal().ToString() != "00:00:00") {
                dataGridView1.Rows.Add(
                    pos.ToString(),
                    listaOrdenada[i].Vehiculo,
                    listaOrdenada[i].PilotoX.NombreCompleto(),
                    listaOrdenada[i].TiempoNeto().ToString(),
                    listaOrdenada[i].CarreraY.Nombre
                    );
                bool band = false;
                dataGridView2.Rows.Add(
                    listaOrdenada[i].Vehiculo,
                    listaOrdenada[i].Rondas(ref band).ToString(),
                    listaOrdenada[i].AllArranques.Count(),
                    listaOrdenada[i].AllFrenos.Count(),
                    listaOrdenada[i].AllMultas.Count(),
                    listaOrdenada[i].AllAtascados.Count()
                    );
                if (band)
                {
                    dataGridView2.Rows[dataGridView2.RowCount - 1].DefaultCellStyle.BackColor = Color.PaleTurquoise;
                }
                pos++;

                }
                else
                {
                    listaIncompletos.Add(listaOrdenada[i]);
                }
               
            }
            List<string> cnt = new List<string>();
            for (int i =0; i<listaIncompletos.Count;i++) {
                if (cnt.Contains(listaIncompletos[i].CarreraY.Nombre))
                {
                     int ind = cnt.IndexOf(listaIncompletos[i].CarreraY.Nombre);
                    cnt[ind + 1] = (int.Parse(cnt[ind + 1]) + 1).ToString();
                }
                else
                {
                    cnt.Add(listaIncompletos[i].CarreraY.Nombre);
                    cnt.Add("1");
                }

                dataGridView1.Rows.Add(
                       pos.ToString(),
                       listaIncompletos[i].Vehiculo,
                       listaIncompletos[i].PilotoX.NombreCompleto(),
                       listaIncompletos[i].TiempoNeto().ToString(),
                       listaIncompletos[i].CarreraY.Nombre
                       );
                bool band = false;
                dataGridView2.Rows.Add(
                    listaIncompletos[i].Vehiculo,
                    listaIncompletos[i].Rondas(ref band).ToString(),
                    listaIncompletos[i].AllArranques.Count(),
                    listaIncompletos[i].AllFrenos.Count(),
                    listaIncompletos[i].AllMultas.Count(),
                    listaIncompletos[i].AllAtascados.Count()
                    );
                if (band)
                {
                    dataGridView2.Rows[dataGridView2.RowCount - 1].DefaultCellStyle.BackColor = Color.PaleTurquoise;
                }
                pos++;

              

            }


            for (int i =0; i<cnt.Count; i+=2) {

                listBox1.Items.Add(cnt[i]+" - "+cnt[i+1]);
            }


        }
        // imprimir total
        private void button4_Click(object sender, EventArgs e)
        {
            CrearPdf.GeneralesPDF(dataGridView1);
           
        }
        
        //ticket piloto
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {

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
            }
            catch (Exception err) { MessageBox.Show(err.Message); }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }


        private int indexPilotoGrid(string dat) {
            
            for(int i =0; i< dataGridView1.RowCount; i++)
            {
                if (dataGridView1.Rows[i].Cells[1].Value.ToString() == dat) { return i; }
            }
            return dataGridView1.RowCount;
        }
        private void button3_Click(object sender, EventArgs e)
        {
            int idex = indexPilotoGrid(numericUpDown1.Value.ToString());

            if (idex<dataGridView1.RowCount) {

                dataGridView1.CurrentCell = dataGridView1.Rows[idex].Cells[0];
            }
            else
            {
                MessageBox.Show("Vehiculo inexistente!!");
            }
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView2_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void PlayGenerales_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            int i = e.RowIndex;

            string vehiculo = dataGridView1.Rows[i].Cells[1].Value.ToString();

            int j = 0; 

            while ((j < dataGridView2.RowCount) &&(vehiculo!=dataGridView2.Rows[j].Cells[0].Value.ToString())) { j++; }

            if (j < dataGridView2.RowCount) {
                dataGridView2.CurrentCell = dataGridView2.Rows[j].Cells[0];
            }
        }
        //pdf radios
        private void button5_Click(object sender, EventArgs e)
        {
            CrearPdf.PosicionesParaRadio();
        }
        // pdf pilotos
        private void button1_Click(object sender, EventArgs e)
        {
            CrearPdf.PosicionesPorCategoria();
        }
    }
}
