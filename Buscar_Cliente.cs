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
    public partial class Buscar_Cliente : Form
    {
        string codigo_M;
        string codigo;
        string nombre;
        string apellido;
        string telefono;
        int num_orden;
        int id_mesa = 0;
        public Buscar_Cliente()
        {
            InitializeComponent();
            btnAnadir.Enabled = false;
        }
        public Buscar_Cliente(string v)
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
            MySqlCommand comando = new MySqlCommand(String.Format("SELECT MAX(num_orden) from pedido"), conexion.obtenerConexion());
            MySqlDataReader reader = comando.ExecuteReader();

            while (reader.Read())
            {
                num_orden = reader.GetInt32(0);
            }
            //MessageBox.Show(num_orden.ToString());
            Pedido p = new Pedido(codigo.ToString(), Convert.ToInt32(num_orden+1), codigo_M.ToString(), id_mesa);
            this.Close();
            p.ShowDialog();
            this.Show();
        }

        private void TxtDatos_TextChanged(object sender, EventArgs e)
        {

        }

        private void BtnBuscar_Click_1(object sender, EventArgs e)
        {
            MySqlCommand comando = new MySqlCommand(String.Format("select * from cliente where codigo_cliente = '{0}'", txtCodigo.Text), conexion.obtenerConexion());
            MySqlDataReader reader = comando.ExecuteReader();

            while (reader.Read())
            {
                codigo = reader.GetString(1);
                nombre = reader.GetString(2);
                apellido = reader.GetString(3);
                telefono = reader.GetString(4);
            }
            if (txtCodigo.Text.Length == 0)
            {
                MessageBox.Show("Introduzca el código a buscar.");
            }
            else if (codigo != txtCodigo.Text)
            {
                MessageBox.Show("No se encontraron coincidencias.");
            }
            else
            {
                txtDatos.Text = ("Código: " + codigo + "\r\n" + "Nombre: " + nombre + "\n" + "Apellido: " + apellido + "\n" + "Teléfono: " + telefono);
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
    }
}
