using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Competencias___Valle_Fertil
{
    internal class Categoria
    {
        int id;
        string nombre;

        List<Piloto> listaPilotos;

        public Categoria() { listaPilotos = new List<Piloto>(); }
        public Categoria(string[] dat) {
            if (dat.Length==2) {

                id =int.Parse(dat[0]);
                nombre = dat[1];
                listaPilotos = new List<Piloto>();
            
              
            }
            

        }

        
        public string Nombre { get { return nombre; } set { nombre = value; } }
        public int Id { get { return id; } set { id = value; } }
       // public List<Piloto> ListaPilotos { get { return PilotoService.findAllforCategoria(id); } set { listaPilotos = value; } }
    
        public string Escribir() { 
            return 
                id.ToString()+"|"+
                nombre; 
        }
    
    }
}
