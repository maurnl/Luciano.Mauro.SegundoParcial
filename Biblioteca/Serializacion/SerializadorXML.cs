using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Biblioteca.Serializacion
{
    public class SerializadorXML<T> : ISerializador<T> where T : class, new()
    {
        private StreamWriter writer;
        private StreamReader reader;
        private XmlSerializer serializer;
        private string path;

        public SerializadorXML(string archivo)
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
            T aux = new T();
            try
            {
                using (this.reader = new StreamReader(this.path))
                {
                    this.serializer = new XmlSerializer(typeof(T));
                    aux = (T)this.serializer.Deserialize(this.reader);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return aux;
        }

        public bool Serializar(T obj)
        {
            bool retorno = false;
            try
            {
                using (this.writer = new StreamWriter(this.path))
                {
                    this.serializer = new XmlSerializer(typeof(T));
                    this.serializer.Serialize(this.writer, obj);
                }
                retorno = true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return retorno;
        }
    }
}
