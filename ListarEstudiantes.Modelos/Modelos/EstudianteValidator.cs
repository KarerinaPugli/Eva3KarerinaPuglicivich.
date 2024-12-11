using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evaluación3KarerinaPuglicivich.Modelos
{
    public static class EstudianteValidator
    {
        public static bool EsValido(Estudiante estudiante, out string mensajeError)
        {
            if (string.IsNullOrWhiteSpace(estudiante.Nombre))
            {
                mensajeError = "El nombre del estudiante no puede estar vacío.";
                return false;
            }

            mensajeError = string.Empty;
            return true;
        }
    }
}
