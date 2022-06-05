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
    public partial class Delete_Alimento : Form
    {
        int id_alimento;
        string codigo_alimento;
        string nombre_alimento;
        double precio_alimento;
        string descripcion_alimento;
        string estado_alimento;
        public Delete_Alimento()
        {
            InitializeComponent();
            btnEliminar.Enabled = false;
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
            MySqlCommand comando = new MySqlCommand(String.Format("select * from alimento where codigo_alimento = '{0}'", txtCodigo.Text), conexion.obtenerConexion());
            MySqlDataReader reader = comando.ExecuteReader();

            while (reader.Read())
            {
                id_alimento = reader.GetInt32(0);
                codigo_alimento = reader.GetString(1);
                nombre_alimento = reader.GetString(2);
                precio_alimento = reader.GetDouble(3);
                descripcion_alimento = reader.GetString(4);
                estado_alimento = reader.GetString(5);
            }

            if (txtCodigo.Text.Length == 0)
            {
                MessageBox.Show("Introduzca el código a buscar.");
            }
            else if (codigo_alimento != txtCodigo.Text)
            {
                MessageBox.Show("No se encontraron coincidencias.");
            }
            else
            {
                txtDatos.Text = ("\r\n\n" + "ID: " + id_alimento + "\r\n" + "Código: " + codigo_alimento + "\r\n" +
                "Nombre: " + nombre_alimento + "\r\n" + "Precio: " + precio_alimento +
                "\r\n" + "Descripción: " + descripcion_alimento);
                btnEliminar.Enabled = true;
            }
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            AddAlimento alim = new AddAlimento();
            alim.CODIGO = codigo_alimento;
            alim.NOMBRE = nombre_alimento;
            alim.PRECIO = precio_alimento;
            alim.DESCRIPCION = descripcion_alimento;
            alim.ESTADO = estado_alimento;
            int est = 0;
            int retorno = Funciones.eliminarAlimento(alim, est);

            if (retorno > 0)
            {
                this.Close();
                MessageBox.Show("Alimento eliminado correctamente.");
            }
            else
            {
                MessageBox.Show("Ocurrió un error al eliminar Alimento. Inténtelo nuevamente");
            }
        }

        private void Delete_Alimento_Load(object sender, EventArgs e)
        {

        }
    }
}
