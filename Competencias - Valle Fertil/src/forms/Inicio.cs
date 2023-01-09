namespace Competencias___Valle_Fertil
{
    public partial class Inicio : Form
    {
        private Form activeForm=null;
        public Inicio()
        {
            InitializeComponent();
        }
        private void openChildForm(Form childForm) {
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
        //abrir form categorias
        private void buttonCategoria_Click(object sender, EventArgs e)
        {
            openChildForm(new CategoriasForm());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form actual = this;
            actual.Close();
        }
        // abrir form pilotos
        private void button2_Click(object sender, EventArgs e)
        {
            openChildForm(new PilotosForm());
        }
        // abrir form carreras
        private void button3_Click(object sender, EventArgs e)
        {
            openChildForm(new CarrerasForm());
        }
        //abrir inscripciones
        private void button4_Click(object sender, EventArgs e)
        {
            openChildForm(new ParticipacionesForm());
        }

        private void panelMenu_Paint(object sender, PaintEventArgs e)
        {

        }
        // abrir sistema de juego
        private void button5_Click_1(object sender, EventArgs e)
        {

            try
            {
                Form k = this;
                new CarreraPlay(ref k).Show();
            }
            catch (Exception err) { MessageBox.Show(err.Message); }
        }
    }
}