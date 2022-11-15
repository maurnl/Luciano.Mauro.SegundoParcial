using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Entidades.Serializacion
{
    public class EscritorTexto
    {
        private StreamWriter escritor;
        private StreamReader lector;
        private string path;

        public EscritorTexto()
        {
            if (!Directory.Exists(@".\Archivos"))
            {
                Directory.CreateDirectory(@".\Serializacion");
            }
            this.path = @".\Serializacion\log_partida.txt";
        }

        public bool SobreescribirElArchivo(string logPartida)
        {
            bool agrego = false;
            try
            {
                using (this.escritor = new StreamWriter(this.path))
                {
                    this.escritor.WriteLine(logPartida);
                }
                agrego = true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return agrego;
        }

        public string LeerArchivoHastaElFinal()
        {
            string retorno = "";
            try
            {
                using (this.lector = new StreamReader(this.path))
                {
                    retorno = this.lector.ReadToEnd();
                }
            }
            catch (Exception e)
            {
                retorno = e.Message;
            }
            return retorno;
        }
    }
}
