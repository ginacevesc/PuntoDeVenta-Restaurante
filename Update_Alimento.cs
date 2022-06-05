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
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Restaurante.MySQL;

namespace Restaurante
{
    public partial class Update_Alimento : Form
    {
        int id_alimento;
        string codigo_alimento;
        string codigo_anterior;
        string nombre_alimento;
        double precio_alimento;
        string descripcion_alimento;
        int estado_alimento;
        public Update_Alimento()
        {
            InitializeComponent();
            txtNombre.Enabled = false;
            //txtCodigo.Enabled = false;
            txtDescripcion.Enabled = false;
            txtPrecio.Enabled = false;
            btnActualizar.Enabled = false;
            txtEstado.Enabled = false;
        }

        private void BtnCerrarSesion_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnAnadir_Click(object sender, EventArgs e)
        {
            if (txtNombre.Text.Length == 0 || txtPrecio.Text.Length == 0)
            {
                MessageBox.Show("No se han llenado uno o más campos obligatorios.");
            }
            else
            {
                AddAlimento alimento = new AddAlimento();
                alimento.NOMBRE = txtNombre.Text;
                alimento.PRECIO = Convert.ToDouble(txtPrecio.Text.ToString());
                alimento.DESCRIPCION = txtDescripcion.Text;
                alimento.ESTADO = txtEstado.Text;
                alimento.CODIGO = codigo_alimento;

                int retorno = Funciones.actualizarAlimento(alimento, codigo_anterior);
                if (retorno > 0)
                {
                    this.Close();
                    MessageBox.Show("Alimento actualizado correctamente.");
                }
                else
                {
                    MessageBox.Show("Ocurrió un error al actualizar alimento. Inténtelo nuevamente");
                }
            }
        }

        private void Update_Alimento_Load(object sender, EventArgs e)
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
                codigo_anterior = reader.GetString(1);
                nombre_alimento = reader.GetString(2);
                precio_alimento = reader.GetDouble(3);
                descripcion_alimento = reader.GetString(4);
                estado_alimento = reader.GetInt32(5);

            }

            if (txtCodigo.Text.Length == 0)
            {
                MessageBox.Show("Introduzca el código a buscar.");
            }
            else if(codigo_alimento != txtCodigo.Text)
            {
                MessageBox.Show("No se encontraron coincidencias.");
            }
            else
            {
                txtNombre.Text = nombre_alimento;
                txtPrecio.Text = precio_alimento.ToString();
                txtDescripcion.Text = descripcion_alimento;
                txtEstado.Text = Convert.ToString(estado_alimento);
                txtNombre.Enabled = true;
                //txtCode.Enabled = true;
                txtDescripcion.Enabled = true;
                txtPrecio.Enabled = true;
                txtEstado.Enabled = true;
                btnActualizar.Enabled = true;
            }
        }

        private void TxtCodigo_TextChanged(object sender, EventArgs e)
        {

        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }
    }
}
