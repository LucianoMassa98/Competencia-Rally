using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Competencias___Valle_Fertil
{
    internal class Piloto
    {
        string celular,nombre, apellido, nacimiento, sexo, domicilio, email, alojamiento, alergias, nacionalidad;
        int edad, dni, id;

        public Piloto() { }
        public Piloto(string[] dat) {
            if (dat.Length>=13) {
                id = int.Parse(dat[0]);
                nombre = dat[1];
                apellido = dat[2];
                nacimiento = dat[3];
                sexo = dat[4];
                domicilio = dat[5];
                email = dat[6];
                alojamiento = dat[7];
                alergias = dat[8];
                nacionalidad = dat[9];
                edad = int.Parse(dat[10]);
                dni = int.Parse(dat[11]);
                celular = dat[12];

            }
        }
        public int Id { get { return id; } set { id = value; } }
        public string Nombre { get { return nombre; } set { nombre = value; } }
        public string Apellido { get { return apellido; } set { apellido = value; } }
        public string Nacimiento { get { return nacimiento; } set { nacimiento = value; } }
        public string Sexo { get { return sexo; } set { sexo = value; } }
        public string Domicilio { get { return domicilio; } set { domicilio = value; } }
        public string Email { get { return email; } set { email = value; } }
        public string Alojamiento { get { return alojamiento; } set { alojamiento = value; } }
        public string Alergias { get { return alergias; } set { alergias = value; } }
        public string Nacionalidad { get { return nacionalidad; } set { nacionalidad = value; } }
        public int Edad { get { return edad; } set { edad = value; } }
        public int Dni { get { return dni; } set { dni = value; } }
        public string Celular { get { return celular; } set { celular = value; } }
        public string Escribir() {
            return
                id + "|" +
                nombre + "|" +
                apellido + "|" +
                nacimiento + "|" +
                sexo + "|" +
                domicilio + "|" +
                email + "|" +
                alojamiento + "|" +
                alergias + "|" +
                nacionalidad + "|" +
                edad.ToString() + "|" +
                dni.ToString() + "|" +
                celular;
                }

        public string NombreCompleto() { return nombre + " " + apellido; }
    }
}
