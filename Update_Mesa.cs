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
    public partial class Update_Mesa : Form
    {
        int id_mesero;
        string codigo_mesero;
        int id;
        string ubicacion;
        string estado;
        string codigo;
        int idd_mesero;
        string codigo_meserob;
        public Update_Mesa()
        {
            InitializeComponent();
            txtID.Enabled = false;
            txtUbicacion.Enabled = false;
            btnAgregar.Enabled = false;
        }

        private void BtnCerrarSesion_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            MySqlCommand comando = new MySqlCommand(String.Format("select * from mesa where codigo_mesa = '{0}'", comboCodigos.Text), conexion.obtenerConexion());
            MySqlDataReader reader = comando.ExecuteReader();

            while (reader.Read())
            {
                id = reader.GetInt32(1);
                codigo = reader.GetString(2);
                ubicacion = reader.GetString(3);
                estado = reader.GetString(4);
            }
            MySqlCommand commando = new MySqlCommand(String.Format("select * from mesero where id_mesero = '{0}'", id), conexion.obtenerConexion());
            MySqlDataReader rexder = commando.ExecuteReader();

            while (rexder.Read())
            {
                idd_mesero = rexder.GetInt32(0);
                codigo_meserob = rexder.GetString(1);
            }
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
                txtID.Text = id.ToString();
                txtUbicacion.Text = ubicacion;
                txtEstado.Text = estado;
                btnAgregar.Enabled = true;
                txtID.Enabled = true;
                txtUbicacion.Enabled = true;
                btnAgregar.Enabled = true;
            }
        }

        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            int es = 1;
            MySqlCommand comando = new MySqlCommand(String.Format("select * from mesero where estado_mesero = '{0}'", es), conexion.obtenerConexion());
            MySqlDataReader reader = comando.ExecuteReader();
            int band = 0;

            while (reader.Read())
            {
                id_mesero = reader.GetInt32(0);
                codigo_mesero = reader.GetString(1);
                estado = reader.GetString(4);
                if(codigo_mesero == txtID.Text)
                {
                    band = 1;
                }
            }
            if (txtID.Text.Length == 0 || txtUbicacion.Text.Length == 0 || txtEstado.Text.Length == 0)
            {
                MessageBox.Show("No se han llenado uno o más campos obligatorios.");
            }
            else if(band == 0)
            {
                MessageBox.Show("Codigo de mesero erróneo.");
            }
            else
            {
                AddMesa m = new AddMesa();
                m.id_meseroMesa = Convert.ToInt32(txtID.Text);
                m.ubicacionMesa = txtUbicacion.Text;
                m.estadoMesa = Convert.ToInt32(txtEstado.Text);
                int retorno = Funciones.actualizarMesa(m, codigo);
                if (retorno > 0)
                {
                    this.Close();
                    MessageBox.Show("Mesa actualizada correctamente.");
                }
                else
                {
                    MessageBox.Show("Ocurrió un error al actualizar Mesa. Inténtelo nuevamente");
                }
            }
        }

        private void RectangleShape1_Click(object sender, EventArgs e)
        {

        }

        private void Update_Mesa_Load(object sender, EventArgs e)
        {
            int estado = 1;
            MySqlCommand comando = new MySqlCommand(String.Format("select codigo_mesa from mesa where estado_mesa = '{0}'", estado), conexion.obtenerConexion());
            MySqlDataReader reader = comando.ExecuteReader();

            while (reader.Read())
            {
                comboCodigos.Refresh();
                comboCodigos.Items.Add(reader.GetValue(0).ToString());
            }
        }

        private void Label3_Click(object sender, EventArgs e)
        {

        }
    }
}
