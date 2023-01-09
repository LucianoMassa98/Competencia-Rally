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
    public partial class SemaforoLargada : Form
    {
        public SemaforoLargada()
        {
            InitializeComponent();
           
        }
        public void onGreen() {
            panel3.BackColor = Color.Green;
            panel4.BackColor = Color.Green;
            label2.ForeColor = Color.Green;
            Console.Beep();
        }
        public void onRed() {
            panel3.BackColor = Color.Red;
            panel4.BackColor = Color.Red;
            

            int num = int.Parse(label2.Text);
            if ((num<=10)&& (num >= 2))
            {
                label2.ForeColor = Color.Red;
            }
            else {
                if (num>10) { label2.ForeColor = Color.Black; }
                 }
        }
        public void onCounter(string count) {

            if (count.Length==2) { count = "0"+count; } else
            {
                if (count.Length == 1) { count = "00" + count; }
            }
            label2.Text = count;
            if ((label2.Text == "000") ||(label2.Text == "001")) {
                onGreen();
            }
            else
            {
                onRed();
            }
        
        }

        public void timeNow(string time) { label3.Text = time; }
        public void setLargada(string largada) { label1.Text = largada; }

        private void SemaforoLargada_Load(object sender, EventArgs e)
        {

        }

        public void ModoNocturno() { }
        public void ModoDiario() { }
    }
}
