using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Competencias___Valle_Fertil
{
    static class PilotoService
    {   
        static public Piloto create(Piloto x)
        {
           
            if (PilotoSchema.createPiloto(x))
            {
               
                List<Piloto> pilotos = findAll();
                if (pilotos.Count()==0)
                {
                    x.Id = 1;
                }
                else
                {
                    x.Id = pilotos[pilotos.Count() - 1].Id + 1;
                }
                pilotos.Add(x);
                if (PilotoService.Guardar(pilotos))
                {
                    return x;
                }
                else
                {
                    MessageBox.Show("Error al escribir BD");
                }
            }
            return null;
        }
        static public Piloto findOneId(int id)
        {
            string[] lineaPiloto = config.findOne(directions.Pilotos, id.ToString(), 0);
            if (lineaPiloto != null) { return new Piloto(lineaPiloto); }
            return null;
        }
        static public Piloto findOneDni(int dni)
        {
            string[] lineaPiloto = config.findOne(directions.Pilotos, dni.ToString(), 11);
            if (lineaPiloto != null) { return new Piloto(lineaPiloto); }
            return null;
        }
        static public Piloto findOneNombre(string nombre, string apellido)
        {
            string[] lineaPiloto = config.findOne(directions.Pilotos, nombre,apellido, 0,1);
            if (lineaPiloto != null) { return new Piloto(lineaPiloto); }
            return null;
        }
        static public List<Piloto> findAllforCategoria(int idCategoria)
        {
            List<Piloto> lista = new List<Piloto>();
            List<string[]> lineaPilotos = config.findBykey(directions.Pilotos, idCategoria.ToString(), 13);

            if (lineaPilotos==null) { return lista; }
            foreach (string[] x in lineaPilotos)
            {
                lista.Add(new Piloto(x));
            }
           
            return lista;

        }
        static public List<Piloto> findAll()
        {
            List<string[]> listbd = config.LeerBD(directions.Pilotos, 13);
            List<Piloto> lista = new List<Piloto>();
            if (listbd.Count() > 0)
            {
                foreach (string[] x in listbd)
                {
                    lista.Add(new Piloto(x));
                }
            }
            return lista;
        }
        static public Piloto update(int id, Piloto change) {
            List<Piloto> lista = PilotoService.findAll();
            int index = PilotoService.IndexForId(lista, id);
            if (index == -1) { return null; }

            lista[index] = change;

            if (PilotoService.Guardar(lista)) { return lista[index]; }
            return null;
        }
        static public bool delete(int id)
        {
            List<Piloto> lista = PilotoService.findAll();
            int index = PilotoService.IndexForId(lista, id);
            if (index == -1) { return false; }

            lista.RemoveAt(index);

            if (PilotoService.Guardar(lista)) { return true; }
            return false;
        }
        static public int IndexForNombre(List<Piloto> xlist, string nom)
        {

            for (int i = 0; i < xlist.Count(); i++)
            {
                if (xlist[i].Nombre == nom) { return i; }
            }
            return -1;
        }
        static public int IndexForId(List<Piloto> xlist, int id)
        {

            for (int i = 0; i < xlist.Count(); i++)
            {
                if (xlist[i].Id == id) { return i; }
            }
            return -1;
        }
        static public bool Guardar(List<Piloto> xlista)
        {

            List<string> dat = new List<string>();

            foreach (Piloto x in xlista)
            {
                dat.Add(x.Escribir());
            }
            if (dat.Count > 0)
            {

                return config.EscribirBD(directions.Pilotos, dat);
            }
            else
            {
                return config.EliminarBD(directions.Pilotos);
            }
        }
    }
}
