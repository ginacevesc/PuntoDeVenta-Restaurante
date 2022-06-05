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
    public partial class Update_Cliente : Form
    {
        int id;
        string codigo;
        string nombre;
        string apellido;
        string telefono;
        string codigo_anterior;
        public Update_Cliente()
        {
            InitializeComponent();
            txtID.Enabled = false;
            txtApellido.Enabled = false;
            txtTelefono.Enabled = false;
            btnAgregar.Enabled = false;
            txtCode.Enabled = false;
        }

        private void BtnCerrarSesion_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            MySqlCommand comando = new MySqlCommand(String.Format("select * from cliente where codigo_cliente = '{0}'", txtCodigo.Text), conexion.obtenerConexion());
            MySqlDataReader reader = comando.ExecuteReader();

            while (reader.Read())
            {
                id = reader.GetInt32(0);
                codigo = reader.GetString(1);
                codigo_anterior = reader.GetString(1);
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
                txtID.Text = nombre;
                txtApellido.Text = apellido;
                txtTelefono.Text = telefono;
                txtCode.Text = codigo;
                txtID.Enabled = true;
                txtApellido.Enabled = true;
                txtCode.Enabled = true;
                txtTelefono.Enabled = true;
                btnAgregar.Enabled = true;
            }
        }

        private void BtnAgregar_Click(object sender, EventArgs e)
        {

            if (txtID.Text.Length == 0 || txtApellido.Text.Length == 0)
            {
                MessageBox.Show("No se han llenado uno o más campos obligatorios.");
            }
            else
            {
                AddCliente c = new AddCliente();
                c.NOMBRE = txtID.Text;
                c.APELLIDO = txtApellido.Text;
                c.TELEFONO = txtTelefono.Text;
                c.CODIGO = txtCode.Text;

                int retorno = Funciones.actualizarCliente(c, codigo_anterior);
                if (retorno > 0)
                {
                    this.Close();
                    MessageBox.Show("Cliente actualizado correctamente.");
                }
                else
                {
                    MessageBox.Show("Ocurrió un error al actualizar Cliente. Inténtelo nuevamente");
                }
            }
        }

        private void Update_Cliente_Load(object sender, EventArgs e)
        {

        }

        private void TxtCode_TextChanged(object sender, EventArgs e)
        {


        }

        private void TxtCodigo_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
