using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Competencias___Valle_Fertil
{
    static class directions
    {
        // actualizar para inyectarlas x variables de ambiente.  
        static string user = Environment.UserName;
        static string space = "RallyValle";

        static public string Usuarios { get { return @"C:\\Users\\" + user + "\\OneDrive\\SetData\\" + space + "\\usrs.txt"; } }
        static public string Categorias { get { return @"C:\\Users\\" + user + "\\OneDrive\\SetData\\" + space + "\\categorias.txt"; } }
        static public string Pilotos { get { return @"C:\\Users\\" + user + "\\OneDrive\\SetData\\" + space + "\\pilotos.txt"; } }
        static public string Carreras { get { return @"C:\\Users\\" + user + "\\OneDrive\\SetData\\" + space + "\\carreras.txt"; } }
        static public string Participaciones { get { return @"C:\\Users\\" + user + "\\OneDrive\\SetData\\" + space + "\\participaciones.txt"; } }
        static public string Participacion_Arranques { get { return @"C:\\Users\\" + user + "\\OneDrive\\SetData\\" + space + "\\arranques.txt"; } }
        static public string Participacion_Frenos { get { return @"C:\\Users\\" + user + "\\OneDrive\\SetData\\" + space + "\\frenos.txt"; } }
        static public string Participacion_Multas { get { return @"C:\\Users\\" + user + "\\OneDrive\\SetData\\" + space + "\\multas.txt"; } }
        static public string Participacion_Atascos { get { return @"C:\\Users\\" + user + "\\OneDrive\\SetData\\" + space + "\\atascos.txt"; } }

        static public string Posiciones { get { return @"C:\\Users\\" + user + "\\OneDrive\\SetData\\" + space + "\\Archivos\\"; } }
        static public string Inscripciones { get { return @"C:\\Users\\" + user + "\\OneDrive\\SetData\\" + space + "\\Archivos\\Inscripción-"; } }

        static public string FormInscripcion
        {
            get { return @"C:\\Users\\" + user + "\\OneDrive\\SetData\\" + space + "\\docInscripcion.txt"; }
        }
    }
}
