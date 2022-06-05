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
    public partial class Add_Cliente : Form
    {
        int num_orden = 0;
        string CODIGO;
        int id_mesa = 0;
        string codigo_M;
        public Add_Cliente()
        {
            InitializeComponent();
        }
        public Add_Cliente(string v, int codigo_cliente)
        {
            InitializeComponent();
            codigo_M = v;
            txtCodigo.Text = codigo_cliente.ToString();
            txtCodigo.Enabled = false;
        }

        private void BtnCerrarSesion_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnAnadir_Click(object sender, EventArgs e)
        { 
            if (txtNombre.Text.Length == 0 || txtApellido.Text.Length == 0)
            {
                MessageBox.Show("No se han llenado uno o más campos obligatorios.");
            }
            else
            {
                AddCliente c = new AddCliente();
                c.NOMBRE = txtNombre.Text;
                c.APELLIDO = txtApellido.Text;
                c.TELEFONO = txtTelefono.Text;
                c.CODIGO = txtCodigo.Text;
                int retorno = Funciones.agregarCliente(c);
                if (retorno > 0)
                {
                    MessageBox.Show("Cliente agregado correctamente.");
                    MySqlCommand comando = new MySqlCommand(String.Format("SELECT MAX(num_orden) FROM pedido"), conexion.obtenerConexion());
                    MySqlDataReader reader = comando.ExecuteReader();

                    while (reader.Read())
                    {
                        num_orden = Convert.ToInt32(reader.GetString(0));
                    }
                    
                    num_orden++;
                    //MessageBox.Show(num_orden.ToString());
                    Pedido p = new Pedido(txtCodigo.Text, Convert.ToInt32(num_orden+1), codigo_M.ToString(), id_mesa);
                    this.Close();
                    p.ShowDialog();
                    this.Show();
                }
                else
                {
                    MessageBox.Show("Ocurrió un error al agregar cliente. Inténtelo nuevamente");
                }
            }
        }

        private void Add_Cliente_Load(object sender, EventArgs e)
        {

        }

    }
}
