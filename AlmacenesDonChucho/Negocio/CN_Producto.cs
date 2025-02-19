using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Datos;

namespace Negocio
{
    public class CN_Producto
    {
        //Instanciar un objeto de tipo de datos
        private CD_Producto objCD = new CD_Producto();

        public string nombre { get; set; }
        public string codigo { get; set; }
        public string precio { get; set; }
        public string stock { get; set; }

        //Metodo para consumir el servicio de la capa de datos listado
        public List<string> listadoProductos() { 
          List<String> lista = new List<string>();
            lista = objCD.listado();
            return lista;
        }

        private List<string> listado()
        {
            throw new NotImplementedException();
        }

        //Metodo para consumir el servicio de insertar de la capa de datos
        public void insertarProducto(string cod, string nom, string pre, string stock){
            objCD.insertar(cod, nom, pre, stock);
        }

        //Metodo para consumir el servicio buscar de la capa de datos
        public void buscarProducto(string cod) {
                objCD.buscar(cod);
                codigo = objCD.codigo;
                nombre = objCD.nombre;
                precio = objCD.precio;
                stock = objCD.stock;
        }

        private void buscar(string cod)
        {
            throw new NotImplementedException();
        }
    }//cierre clase
}
