using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Competencias___Valle_Fertil
{
    static class PilotoSchema
    {
        static public bool createPiloto(Piloto x) {

            if (x.Nombre=="") { MessageBox.Show("Nombre inválido"); return false; }
            if (x.Apellido == "") { MessageBox.Show("Apellido inválido"); return false; }
            //if (x.Nacimiento == "") { MessageBox.Show("Nacimiento Inválido");  return false; }
            //if (x.Sexo == "") { MessageBox.Show("Sexo Inválido");  return false; }
            //if (x.Domicilio == "") { MessageBox.Show("Domicilio Inválido"); return false; }
            //if (x.Email == "") { MessageBox.Show("Email Inválido"); return false; }
            //if (x.Alojamiento == "") { MessageBox.Show("Alojamiento Inválido"); return false; }
            //if (x.Alergias == "") { MessageBox.Show("Alergias Inválido"); return false; }
            //if (x.Nacionalidad == "") { MessageBox.Show("Nacionalidad Inválido"); return false; }
            //if (x.Edad <=0) { MessageBox.Show("Edad Inválido"); return false; }
            if (x.Dni <= 0) { MessageBox.Show("Dni Inválido"); return false; }
          //  if (x.Celular=="") { MessageBox.Show("Celular Inválido"); return false; }
            return true;

        }

    }
}
