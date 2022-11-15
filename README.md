### Segundo Parcial Laboratorio de Programación II por Mauro Luciano.
---
# Sobre la aplicación
**Titulo:** Simulador 'ArgenJuegos'

**Sobre mí:** Soy Mauro, estudiante del segundo cuatrimestre de la carrera, y alumno de la comisión 2A con Maximiliano Neiner a cargo. La aplicación fue bastante difícil, como era la primera vez haciendo un juego un juego de cartas y además por turnos encarar ese problema fue lo que llevó más tiempo. Fue bastante divertido hacer el parcial, ya que no era un ABM o algo así; está bueno saber que se pueden hacer mucho más cosas fuera de eso, aplicando todo lo que se aprende durante la cursada. Le puse bastante ganas a la parte visual esta vez, ya que los temas que había que aplicar no eran muy extensos como en el primer parcial. Como desde el inicio pensé en hacer la aplicación teniendo en mente la expansión (agregar otros juegos) apliqué (o por lo menos se intentó en la medida de lo posible xD) el patrón arquitectónico Modelo-Vista-Presentador con el objetivo de tener una clase de instancia que maneje la lógica de negocio de la aplicación y una vista que tenga la menor cantidad de lógica posible.

**Resumen:** La aplicación es un simulador de juegos, donde adicionalmente se puede jugar contra la máquina. Consta de sólo 3 tipos de formularios: el principal, el de menú de juego donde se puede crear salas de juego simuladas o vs la máquina y el de visualización de partida.

# Formulario principal

En este formulario se puede elegir el juego y un nombre de jugar que será utilizado a lo largo del programa.

![Formulario principal del simulador de juegos](docs/form_principal.png)

# Formulario menú de juego

Aquí se podrá crear partidas del juego elegido anteriormente, simuladas o vs la máquina. Cada botón generado corresponde a una partida en curso, si se decide jugar contra la máquina el formulario de partida se abrirá automáticamente.

![Formulario de menú de juego](docs/form_truco.png)

# Formulario partida

En una partida en curso, se podrá visualizar el estado de la misma en este formulario. Se mostrará la partida en curso de manera gráfica y en texto, y adicionalmente se podrá cancelar la partida.

![Formulario de partida de truco en curso](docs/form_partida_truco.png)

Si se decide jugar vs la máquina el formulario se presentará con un diálogo adicional.

![Formulario jugar partida vs máquina](docs/form_jugar_truco.png)

# Diagrama de clases

# Entidades
![Diagrama de clases de la biblioteca](docs/diagrama_clases.png)

# Forms
![Diagrama de clases de la biblioteca](docs/diagrama_forms.png)

# Justificación técnica
## Excepciones
Se utilizaron excepciones para manejar los posibles errores en tiempo de ejecución a la hora de obtener jugadores desde la base de datos.
```
try
{
    comando = new SqlCommand();

    comando.CommandType = CommandType.Text;
    comando.CommandText = "SELECT id, nombre, apellido, esHumano, trucoGanadas, trucoPerdidas, piedrapapeltijeraGanadas, piedrapapeltijeraPerdidas FROM dbo.Jugadores";
    comando.Connection = conexion;

    conexion.Open();

    lector = comando.ExecuteReader();
    while (lector.Read())
    {
        Jugador item = new Jugador();

        item.Id = lector.GetInt32(0);
        item.Nombre = lector.GetString(1);
        item.Apellido = lector.GetString(2);
        item.EsHumano = lector.GetBoolean(3);
        item.CantidadVictoriasTruco = lector.GetInt32(4);
        item.CantidadDerrotasTruco = lector.GetInt32(5);
        item.CantidadVictoriasJanKenPon = lector.GetInt32(6);
        item.CantidadDerrotasJanKenPon = lector.GetInt32(7);

        lista.Add(item);
    }

    lector.Close();

}
catch (Exception ex)
{
    Console.WriteLine(ex.ToString());
}
finally
{
    if (conexion.State == ConnectionState.Open)
    {
        conexion.Close();
    }
}
```
## Pruebas unitarias
Se realizaron test unitarios para comprobar la funcionalidad del código y reducir los posibles errores al refactorizar e integrar con el resto del programa.


![Código de test unitarios](docs/testunitarios.png)
## Tipos genéricos
Se utilizaron tipos genericos para la interfaz de serializacion, permitiendo serializar cualquier tipo con una instancia de serializador que cumpla con las restricciones.


![Código de test unitarios](docs/genericos.png)
## Interfaces
Se aplicaron interfaces para guardar los datos de la partida de un juego dado y manejarlo dentro de la clase partida a partir de esta.


![Código de test unitarios](docs/interfaces.png)
![Código de test unitarios](docs/interfaces2.png)
![Código de test unitarios](docs/interfaces3.png)
## Archivos
Para guardar el registro de la partida se utilizó una clase para guardar el texto generado en un archivo de texto localmente.


![Código de test unitarios](docs/archivos.png)
## Serialización
Se realizó la serialización del mazo de cartas una vez que se crea en memoria, y además se agregó la opción de poder serializar y deserializar un historial de partidas.


![Código de test unitarios](docs/serializacion.png)
![Código de test unitarios](docs/serializacion2.png)
![Código de test unitarios](docs/serializacion3.png)
## SQL y Base de datos
Se implementó una base de datos para guardar los jugadores y el registro de partidas, y SQL para realizar consultas a la base de datos y poder generar un CRUD de los jugadores.


![Código de test unitarios](docs/sql.png)
## Delegados y expresiones lambda
Se utilizó delegados para guardar el método Cancelar de cada partida con el objetivo de realizar una única llamada para cancelar todas las partidas. Por otro lado, se utilizaron expresiones lambda para simplificar la escritura de bucles foreach utilizando el método ForEach de List<T>, el cual recibe una expresión lambda.


![Código de test unitarios](docs/delegados.png)
![Código de test unitarios](docs/lambda.png)
## Programación multi-hilo y concurrencia
Se necesitó de concurrencia para que se puedan jugar partidas sin bloquear el hilo principal de renderizado de WinForms. Para ello se utilizó la clase Task para crear hilos nuevos, y se hizo que cada partida se juegue dentro de un hilo diferente.


![Código de test unitarios](docs/multihilos.png)
## Eventos
Por último, se implementaron eventos para conectar el Presentador a la Vista, y además a las instancias de Partida con el formulario que las muestra.


![Código de test unitarios](docs/eventos.png)
![Código de test unitarios](docs/eventos2.png)
