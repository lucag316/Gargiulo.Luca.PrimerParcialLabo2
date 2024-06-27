using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.OtrasClases
{
    public class UsuarioLog //maneja el registro de accesos de usuarios en un archivo de registro //logger
    {
        private string logFilPath; //ruta del archivo de registro (usuarios.log)

        public UsuarioLog(string logFilePath)
        {
            logFilPath = logFilePath;
            VerificarLogFileExists();
        }

        /// <summary>
        /// Verifica si el archivo de registro existe. Si no existe, lo crea.
        /// </summary>
        private void VerificarLogFileExists()
        {
            if (!File.Exists(logFilPath))
            {
                using (File.Create(logFilPath)) { }
            }
        }

        /// <summary>
        /// Registra un acceso de usuario en el archivo de registro.
        /// </summary>
        //// <param name="usuario">Usuario que ha accedido.</param>
        public void RegistrarAcceso(Usuario usuario)
        {
            string fechaAcceso = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
            string logEntry = $"Usuario: {usuario.nombre} {usuario.apellido} - Fecha de Acceso: {fechaAcceso} - Legajo: {usuario.legajo} - Perfil: {usuario.perfil} - Correo: {usuario.correo}";

            using (StreamWriter sw = new StreamWriter(logFilPath, true)) //el segundo parametro es tipo append
            {
                sw.WriteLine(logEntry);
            }
        }

        /// <summary>
        /// Lee todo el contenido del archivo de registro y lo devuelve en una cadena.
        /// </summary>
        public string LeerLog()
        {
            using (StreamReader sr = new StreamReader(logFilPath))
            {
                return sr.ReadToEnd();
            }
        }
    }
}
