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
    public partial class Buscar_Cuenta : Form
    {
        string codigo_M;
        string num_orden_reader;
        string nombre_cliente;
        string apellido_cliente;
        string nombre_mesero;
        string apellido_mesero; 
        int id_mesa;
        int id_cliente;
        int num_orden;
        public Buscar_Cuenta()
        {
            InitializeComponent();
            btnAnadir.Enabled = false;
        }
        public Buscar_Cuenta(string v)
        {
            InitializeComponent();
            codigo_M = v;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void RectangleShape1_Click(object sender, EventArgs e)
        {

        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {

        }

        private void BtnAnadir_Click(object sender, EventArgs e)
        {
            MySqlCommand comand = new MySqlCommand(String.Format("SELECT codigo_cliente FROM cliente WHERE nombre_cliente='{0}'", nombre_cliente), conexion.obtenerConexion());
            MySqlDataReader read = comand.ExecuteReader();

            while (read.Read())
            {
                id_cliente = read.GetInt32(0);
                // id_cliente = reader.GetInt32(1);
            }
            Pedido p = new Pedido(id_cliente.ToString(),Convert.ToInt32(num_orden_reader), codigo_M.ToString(), Convert.ToInt32(id_mesa)); 
            this.Close();
            p.ShowDialog();
            this.Show();
        }

        private void TxtDatos_TextChanged(object sender, EventArgs e)
        {

        }

        private void BtnBuscar_Click_1(object sender, EventArgs e)
        {
            MySqlCommand comando = new MySqlCommand(String.Format("SELECT pedido.num_orden, cliente.nombre_cliente, " +
                "cliente.apellido_cliente, mesero.nombre_mesero, mesero.apellido_mesero, pedido.id_mesa FROM pedido " +
                "INNER JOIN cliente ON pedido.id_cliente = cliente.id_cliente INNER JOIN mesero ON pedido.id_mesero = " +
                "mesero.id_mesero WHERE num_orden = '{0}'", txtCodigo.Text), conexion.obtenerConexion());
            MySqlDataReader reader = comando.ExecuteReader();

            while (reader.Read())
            {
                num_orden_reader = reader.GetString(0);
                nombre_cliente = reader.GetString(1);
                apellido_cliente = reader.GetString(2);
                nombre_mesero = reader.GetString(3);
                apellido_mesero = reader.GetString(4);
                id_mesa = reader.GetInt32(5);
            }
            if (txtCodigo.Text.Length == 0)
            {
                MessageBox.Show("Introduzca el código a buscar.");
            }
            else if (num_orden_reader != txtCodigo.Text)
            {
                MessageBox.Show("No se encontraron coincidencias.");
            }
            else
            {
                txtDatos.Text = ("Num orden: " + num_orden_reader + "\r\n" + "Cliente: " + nombre_cliente + " " + apellido_cliente
                    + "\n" + "Mesa: " + id_mesa + "\n" + "Mesero: " + nombre_mesero +" " + apellido_mesero);
                btnAnadir.Enabled = true;
            }
        }

        private void Button1_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Buscar_Cliente_Load(object sender, EventArgs e)
        {

        }

        private void TxtCodigo_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
