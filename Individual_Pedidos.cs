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
    public partial class Individual_Pedidos : Form
    {
        int codigo;
        public Individual_Pedidos()
        {
            InitializeComponent();
            
        }

        private void BtnCerrarSesion_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            MySqlCommand commando = new MySqlCommand(String.Format("select num_orden from pedido where num_orden = '{0}'", Convert.ToInt32(txtCodigo.Text)), conexion.obtenerConexion());
            MySqlDataReader reaader = commando.ExecuteReader();
            AddMesero mesero = new AddMesero();
            while (reaader.Read())
            {
                codigo = reaader.GetInt32(0);
            }

            if (txtCodigo.Text.Length == 0)
            {
                MessageBox.Show("Introduzca el código a buscar");
            }
            else if (codigo != Convert.ToInt32(txtCodigo.Text))
            {
                MessageBox.Show("No se encontraron coincidencias.");
            }
            else
            {
                MySqlConnection con = new MySqlConnection("server=127.0.0.1;database=restaurante;Uid=root;pwd=g1n4;");
                //int estado = 1;
                con.Open();
                MySqlCommand comando = new MySqlCommand(string.Format("select * from pedido where num_orden = '{0}'", Convert.ToInt32(txtCodigo.Text)), con);
                //dgvPedidos.DataSource = Funciones.consultasGeneralesPedidos();
                DataTable dt = new DataTable();
                MySqlDataAdapter SDA = new MySqlDataAdapter(comando);
                //DataTable dt = new DataTable();
                SDA.Fill(dt);
                dgvPedidos.DataSource = dt;
            }
        }

        private void Individual_Pedidos_Load(object sender, EventArgs e)
        {

        }
    }
}
