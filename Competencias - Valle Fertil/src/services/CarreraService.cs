using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Competencias___Valle_Fertil
{
    internal class CarreraService
    {
        static public Carrera create(Carrera x)
        {
            if (CarreraService.findOneId(x.Id) == null)
            {
                List<Carrera> carreras = findAll();


                if (carreras.Count()==0)
                {
                    x.Id = 1;
                }
                else
                {
                    x.Id = carreras[carreras.Count() - 1].Id + 1;
                }
                carreras.Add(x);
                if (CarreraService.Guardar(carreras))
                {
                    return x;
                }
            }
            return null;
        }
        static public Carrera findOneId(int id)
        {
            string[] lineaCarrera = config.findOne(directions.Carreras, id.ToString(), 0);
            if (lineaCarrera != null) { return new Carrera(lineaCarrera); }
            return null;
        }

        static public Carrera findOneNombre(string nom)
        {
            string[] lineaCarrera = config.findOne(directions.Carreras,nom, 1);
            if (lineaCarrera != null) { return new Carrera(lineaCarrera); }
            return null;
        }
        static public List<Carrera> findAll()
        {
            List<string[]> listbd = config.LeerBD(directions.Carreras, 4);
            List<Carrera> lista = new List<Carrera>();
            if (listbd.Count() > 0)
            {

               

                foreach (string[] x in listbd)
                {
                    lista.Add(new Carrera(x));
                }

               
            }
            return lista;
        }
        static public Carrera update(int id, Carrera change)
        {
            List<Carrera> lista = CarreraService.findAll();
            int index = CarreraService.IndexForId(lista, id);
            if (index == -1) { return null; }

            lista[index] = change;

            if (CarreraService.Guardar(lista)) { return lista[index]; }
            return null;
        }
        static public bool delete(int id)
        {
            List<Carrera> lista = CarreraService.findAll();
            int index = CarreraService.IndexForId(lista, id);
            if (index == -1) { return false; }

            lista.RemoveAt(index);

            if (CarreraService.Guardar(lista)) { return true; }
            return false;
        }
        static public bool deleteAll()
        {
            ParticipacionService.deleteAll();
            return config.EliminarBD(directions.Carreras);
           
        }
        static public int IndexForNombre(List<Carrera> xlist, string nom)
        {

            for (int i = 0; i < xlist.Count(); i++)
            {
                if (xlist[i].Nombre == nom) { return i; }
            }
            return -1;
        }
        static public int IndexForId(List<Carrera> xlist, int id)
        {

            for (int i = 0; i < xlist.Count(); i++)
            {
                if (xlist[i].Id == id) { return i; }
            }
            return -1;
        }
        static public bool Guardar(List<Carrera> xlista)
        {

            List<string> dat = new List<string>();

            foreach (Carrera x in xlista)
            {
                dat.Add(x.Escribir());
            }
            if (dat.Count > 0)
            {

                return config.EscribirBD(directions.Carreras, dat);
            }
            else
            {
                return config.EliminarBD(directions.Carreras);
            }
        }
   
    
    
    }
}
