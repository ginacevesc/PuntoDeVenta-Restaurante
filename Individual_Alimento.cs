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
    public partial class Individual_Alimento : Form
    {
        string codigo;
        public Individual_Alimento()
        {
            InitializeComponent();
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            MySqlCommand comando = new MySqlCommand(String.Format("select * from alimento where codigo_alimento = '{0}'", txtCodigo.Text), conexion.obtenerConexion());
            MySqlDataReader reader = comando.ExecuteReader();
            AddAlimento alimento = new AddAlimento();
            while (reader.Read())
            {

                alimento.CODIGO = reader.GetString(1);
                alimento.NOMBRE = reader.GetString(2);
                alimento.PRECIO = reader.GetDouble(3);
                alimento.DESCRIPCION = reader.GetString(4);
            }
            codigo = alimento.CODIGO;
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
                dgvAlimentoIndividual.DataSource = Funciones.ConsultasIndividualesAlimentos(txtCodigo.Text);
            }
        }

        private void BtnCerrarSesion_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Individual_Alimento_Load(object sender, EventArgs e)
        {

        }
    }
}
