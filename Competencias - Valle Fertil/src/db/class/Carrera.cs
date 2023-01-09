using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Competencias___Valle_Fertil
{
    internal class Carrera
{
        int id;
        string nombre;
        DateTime fecha;

        Categoria categoria;
        List<Participacion> listaParticipantes;

        public Carrera() { listaParticipantes = new List<Participacion>(); }
        public Carrera(string[] dat)
        {
            if (dat.Length == 4)
            {
                id = int.Parse(dat[0]);
                nombre = dat[1];
                fecha = DateTime.Parse(dat[2]);
                categoria = CategoriaService.findOneId(int.Parse(dat[3]));
                listaParticipantes = new List<Participacion>();
            }

        }
        public string Nombre { get { return nombre; } set { nombre = value; } }
        public int Id { get { return id; } set { id = value; } }
        public Categoria Categoria { get { return categoria; } set { categoria = value; } }
        public DateTime Fecha { get { return fecha; } set { fecha = value; } }

        public List<Participacion> ListaPilotos { get { return ParticipacionService.findAllforCarrera(id); } set { listaParticipantes = value; } }

        public Participacion findOneVehiculo(int numVehiculo) {
            
            Participacion newParticipacion  = new Participacion();
            foreach(Participacion x in ListaPilotos) {
                if (x.Vehiculo==numVehiculo) { return x; }
            }
            return null;
        
        }

        public string Escribir() { 
            return 
                id + "|" +
                nombre + "|" +
                fecha.ToString() + "|" +
                categoria.Id ; 
        }
    }
}
