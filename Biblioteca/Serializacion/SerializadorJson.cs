using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Biblioteca.Serializacion
{
    public class SerializadorJson<T> : ISerializador<T> where T : class, new()
    {
        public StreamWriter escritor;
        public StreamReader lector;
        public string path;

        public SerializadorJson(string archivo)
        {
            path = Environment.CurrentDirectory + @"\Serializacion";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            path += @"\" + archivo;
        }

        public T Deserializar()
        {
            T objeto;
            try
            {
                using (lector = new StreamReader(path))
                {
                    string json = lector.ReadToEnd();
                    objeto = JsonSerializer.Deserialize<T>(json);
                }
            }
            catch (Exception)
            {
                return null;
            }
            return objeto;
        }

        public bool Serializar(T objeto)
        {
            bool retorno = false;
            try
            {
                using (escritor = new StreamWriter(path))
                {
                    string json = JsonSerializer.Serialize(objeto);
                    escritor.Write(json);
                    retorno = true;
                }
            }
            catch (Exception)
            {
                retorno = false;
            }
            return retorno;
        }
    }
}
