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
        public StreamWriter writer;
        public StreamReader reader;
        public string path;

        public SerializadorJson(string archivo)
        {
            path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            path += "\\" + archivo;
        }

        public T Deserializar()
        {
            T obj;
            try
            {
                using (reader = new StreamReader(path))
                {
                    string json = reader.ReadToEnd();

                    obj = JsonSerializer.Deserialize<T>(json);
                }
            }
            catch (Exception)
            {
                return null;
            }
            return obj;
        }

        public bool Serializar(T objeto)
        {
            bool retorno = false;
            try
            {
                using (writer = new StreamWriter(path))
                {

                    string json = JsonSerializer.Serialize(objeto);

                    writer.Write(json);
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
