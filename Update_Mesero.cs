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
    public partial class Update_Mesero : Form
    {
        int id;
        string codigo;
        string password;
        string tipo;
        string nombre;
        string apellido;
        string direccion;
        string telefono;
        string codigo_anterior;
        int estado;
        public Update_Mesero()
        {
            InitializeComponent();
            txtNombre.Enabled = false;
            txtApellido.Enabled = false;
            txtDireccion.Enabled = false;
            txtPassword.Enabled = false;
            txtTelefono.Enabled = false;
            cbactivo.Enabled = false;
            cbinactivo.Enabled = false;
            txtCode.Enabled = false;
            rbadmi.Enabled = false;
            rbmesero.Enabled = false;
            btnAgregar.Enabled = false;
        }

        private void TxtNombre_TextChanged(object sender, EventArgs e)
        {

        }

        private void BtnCerrarSesion_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            MySqlCommand comando = new MySqlCommand(String.Format("SELECT * FROM mesero WHERE codigo_mesero = '{0}'", comboCodigos.Text), conexion.obtenerConexion());
            MySqlDataReader reader = comando.ExecuteReader();
            while (reader.Read())
            {
                id = reader.GetInt32(0);
                codigo = reader.GetString(1);
                codigo_anterior = reader.GetString(1);
                password = reader.GetString(2);
                tipo = reader.GetString(3);
                nombre = reader.GetString(4);
                apellido = reader.GetString(5);
                direccion = reader.GetString(6);
                telefono = reader.GetString(7);
                estado = reader.GetInt32(8);
            }
            if (comboCodigos.Text.Length == 0)
            {
                MessageBox.Show("Introduzca el mesero que desea buscar.");
            }
            else if (codigo != comboCodigos.Text)
            {
                MessageBox.Show("No se encontraron coincidencias.");
            }
            else
            {
                txtNombre.Text = nombre;
                txtApellido.Text = apellido;
                txtPassword.Text = password;
                txtTelefono.Text = telefono;
                txtCode.Text = codigo;
                txtDireccion.Text = direccion;
                if (tipo == rbadmi.Text)
                    rbadmi.Checked = true;
                else if (tipo == rbmesero.Text)
                    rbmesero.Checked = true;

                if (estado == 1)
                    cbactivo.Checked = true;
                else
                    cbinactivo.Checked = true;
                txtNombre.Enabled = true;
                txtApellido.Enabled = true;
                txtCode.Enabled = true;
                txtDireccion.Enabled = true;
                txtPassword.Enabled = true;
                txtTelefono.Enabled = true;
                cbactivo.Enabled = true;
                cbinactivo.Enabled = true;
                rbadmi.Enabled = true;
                rbmesero.Enabled = true;
                btnAgregar.Enabled = true;
            }
        }

        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            if (txtCode.Text.Length == 0 || (cbactivo.Checked == false && cbinactivo.Checked == false) || comboCodigos.Text.Length == 0 || txtApellido.Text.Length == 0 || txtDireccion.Text.Length == 0 || txtPassword.Text.Length == 0 || txtTelefono.Text.Length == 0 || (rbadmi.Checked == false && rbmesero.Checked == false))
            {
                MessageBox.Show("No se han llenado uno o más campos obligatorios.");
            }
            else
            {
                AddMesero m = new AddMesero();
                m.PASSWORD = txtPassword.Text;
                if (rbadmi.Checked == true)
                    m.TIPO = rbadmi.Text;
                else if (rbmesero.Checked == true)
                    m.TIPO = rbmesero.Text;
                m.NOMBRE = txtNombre.Text;
                m.APELLIDO = txtApellido.Text;
                m.DIRECCION = txtDireccion.Text;
                m.TELEFONO = txtTelefono.Text;
                m.CODIGO = txtCode.Text;
                if (cbactivo.Checked == true)
                    m.ESTADO = "1";
                else if (cbinactivo.Checked == true)
                    m.ESTADO = "0";
                int retorno = Funciones.actualizarMesero(m, codigo_anterior);
                if (retorno > 0)
                {
                    this.Close();
                    MessageBox.Show("Mesero actualizado correctamente.");
                }
                else
                {
                    MessageBox.Show("Ocurrió un error al actualizar mesero. Inténtelo nuevamente");
                }
            }
        }

        private void Boton_CheckedChanged(object sender, EventArgs e)
        {
            if (boton.Checked == true)
            {
                if (txtPassword.PasswordChar == '*')
                {
                    txtPassword.PasswordChar = '\0';
                }
            }
            else
            {
                txtPassword.PasswordChar = '*';
            }
        }

        private void Update_Mesero_Load(object sender, EventArgs e)
        {
            int estado = 1;
            MySqlCommand comando = new MySqlCommand(String.Format("SELECT codigo_mesero FROM mesero"), conexion.obtenerConexion());
            MySqlDataReader readerr = comando.ExecuteReader();

            while (readerr.Read())
            {
                comboCodigos.Refresh();
                comboCodigos.Items.Add(readerr.GetValue(0).ToString());
            }
        }

        private void comboCodigos_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
