using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Serializacion
{
    public interface ISerializador<T> where T : class, new()
    {
        bool Serializar(T obj);
        T Deserializar();
    }
}
