using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Competencias___Valle_Fertil
{
    internal class ParticipacionService
    {

        static public Participacion create(Participacion x)
        {

            if (ParticipacionSchema.createParticipacion(x)) {
                List<Participacion> participaciones = findAll();
                if (participaciones.Count() == 0)
                {
                    x.Id = 1;
                }
                else
                {
                    x.Id = participaciones[participaciones.Count() - 1].Id + 1;
                }

                //x.Arranques[0].ParticipacionX = x;
                participaciones.Add(x);
                if (ParticipacionService.Guardar(participaciones))
                {
                    return x;
                }
            }
                
            
            return null;
        }
        static public Participacion add_arranque(Participacion_Arranque x)
        {
           Participacion participacion=  ParticipacionService.findOneId(x.ParticipacionX.Id);

            if (participacion != null)
            {

                participacion.Agregar("a",x);

            }
            else { MessageBox.Show("Participacion Inexistente"); }
            
            return null;
        }
        static public Participacion add_freno(Participacion_Freno x)
        {

            Participacion participacion = ParticipacionService.findOneId(x.ParticipacionX.Id);

            if (participacion != null)
            {

                participacion.Agregar("f", x);
            }
            else { MessageBox.Show("Participacion Inexistente"); }
            
            return null;
        }
        static public Participacion add_multa(Participacion_Multa x)
        {

            Participacion participacion = ParticipacionService.findOneId(x.ParticipacionX.Id);

            if (participacion != null)
            {

                participacion.Agregar("m", x);
            }
            else { MessageBox.Show("Participacion Inexistente"); }
            
            return null;
        }
        static public Participacion remove_arranque(Participacion_Arranque x)
        {

            Participacion participacion = ParticipacionService.findOneId(x.ParticipacionX.Id);

            if (participacion != null)
            {

                participacion.Restar("a", x);
            }
            else { MessageBox.Show("Participacion Inexistente"); }
            
            return null;
        }
        static public Participacion remove_freno(Participacion_Freno x)
        {

            Participacion participacion = ParticipacionService.findOneId(x.ParticipacionX.Id);

            if (participacion != null)
            {

                participacion.Restar("f", x);
            }
            else { MessageBox.Show("Participacion Inexistente"); }
            
            return null;
        }
        static public Participacion remove_multa(Participacion_Multa x)
        {
            Participacion participacion = ParticipacionService.findOneId(x.ParticipacionX.Id);

            if (participacion != null)
            {

                participacion.Restar("m", x);
            }
            else { MessageBox.Show("Participacion Inexistente"); }
            
            return null;
        }
        static public Participacion findOneId(int id)
        {
            string[] lineaParticipacion = config.findOne(directions.Participaciones, id.ToString(), 0);
            if (lineaParticipacion != null) { return new Participacion(lineaParticipacion); }
            return null;

        }
       
        static public List<Participacion> findAllforCarrera(int idCarrera)
        {
            List<Participacion> lista = new List<Participacion>();
            List<string[]> lineaParticipaciones = config.findBykey(directions.Participaciones, idCarrera.ToString(),2);
            if (lineaParticipaciones==null) { return lista; }
            foreach (string[] x in lineaParticipaciones) {
                lista.Add(new Participacion(x)); 
            }
            
            return lista;

        }
        static public List<Participacion_Arranque> findAllforArranques(int idParticipacion)
        {
            List<Participacion_Arranque> lista = new List<Participacion_Arranque>();
            List<string[]> lineaParticipaciones = config.findBykey(directions.Participacion_Arranques, idParticipacion.ToString(), 1);
            if (lineaParticipaciones!=null) {
                foreach (string[] x in lineaParticipaciones)
                {
                    lista.Add(new Participacion_Arranque(x));
                    

                }
            }
            
            return lista;

        }
        static public List<Participacion_Freno> findAllforFrenos(int idParticipacion)
        {
            List<Participacion_Freno> lista = new List<Participacion_Freno>();
            List<string[]> lineaParticipaciones = config.findBykey(directions.Participacion_Frenos, idParticipacion.ToString(), 1);
            if (lineaParticipaciones!=null) {
                foreach (string[] x in lineaParticipaciones)
                {
                    lista.Add(new Participacion_Freno(x));
                }
            }
            return lista;

        }
        static public List<Participacion_Multa> findAllforMultas(int idParticipacion)
        {
            List<Participacion_Multa> lista = new List<Participacion_Multa>();
            List<string[]> lineaParticipaciones = config.findBykey(directions.Participacion_Multas, idParticipacion.ToString(), 1);

            if (lineaParticipaciones!=null) {
                foreach (string[] x in lineaParticipaciones)
                {
                    lista.Add(new Participacion_Multa(x));
                }
            }
           
            return lista;

        }
        static public List<Participacion_Atascado> findAllforAtascos(int idParticipacion)
        {
            List<Participacion_Atascado> lista = new List<Participacion_Atascado>();
            List<string[]> lineaParticipaciones = config.findBykey(directions.Participacion_Atascos, idParticipacion.ToString(), 1);

            if (lineaParticipaciones != null)
            {
                foreach (string[] x in lineaParticipaciones)
                {
                    lista.Add(new Participacion_Atascado(x));
                }
            }

            return lista;

        }
        static public List<Participacion> findAll()
        {

            List<string[]> listbd = config.LeerBD(directions.Participaciones, 4);
            List<Participacion> lista = new List<Participacion>();
            if (listbd.Count() > 0)
            {
                foreach (string[] x in listbd)
                {
                    lista.Add(new Participacion(x));
                }
            }
            
            return lista;
        }
        static public Participacion update(int id, Participacion change)
        {

            List<Participacion> lista = ParticipacionService.findAll();
            
            int index = ParticipacionService.IndexForId(lista, id);
            if (index == -1) { return null; }

            lista[index] = change;
            List<Participacion_Arranque> arranques = findAllforArranques(lista[index].Id);

            if (arranques.Count()==2) {

                remove_arranque(arranques[0]);
                if (ParticipacionService.Guardar(lista)) { 
                    
                    return lista[index]; 
                
                }
            }
            return null;
        }
        static public bool delete(int id)
        {
            List<Participacion> lista = ParticipacionService.findAll();
            int index = ParticipacionService.IndexForId(lista, id);
            if (index == -1) { return false; }


            List<Participacion_Arranque> listA = lista[index].AllArranques;
            foreach (Participacion_Arranque x in listA)
            {
                remove_arranque(x);
              //  MessageBox.Show("Arranque: "+x.Escribir());
            }
            List<Participacion_Freno> listF = lista[index].AllFrenos;
            foreach (Participacion_Freno x in listF)
            {
                remove_freno(x);
                //MessageBox.Show("Freno: " + x.Escribir());
            }

            List<Participacion_Multa> listM = lista[index].AllMultas;
            foreach (Participacion_Multa x in listM)
            {
                remove_multa(x);
                //MessageBox.Show("Multa: " + x.Escribir());
            }
            lista.RemoveAt(index);

            if (ParticipacionService.Guardar(lista)) { return true; }
            return false;

        }
        static public bool deleteAll()
        {
            config.EliminarBD(directions.Participacion_Arranques);
            config.EliminarBD(directions.Participacion_Frenos);
            config.EliminarBD(directions.Participacion_Multas);
            return config.EliminarBD(directions.Participaciones);
            
        }
        static public int IndexForId(List<Participacion> xlist, int id)
        {

            for (int i = 0; i < xlist.Count(); i++)
            {
                if (xlist[i].Id == id) { return i; }
            }
            return -1;
        }
        static public bool findVehiculoInCarrera(Carrera carrera, int vehiculo)
        {
            List<Participacion> xlist = ParticipacionService.findAllforCarrera(carrera.Id);
            for (int i = 0; i < xlist.Count(); i++)
            {
                if (xlist[i].Vehiculo == vehiculo) { return true; }
            }
            return false;
        }
        static public Participacion findVehiculo(int vehiculo)
        {
            List<Participacion> xlist = ParticipacionService.findAll();
            for (int i = 0; i < xlist.Count(); i++)
            {
                if (xlist[i].Vehiculo == vehiculo) { return xlist[i]; }
            }
            return null;
        }
        static public Participacion findPiloto(int idPiloto)
        {
            List<Participacion> xlist = ParticipacionService.findAll();
            for (int i = 0; i < xlist.Count(); i++)
            {
                if (xlist[i].PilotoX.Id == idPiloto) { return xlist[i]; }
            }
            return null;
        }
        static public bool Guardar(List<Participacion> xlista)
        {

            List<string> dat = new List<string>();

            foreach (Participacion x in xlista)
            {
                dat.Add(x.Escribir());
            }
            if (dat.Count > 0)
            {

                return config.EscribirBD(directions.Participaciones, dat);
            }
            else
            {
                return config.EliminarBD(directions.Participaciones);
            }
        }
  
        static public TimeSpan diferencia(TimeSpan a, TimeSpan b) {
            return a - b;
        }

        static public List<TimeSpan> MayoresTiempos(int idCarrera)
        {
            return new List<TimeSpan>();
        }

    }
}
