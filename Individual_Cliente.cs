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
using MySql.Data.MySqlClient;
using Restaurante.MySQL;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Restaurante
{
    public partial class Individual_Cliente : Form
    {
        string codigo;
        public Individual_Cliente()
        {
            InitializeComponent();
        }

        private void BtnCerrarSesion_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            MySqlCommand comando = new MySqlCommand(String.Format("SELECT * FROM cliente WHERE codigo_cliente = '{0}'", txtCodigo.Text), conexion.obtenerConexion());
            MySqlDataReader reader = comando.ExecuteReader();
            AddCliente cliente = new AddCliente();
            while (reader.Read())
            {
                cliente.CODIGO = reader.GetString(1);
            }
            codigo = cliente.CODIGO;
            if (txtCodigo.Text.Length == 0)
            {
                MessageBox.Show("Introduzca el código a buscar");
            }
            else if (codigo != txtCodigo.Text)
            {
                MessageBox.Show("No se encontraron coincidencias.");
            }
            else
            {
                dgvClienteIndividual.DataSource = Funciones.ConsultasIndividualesClientes(txtCodigo.Text);
            }
        }

        private void Individual_Cliente_Load(object sender, EventArgs e)
        {

        }
    }
}
