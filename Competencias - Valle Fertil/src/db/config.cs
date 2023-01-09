using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Competencias___Valle_Fertil
{
    static class config
    {
        static public List<string[]> LeerBD(string direccion, int ancho)
        {

            List<string[]> lista = new List<string[]>();
            StreamReader p = new StreamReader(direccion);
            string l;
            string[] dat;

            while ((l = p.ReadLine()) != null)
            {
                dat = l.Split('|');
                if (dat.Length == ancho) { lista.Add(dat); }
            }

            p.Close(); p.Dispose();
            return lista;
        }
        static public string LeerBdBloque(string direccion)
        {
            StreamReader p = new StreamReader(direccion);
            string l = p.ReadToEnd();
            p.Close(); p.Dispose();
            return l;
        }
        static public List<string> LeerArchivo(string direccion, int ancho)
        {

            List<string> lista = new List<string>();
            StreamReader p = new StreamReader(direccion);
            string l;
            string[] dat;

            while ((l = p.ReadLine()) != null)
            {
                dat = l.Split('|');
                if (dat.Length == ancho) { lista.Add(l); }
            }

            p.Close(); p.Dispose();
            return lista;
        }
        static public bool EscribirBD(string direccion,List<string> dat) {
            StreamWriter p = new StreamWriter(direccion);

            foreach(string x in dat)
            {
                p.WriteLine(x);
            }

            p.Close(); p.Dispose();
            return true;
        }

        static public bool EliminarBD(string direccion)
        {
            StreamWriter p = new StreamWriter(direccion);
            p.Close(); p.Dispose();
            return true;
        }
        static public string[] findOne(string direccion,string ide, int column ) {

            
            StreamReader p = new StreamReader(direccion);
            string l;
            string[] dat;

            while ((l = p.ReadLine()) != null)
            {
                dat = l.Split('|');
                if (dat[column] == ide) {
                    p.Close(); p.Dispose();
                    return dat;
                }
            }

            p.Close(); p.Dispose();
            return null;

        }
        static public string[] findOne(string direccion, string ide1,string ide2, int column1, int column2)
        {


            StreamReader p = new StreamReader(direccion);
            string l;
            string[] dat;

            while ((l = p.ReadLine()) != null)
            {
                dat = l.Split('|');
                if ((dat[column1] == ide1) && (dat[column2] == ide2))
                {
                    p.Close(); p.Dispose();
                    return dat;
                }
            }

            p.Close(); p.Dispose();
            return null;

        }
        static public List<string[]> findBykey(string direccion, string ide, int column)
        {
            List<string[]> lista = new List<string[]>();
            StreamReader p = new StreamReader(direccion);
            string l;
            string[] dat;

            while ((l = p.ReadLine()) != null)
            {
                dat = l.Split('|');
                if (dat[column] == ide)
                {
                  //  MessageBox.Show("entro "+ ide);
                    lista.Add(dat);
                }
            }

            p.Close(); p.Dispose();
            if (lista.Count()>0) { return lista; }
            else { return null; }
        }

     
    }
}
