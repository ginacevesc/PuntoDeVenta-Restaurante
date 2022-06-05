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
    public partial class Individual_Mesero : Form
    {
        string codigo;
        public Individual_Mesero()
        {
            InitializeComponent();
        }

        private void BtnCerrarSesion_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Individual_Mesero_Load(object sender, EventArgs e)
        {

        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            MySqlCommand comando = new MySqlCommand(String.Format("select * from mesero where codigo_mesero = '{0}'", txtCodigo.Text), conexion.obtenerConexion());
            MySqlDataReader reader = comando.ExecuteReader();
            AddMesero mesero = new AddMesero();
            while (reader.Read())
            {
                mesero.CODIGO = reader.GetString(1);
                mesero.PASSWORD = reader.GetString(2);
                mesero.TIPO = reader.GetString(3);
                mesero.NOMBRE = reader.GetString(4);
                mesero.APELLIDO = reader.GetString(5);
                mesero.DIRECCION = reader.GetString(6);
                mesero.TELEFONO = reader.GetString(7);
            }
            codigo = mesero.CODIGO;
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
                dgvMeseroIndividual.DataSource = Funciones.ConsultasIndividualesMeseros(txtCodigo.Text);
            }
        }
    }
}
