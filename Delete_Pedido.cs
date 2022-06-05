/*
Equipo # 5
Integrantes:
Aceves Curiel Georgina Guadalupe
Fernández Flores Paola Crineth
Preciado Antón Hanna Lizeth
Sección: D04
Clave Materia: I5891
Calendario: 2019A
*/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Restaurante.MySQL;


namespace Restaurante
{
    public partial class Delete_Pedido : Form
    {
        public Delete_Pedido()
        {
            InitializeComponent();
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            if(txtCodigo.Text.Length == 0)
            {
                MessageBox.Show("Introduzca el código");
            }
            else
            {
                MySqlConnection con = new MySqlConnection("server=127.0.0.1;database=restaurante;Uid=root;pwd=g1n4;");
                //int estado = 1;
                con.Open();
                MySqlCommand comm = new MySqlCommand(string.Format("SELECT pedido.cantidad_platillo AS CANTIDAD, alimento.nombre_alimento AS ALIMENTO, alimento.precio_alimento AS PRECIO, alimento.precio_alimento*pedido.cantidad_platillo AS IMPORTE FROM pedido INNER JOIN alimento ON pedido.id_alimento = alimento.id_alimento WHERE pedido.num_orden = '{0}'", txtCodigo.Text), con);
                //MySqlCommand comm = new MySqlCommand(string.Format("Select pedido.cantidad_platillo, alimento.nombre_alimento, alimento.precio_alimento FROM pedido INNER JOIN alimento ON pedido.id_alimento = alimento.id_alimento WHERE pedido.num_orden = '{0}'", txtNOrden.Text), con);
                DataTable dt = new DataTable();
                MySqlDataAdapter SDA = new MySqlDataAdapter(comm);
                //DataTable dt = new DataTable();
                SDA.Fill(dt);
                dgvPrueba.DataSource = dt;
            }
            
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            int retorno = Funciones.eliminarPedido(txtCodigo.Text);

            if (retorno > 0)
            {
                this.Close();
                MessageBox.Show("Pedido eliminado correctamente.");
            }
            else
            {
                MessageBox.Show("Ocurrió un error al eliminar Pedido. Inténtelo nuevamente");
            }
        }

        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Delete_Pedido_Load(object sender, EventArgs e)
        {

        }
    }
}
