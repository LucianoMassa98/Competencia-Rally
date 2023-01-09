using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Competencias___Valle_Fertil
{
    internal class ParticipacionSchema
    {
        static public bool createParticipacion(Participacion x)
        {

            if (x.PilotoX == null) { MessageBox.Show("Falta piloto"); return false; }
            if (x.CarreraY == null) { MessageBox.Show("Falta carrera");  return false; }
          //  if (x.PilotoX.Categoria.Id != x.CarreraY.Categoria.Id) { MessageBox.Show("El piloto y la carrea son de diferente categoria"); return false; }
            if (ParticipacionService.findVehiculo( x.Vehiculo)!=null) { MessageBox.Show("El Numero de vehiculo ya existe en las inscripciones "); return false; }
            if (ParticipacionService.findPiloto(x.PilotoX.Id) != null) { MessageBox.Show("El piloto ya se encuentra inscripto en la carrera "); return false; }
            return true;

        }
    }
}
