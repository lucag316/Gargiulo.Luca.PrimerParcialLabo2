using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class UsuarioLog //logger // maneja el registro de accesos de usuarios
    {
        private string logFilPath; //ruta del archivo de registro (usuarios.log)

        public UsuarioLog(string logFilePath)
        {
            this.logFilPath = logFilePath;
            VerificarLogFileExists(); //para asegurarse de que el archivo de registro exista.Si no existe, lo crea.
        }

        private void VerificarLogFileExists()
        {
            if (!File.Exists(this.logFilPath))
            {
                using (File.Create(this.logFilPath)) { } //lo creo si no existe
            }
        }

        public void RegistrarAcceso(Usuario usuario)
        {
            string fechaAcceso = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
            string logEntry = $"Usuario: {usuario.nombre} {usuario.apellido} - Fecha de Acceso: {fechaAcceso} - Legajo: {usuario.legajo} - Perfil: {usuario.perfil} - Correo: {usuario.correo} - Clave: {usuario.clave}";

            using (StreamWriter sw = new StreamWriter(this.logFilPath, true)) //el segundo es que se agrega nueva entrada al final del archivo, creo que es append
            {
                sw.WriteLine(logEntry);
            }
        }

        public string LeerLog() //lee todo el contenido del archivo y lo devuelve en una cadena
        {
            using (StreamReader sr = new StreamReader(this.logFilPath))
            {
                return sr.ReadToEnd();
            }
        }
    }
}
