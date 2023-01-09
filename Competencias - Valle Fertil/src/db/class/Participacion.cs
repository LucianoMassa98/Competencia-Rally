using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Competencias___Valle_Fertil
{
    internal class Participacion // Carrera-Pilotos
    {
        int id, vehiculo;
        Piloto piloto;
        Carrera carrera;
        List<Participacion_Arranque> arranques;
        List<Participacion_Freno> frenos;
        List<Participacion_Multa> multas;
        List<Participacion_Atascado> atascos;
        public Participacion()
        {
            arranques = new List<Participacion_Arranque>();
            frenos = new List<Participacion_Freno>();
            multas = new List<Participacion_Multa>();
                atascos = new List<Participacion_Atascado>();
        }
        public Participacion(string[] dat)
        {
            if (dat.Length==4) {

                id = int.Parse(dat[0]);
                vehiculo = int.Parse(dat[1]);
                carrera = CarreraService.findOneId(int.Parse(dat[2]));
                piloto = PilotoService.findOneId(int.Parse(dat[3]));
                arranques = new List<Participacion_Arranque>();
                frenos = new List<Participacion_Freno>();
                multas = new List<Participacion_Multa>();
                atascos = new List<Participacion_Atascado>();
            }
            else {  }
        }

        public int Id { get { return id; } set { id = value; } }
        public int Vehiculo { get { return vehiculo; } set { vehiculo = value; } }
        public Piloto PilotoX { get { return piloto; } set { piloto = value; } }
        public Carrera CarreraY { get { return carrera; } set { carrera = value; } }
        public List<Participacion_Arranque> Arranques { get { return arranques; } set { arranques= value; } }
        public List<Participacion_Freno> Frenos{ get { return frenos; } set { frenos = value; } }
        public List<Participacion_Multa> Multas { get { return multas; } set { multas = value; } }
        public List<Participacion_Atascado> Atascos { get { return atascos; } set { atascos = value; } }
        public List<Participacion_Arranque> AllArranques{ get { return ParticipacionService.findAllforArranques(id); } }
        public List<Participacion_Freno> AllFrenos{ get { return ParticipacionService.findAllforFrenos(id); } }
        public List<Participacion_Multa> AllMultas{ get { return ParticipacionService.findAllforMultas(id); } }
        public List<Participacion_Atascado> AllAtascados{ get { return ParticipacionService.findAllforAtascos(id); } }
        public bool Agregar(string tipo, object participacion)
        {

            switch (tipo)
            {
                case "a":
                    {
                        int cntArranques = AllArranques.Count();
                        int cntFrenos = AllFrenos.Count();

                        Participacion_Arranque xArranque = (Participacion_Arranque)participacion;
                        xArranque.ParticipacionX = this;
                        Arranques.Add(xArranque);
                        List<string> lista = config.LeerArchivo(directions.Participacion_Arranques, 3);
                        if (lista.Count > 0)
                        {
                            string[] dat = lista[lista.Count - 1].Split('|');
                            xArranque.Id = int.Parse(dat[0]) + 1;
                        }
                        else { xArranque.Id = 1; }
                        lista.Add(xArranque.Escribir());
                        config.EscribirBD(directions.Participacion_Arranques, lista);
                        
                        if (cntArranques - cntFrenos !=0) { MessageBox.Show("Cuidado, verificar detalles de piloto"); }

                        
                        return true;
                        
                        break;
                    }
                case "f":
                    {
                        int cntArranques = AllArranques.Count();
                        int cntFrenos = AllFrenos.Count();


                        Participacion_Freno xFreno = (Participacion_Freno)participacion;

                        xFreno.ParticipacionX = this;
                        Frenos.Add(xFreno);
                        List<string> lista = config.LeerArchivo(directions.Participacion_Frenos, 3);
                        if (lista.Count > 0)
                        {
                            string[] dat = lista[lista.Count - 1].Split('|');
                            xFreno.Id = int.Parse(dat[0]) + 1;
                        }
                        else { xFreno.Id = 1; }
                        lista.Add(xFreno.Escribir());
                        config.EscribirBD(directions.Participacion_Frenos, lista);
                        if (cntArranques != cntFrenos+1)
                        {
                            MessageBox.Show("Cuidado, verificar detalles de piloto");
                        }


                        return true;

                        break;
                    }
                case "m":
                    {
                        int cntArranques = AllArranques.Count();
                        int cntFrenos = AllFrenos.Count();
                        if (cntArranques == cntFrenos)
                        {
                            Participacion_Multa xMulta = (Participacion_Multa)participacion;
                           
                            xMulta.ParticipacionX = this;
                            Multas.Add(xMulta);
                            List<string> lista = config.LeerArchivo(directions.Participacion_Multas, 3);
                            if (lista.Count > 0)
                            {
                                string[] dat = lista[lista.Count - 1].Split('|');
                                xMulta.Id = int.Parse(dat[0]) + 1;
                            }
                            else { xMulta.Id = 1; }
                            lista.Add(xMulta.Escribir());
                            config.EscribirBD(directions.Participacion_Multas, lista);

                            return true;
                        }
                        break;
                    }
                case "at":
                    {
                        
                            Participacion_Atascado x= (Participacion_Atascado)participacion;

                            x.ParticipacionX = this;
                            Atascos.Add(x);
                            List<string> lista = config.LeerArchivo(directions.Participacion_Atascos, 3);
                            if (lista.Count > 0)
                            {
                                string[] dat = lista[lista.Count - 1].Split('|');
                                x.Id = int.Parse(dat[0]) + 1;
                            }
                            else { x.Id = 1; }
                            lista.Add(x.Escribir());
                            config.EscribirBD(directions.Participacion_Atascos, lista);

                            return true;
                        
                        break;
                    }

            }
            return false;
        }
        public bool Restar(string tipo, object participacion)
        {

            switch (tipo)
            {

                case "a":
                    {
                        List<string> lista = config.LeerArchivo(directions.Participacion_Arranques, 3);
                        if (lista.Count>0)
                        {
                            Participacion_Arranque xArranque = (Participacion_Arranque)participacion;
                            lista.Remove(xArranque.Escribir());
                            config.EscribirBD(directions.Participacion_Arranques, lista);
                            return true;
                        }
                        break;
                    }
                case "f":
                    {
                        List<string> lista = config.LeerArchivo(directions.Participacion_Frenos, 3);
                        if (lista.Count>0)
                        {
                            Participacion_Freno xFreno= (Participacion_Freno)participacion;
                            lista.Remove(xFreno.Escribir());
                            config.EscribirBD(directions.Participacion_Frenos, lista); 
                            return true;
                        }
                        break;
                    }
                case "m":
                    {

                        List<string> lista = config.LeerArchivo(directions.Participacion_Multas, 3);

                        if (lista.Count()>0)
                        {
                            Participacion_Multa xMulta= (Participacion_Multa)participacion;
                            lista.Remove(xMulta.Escribir());
                            config.EscribirBD(directions.Participacion_Multas, lista);

                            return true;
                        }
                        break;
                    }
                case "at":
                    {

                        List<string> lista = config.LeerArchivo(directions.Participacion_Atascos, 3);

                        if (lista.Count() > 0)
                        {
                            Participacion_Atascado xMulta = (Participacion_Atascado)participacion;
                            lista.Remove(xMulta.Escribir());
                            config.EscribirBD(directions.Participacion_Atascos, lista);

                            return true;
                        }
                        break;
                    }

            }
            return false;
        }
        public string Escribir() {
            return id.ToString()+"|"+
                vehiculo.ToString() + "|"+
                carrera.Id + "|"+
                piloto.Id;
        }

        public TimeSpan TiempoNeto()
        {
            
            arranques = AllArranques;
            
            frenos = AllFrenos;
            TimeSpan res = new TimeSpan();

           
           // MessageBox.Show(arranques.Count().ToString()+ " "+ frenos.Count().ToString()+"--"+vehiculo);
            if (arranques.Count()== frenos.Count()) {

                for (int i =0; i< frenos.Count();i++) {


                  
                    res +=  frenos[i].Value- arranques[i].Value;
                   // MessageBox.Show(arranques[i].Value.ToString()+" - "+ frenos[i].Value.ToString() +" - "+frenos[i].Value.ToString("hh"));
                }
                if (arranques.Count() > 0) {}

            }
            return res;
        }

        public TimeSpan TiempoMulta()
        {
            List<Participacion_Multa> listMultas = AllMultas;
            TimeSpan res = new TimeSpan();
            
            for (int i = 0; i < listMultas.Count(); i++)
                {
                res += listMultas[i].Value;
                }
            return res;

        }
        public TimeSpan TiempoTotal()
        {
            
            return TiempoNeto() + TiempoMulta();
        }

        public TimeSpan TiempoPromedio()
        {
            if (TiempoNeto().Seconds>0) {
                return TiempoTotal() / AllArranques.Count();
            }
            return new TimeSpan();
        }
    
        public int Rondas(ref bool band) {

            int arrnq = AllArranques.Count();
            int frens = AllFrenos.Count();
            if (arrnq == frens)
            {
                band = true;
                return arrnq;
            }
            return frens;
        }
        public int Rondas()
        {
            int arrnq = AllArranques.Count();
            int frens = AllFrenos.Count();
            if (arrnq == frens)
            { 
                return arrnq;
            }
            return frens;
        }

        public List<string> DetalleRondas()
        {
            List<string> lis = new List<string>();
            arranques = AllArranques;
            frenos = AllFrenos;
            int n = arranques.Count;
            if (n<frenos.Count) { n = frenos.Count; }
            for (int i = 0; i < n; i++)
                {
                string res="00:00:00";
                
                try { 
                    TimeSpan timeres = frenos[i].Value - arranques[i].Value;
                    res = timeres.ToString();
                } catch (Exception) { }

                    try {
                   
                    lis.Add(arranques[i].Value.ToString()); }
                    catch (Exception) 
                    { lis.Add("Pendiente"); }
                    try { lis.Add(frenos[i].Value.ToString()); }
                    catch (Exception)
                    { lis.Add("Pendiente"); }
                    lis.Add(res);
                }
           
            return lis;
        }    
    }
}
