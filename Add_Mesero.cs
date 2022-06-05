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

namespace Restaurante
{
    public partial class Add_Mesero : Form
    {
        public Add_Mesero()
        {
            InitializeComponent();
        }

        private void TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void BtnAnadir_Click(object sender, EventArgs e)
        {
            if ((cbactivo.Checked == false && cbinactivo.Checked == false) || txtNombre.Text.Length == 0 || txtApellido.Text.Length == 0 || txtPassword.Text.Length == 0 || txtDireccion.Text.Length == 0 || txtTelefono.Text.Length == 0 || (rbadmi.Checked == false && rbmesero.Checked == false))
            {
                MessageBox.Show("No se han llenado uno o más campos obligatorios.");
            }
            else
            {
                AddMesero m = new AddMesero();
                //m.CODIGO = Funciones.codigoMesero().ToString();
                m.PASSWORD = txtPassword.Text;
                if (rbadmi.Checked == true)
                    m.TIPO = "administrador";
                else if (rbmesero.Checked == true)
                    m.TIPO = "mesero";

                if (cbactivo.Checked == true)
                    m.ESTADO = "1";
                else
                    m.ESTADO = "0";

                m.NOMBRE = txtNombre.Text;
                m.APELLIDO = txtApellido.Text;
                m.DIRECCION = txtDireccion.Text;
                m.TELEFONO = txtTelefono.Text;
                m.CODIGO = txtCodigo.Text;
                int retorno = Funciones.agregarMesero(m);
                if (retorno > 0)
                {
                    this.Close();
                    MessageBox.Show("Mesero agregado correctamente.");
                }
                else
                {
                    MessageBox.Show("Ocurrió un error al agregar mesero. Inténtelo nuevamente");
                }
            }
        }

        private void CbDesenmascara_CheckedChanged(object sender, EventArgs e)
        {
            if (cbDesenmascara.Checked == true)
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

        private void BtnCerrarSesion_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Add_Mesero_Load(object sender, EventArgs e)
        {

        }

    }
}
