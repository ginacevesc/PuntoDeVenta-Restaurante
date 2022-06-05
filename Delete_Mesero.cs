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
    public partial class Delete_Mesero : Form
    {
        int id;
        string codigo;
        string password;
        string tipo;
        string nombre;
        string apellido;
        string direccion;
        string telefono;
        int estado;
        public Delete_Mesero()
        {
            InitializeComponent();
            btnEliminar.Enabled = false;
        }

        private void Delete_Mesero_Load(object sender, EventArgs e)
        {
            MySqlCommand comando = new MySqlCommand(String.Format("select codigo_mesero from mesero"), conexion.obtenerConexion());
            MySqlDataReader reader = comando.ExecuteReader();

            while (reader.Read())
            {
                comboCodigos.Refresh();
                comboCodigos.Items.Add(reader.GetValue(0).ToString());
            }
        }

        private void BtnCerrarSesion_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void RectangleShape1_Click(object sender, EventArgs e)
        {

        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            MySqlCommand comando = new MySqlCommand(String.Format("SELECT * FROM mesero WHERE codigo_mesero = '{0}' AND estado_mesero = 1", comboCodigos.Text), conexion.obtenerConexion());
            MySqlDataReader reader = comando.ExecuteReader();

            while (reader.Read())
            {
                id = reader.GetInt32(0);
                codigo = reader.GetString(1);
                password = reader.GetString(2);
                tipo = reader.GetString(3);
                nombre = reader.GetString(4);
                apellido = reader.GetString(5);
                direccion = reader.GetString(6);
                telefono = reader.GetString(7);
                estado = reader.GetInt32(8);
            }
            if (tipo == "administrador")
                tipo = "Administrador";
            else if (tipo == "mesero")
                tipo = "Mesero";

            string estado_string;

            if (comboCodigos.Text.Length == 0)
            {
                MessageBox.Show("Introduzca el código a buscar.");
            }
            else if (codigo != comboCodigos.Text)
            {
                MessageBox.Show("No se encontraron coincidencias.");
            }
            else
            {
                txtDatos.Text = ("Código: " + codigo + "\r\n" + "Password: *******" +
                "\n" + "Tipo: " + tipo + "\n" + "Nombre: " + nombre + "\n" + "Apellidos: " + apellido +
                "\n" + "Dirección: " + direccion + "\n" + "Teléfono: " + telefono);
                btnEliminar.Enabled = true;
            }
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            AddMesero mesero = new AddMesero();
            mesero.CODIGO = codigo;
            mesero.PASSWORD = password;
            mesero.TIPO = tipo;
            mesero.NOMBRE = nombre;
            mesero.APELLIDO = apellido;
            mesero.DIRECCION = direccion;
            mesero.TELEFONO = telefono;
            int retorno = Funciones.eliminarMesero(mesero, 0);

            if (retorno > 0)
            {
                this.Close();
                MessageBox.Show("Mesero eliminado correctamente.");
            }
            else
            {
                MessageBox.Show("Ocurrió un error al eliminar mesero. Inténtelo nuevamente");
            }
        }
    }
}
