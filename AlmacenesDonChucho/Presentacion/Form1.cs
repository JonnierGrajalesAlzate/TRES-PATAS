using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//Usar la capa de negocio
using Negocio;

namespace Presentacion
{
    public partial class frmPrincipal : Form
    {
        public frmPrincipal()
        {
            InitializeComponent();
        }

        //instanciar un objeto de tipo CN_Producto
        CN_Producto objCN = new CN_Producto();

        private void limpiar()
        {
            txtCod.Clear();
            txtNom.Clear();
            txtPre.Clear();
            txtStock.Clear();
            txtCod.Focus();
        }
        //Insertar datos en los campos de texto
        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            objCN.insertarProducto(txtCod.Text, txtNom.Text, txtPre.Text, txtStock.Text);
            MessageBox.Show("Se ha registrado el producto", "Almacenes el strawberry mouse", MessageBoxButtons.OK, MessageBoxIcon.Information);
            limpiar();
        }

        private void btnListado_Click(object sender, EventArgs e)
        {
            foreach(var lista in objCN.listadoProductos())
            {
                lstListado.Items.Add(lista);
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            objCN.buscarProducto(txtCod.Text);
            txtCod.Text = objCN.codigo;
            txtNom.Text = objCN.nombre;
            txtPre.Text = objCN.precio;
            txtStock.Text = objCN.stock;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
