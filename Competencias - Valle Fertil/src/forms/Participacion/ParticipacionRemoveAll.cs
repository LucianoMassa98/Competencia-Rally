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
    public partial class ParticipacionRemoveAll : Form
    {
        ParticipacionesForm Anterior;
        public ParticipacionRemoveAll(ref ParticipacionesForm x)
        {
            InitializeComponent();
            Anterior = x;
            loadData();
        }
        public void loadData()
        {
            label8.Text = "Total: " + ParticipacionService.findAll().Count();
            
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
           if (ParticipacionService.deleteAll())
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
