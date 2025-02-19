using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Importar el paquete para trabajar archivos
using System.IO;

namespace Datos
{
    public class CD_Producto
    {
        public string nombre { get; set; }
        public string codigo { get; set; }
        public string precio { get; set; }
        public string stock { get; set; }

        //Variables para los stream
        private FileStream archivo = null;
        private StreamWriter escritor = null;
        private StreamReader lector = null;

        //Almacenar los productos en un listado
        List<string> lista = new System.Collections.Generic.List<string>();

        //Establecer la ruta del archivo
        private string ruta = @"..\..\recursos\productos.txt";
        public string mensaje = "";

        //Metodo para almacenar datos en el archivo
        public void insertar(string cod, string nom, string pre, string stock)
        {
            try
            {
                //Indicar el archivo a usar
                archivo = new FileStream(ruta, FileMode.Append, FileAccess.Write);
                //Crear el escritor
                escritor = new StreamWriter(archivo);
                //Escribir los datos en el archivo
                escritor.WriteLine(cod + "," + nom + "," + pre + "," + stock);
                //Cerrar el archivo
                escritor.Close();
                mensaje = "Se ha registrado el producto!";
            }
            catch (IOException e) {
                mensaje = "ERROR: " + e.Message;
            }
        }//Cierre metodo

        //Metodo para listar los productos (servicio)
        public List<String> listado()
        {
            try
            {
                archivo = new FileStream(ruta, FileMode.Open, FileAccess.Read);
                lector = new StreamReader(archivo);
                string linea;
                //Recorrer el archivo hasta que llegue a null
                while ((linea = lector.ReadLine()) != null)
                {
                    lista.Add(linea);
                }
                //cerrar el archivo
                lector.Close();
            }
            catch (IOException e)
            {
                mensaje = "ERROR: " + e.Message;
            }
            return lista;
        }

        //Metodo para buscar los productos (servicio)
        public void buscar(string cod)
        {
            try
            {
                archivo = new FileStream(ruta, FileMode.Open, FileAccess.Read);
                lector = new StreamReader(archivo);
                string linea;
                //Recorrer el archivo hasta que llegue a null
                string[] cadena = new string[4];
                bool encontro = false;

                while ((linea = lector.ReadLine()) != null)
                {
                    //Separar la linea de texto en campos y llevamos al vector
                    cadena=linea.Split(new char[] { ','});
                    //Validar si el producto está almacenado en el vector
                    if (cadena[0]==cod)
                    {
                        encontro = true;
                       break;
                    }
                }//cierre del while
                if (encontro) { 
                  codigo=cadena[0];//los datos que se pasaran a negocio
                    nombre=cadena[1];
                    precio=cadena[2];
                    stock=cadena[3];
                }
                //cerrar el archivo
                lector.Close();
            }
            catch (IOException e)
            {
                mensaje = "ERROR: " + e.Message;
            }
        }
    }//cerrar metodo
}
