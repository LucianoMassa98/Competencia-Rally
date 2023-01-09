using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
namespace Competencias___Valle_Fertil
{
    internal class Participacion_Atascado

    {
        int id;
        Participacion participacion;
        TimeSpan value;

        public Participacion_Atascado(TimeSpan x) { value = x; }
        public Participacion_Atascado(string[] dat) {
            id = int.Parse(dat[0]);
            participacion = ParticipacionService.findOneId(int.Parse(dat[1]));
            string[] tp = dat[2].Split(':');
            this.value = new TimeSpan(int.Parse(tp[0]), int.Parse(tp[1]), int.Parse(tp[2]), int.Parse(tp[3]), int.Parse(tp[4]));
            
           
            
        }

        public int Id { get { return id; } set { id = value; } }
        public Participacion ParticipacionX{ get { return participacion; }set { participacion = value; } }
        public TimeSpan Value {  get { return this.value; } set { this.value = value; } } 
        public string Escribir() {
            return
                id + "|" +
                participacion.Id + "|" +
                 this.value.Days+":"+ this.value.Hours + ":" + this.value.Minutes + ":" + this.value.Seconds + ":" + this.value.Milliseconds;
        }


}
}
