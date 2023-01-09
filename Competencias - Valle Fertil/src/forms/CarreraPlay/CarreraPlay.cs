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
    public partial class CarreraPlay : Form
    {
        
        Form anterior;
        private Form activeForm = null;
        public CarreraPlay(ref Form anterior)
        {
            InitializeComponent();

            this.anterior = anterior;
            anterior.Visible = false;

        }

        public void openChildForm(Form childForm)
        {
            if (activeForm != null)
            {
                activeForm.Close();
            }

            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelPrincipal.Controls.Add(childForm);
            panelPrincipal.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        //salir
        private void button1_Click(object sender, EventArgs e)
        {
            anterior.Visible = true;
            Form actual = this;
            actual.Close();
        }
        //abrir arranque
        private void buttonCategoria_Click(object sender, EventArgs e)
        {
            openChildForm(new PlayArranque());
             
        }
        //abrir freno
        private void button2_Click(object sender, EventArgs e)
        {
            openChildForm(new PlayFreno());
        }
        // abrir multa
        private void button3_Click(object sender, EventArgs e)
        {
            openChildForm(new PlayMulta());
        }

        private void panelPrincipal_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            openChildForm(new PlayManual());
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
                openChildForm(new PlayGenerales());
        }

        private void button6_Click(object sender, EventArgs e)
        {
            CarreraPlay form1 = this;
            openChildForm(new SeleccionarCategoria(ref form1));
        }
    }
}
