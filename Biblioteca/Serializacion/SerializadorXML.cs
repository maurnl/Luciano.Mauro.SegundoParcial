using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Serializacion
{
    public class SerializadorXML<T> : ISerializador<T> where T : class, new()
    {
        public T Deserializar()
        {
            // Desealiza un archivo .xml
            throw new NotImplementedException();
        }

        public bool Serializar(T obj)
        {
            // Serializa a xml
            throw new NotImplementedException();
        }
    }
}
