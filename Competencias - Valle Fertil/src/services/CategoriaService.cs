using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Competencias___Valle_Fertil
{
    static class CategoriaService
    {
        static public Categoria create(Categoria x) {

            if (CategoriaService.findOneId(x.Id)==null)
            {
                List<Categoria> categorias = findAll();

                if (categorias==null) {
                    categorias = new List<Categoria>();
                    x.Id = 1;
                }
                else
                {
                    x.Id = categorias[categorias.Count() - 1].Id + 1;
                }
               
                categorias.Add(x);
                if (CategoriaService.Guardar(categorias)) {
                    return x;
                }
            }
            return null;
        }
        static public Categoria findOneId(int id) {
            string[] lineaCategoria = config.findOne(directions.Categorias,id.ToString(),0);
            if (lineaCategoria != null) { return new Categoria(lineaCategoria); }
            return null;

        }
        static public Categoria findOneNombre(string nombre)
        {
            string[] lineaCategoria = config.findOne(directions.Categorias, nombre, 1);
            if (lineaCategoria != null) { return new Categoria(lineaCategoria); }
            return null;

        }
        static public List<Categoria> findAll() {

            List<string[]> listbd = config.LeerBD(directions.Categorias,2);

            if (listbd.Count()>0) {

                List<Categoria> lista = new List<Categoria>();

                foreach (string[] x in listbd) {
                    lista.Add(new Categoria(x));
                }

                return lista;
            }
            return null;
        }
        static public Categoria update(int id, Categoria change) {

            List<Categoria>  lista = CategoriaService.findAll();
            int index = CategoriaService.IndexForId(lista,id);
            if (index==-1) { return null; }

            lista[index] = change;

            if (CategoriaService.Guardar(lista)) { return lista[index]; }
            return null;
        }
        static public bool delete(int id) {
            List<Categoria> lista = CategoriaService.findAll();
            int index = CategoriaService.IndexForId(lista, id);
            if (index == -1) { return false; }

            lista.RemoveAt(index);

            if (CategoriaService.Guardar(lista)) { return true; }
            return false;

        }
        static public int IndexForNombre(List<Categoria> xlist, string nom) {

            for(int i =0; i<xlist.Count();i++) {
                if (xlist[i].Nombre == nom) { return i; }
            }
            return -1;
        }
        static public int IndexForId(List<Categoria> xlist, int id)
        {

            for (int i = 0; i < xlist.Count(); i++)
            {
                if (xlist[i].Id == id) { return i; }
            }
            return -1;
        }
        static public bool Guardar(List<Categoria> xlista) {

            List<string> dat = new List<string>();
            
            foreach(Categoria x in xlista)
            {
                dat.Add(x.Escribir());
            }
            if (dat.Count>0) {

                return config.EscribirBD(directions.Categorias, dat);
            }
            else
            {
                return config.EliminarBD(directions.Categorias);
            }
        }
    }
}
