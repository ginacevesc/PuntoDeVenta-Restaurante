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
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Restaurante.MySQL;
using iTextSharp.text.pdf;
using iTextSharp.text;
using System.IO;

namespace Restaurante
{

    public partial class Generar_Cuenta : Form
    {
        string num_orden, NOMBRE, APELLIDO, nombre_mesero, apellido_mesero;
        string nombre;
        int num_o, cod;
        string codigo;
        string codigo_mesa;
        public Generar_Cuenta()
        {
            InitializeComponent();
            //dgvPrueba.DataSource = Funciones.Cuenta();
            //dgvPrueba.DataSource = Funciones.Cuenta();
            
        }
        public void returnTicket()
        {
            string nombre_archivo = "Cuenta";
            FileStream file = new FileStream("C:\\Users\\Gina\\Downloads\\" + nombre_archivo + "_No.Orden_" + comboCodigos.Text + ".pdf", FileMode.Create);
            Document document = new Document(PageSize.A4, 20, 20, 20, 20);
            PdfWriter pdf = PdfWriter.GetInstance(document, file);
            float cambio;
            document.Open();
            DateTime hoy = DateTime.Now.AddDays(0);
            string nombre = Convert.ToString(hoy.ToShortDateString());
            nombre = nombre.Replace('/', '-');
            iTextSharp.text.Image imagen = iTextSharp.text.Image.GetInstance("C:\\Users\\Gina\\Downloads\\AchisAchis.png");
            imagen.BorderWidth = 0;
            imagen.Alignment = Element.ALIGN_CENTER;
            Paragraph fechaActual = new Paragraph(nombre);
            document.Add(fechaActual);
            float percentage = 0.0f;
            percentage = 150 / imagen.Width;
            imagen.ScalePercent(percentage * 85);
            document.Add(imagen);
            int temp_int;
            string temp_str;
            document.Add(new Paragraph("NO CLIENTE      " + retornarIdCliente() + "\n"));
            document.Add(new Paragraph("NOMBRE CLIENTE  " + retornarNombreCliente() + " " + retornarApellidoCliente()));
            document.Add(new Paragraph("LO ATENDIO:      " + retornarNombreMesero() + " " + retornarApellidoMesero()));
            document.Add(new Paragraph("\n"));
            document.Add(new Paragraph("\n"));
            document.Add(new Paragraph("\n"));
            document.Add(new Paragraph("No. Orden: " + comboCodigos.Text));
            document.Add(new Paragraph("Total a pagar: " +txtTotal.Text));
            document.Add(new Paragraph("Tipo de Pago: " + txtTipo.Text));
            document.Add(new Paragraph("Recibido: " + txtPago.Text));
            cambio = Convert.ToInt32(txtPago.Text) - Convert.ToInt32(txtTotal.Text);
            document.Add(new Paragraph("Cambio: " + cambio));
            document.Add(new Paragraph("\n"));
            document.Add(new Paragraph("\n"));
            //document.Add(retornarTabla());    
            document.Close();
            

        }

        public int retornarIdCliente()
        {
            string sentencia = "SELECT cliente.codigo_cliente AS No_CLIENTE FROM cliente INNER JOIN pedido ON pedido.id_cliente = cliente.id_cliente WHERE pedido.num_orden = '{0}'";
            MySqlCommand command = new MySqlCommand(string.Format(sentencia, comboCodigos.Text), conexion.obtenerConexion());
            MySqlDataReader read = command.ExecuteReader();
            
            while (read.Read())
            {
                cod = read.GetInt32(0);
            }
            return cod;
        }
        public PdfPTable retornarTabla()
        {
            PdfPTable table = new PdfPTable(dgvPrueba.Columns.Count);
            for (int i = 0; i < dgvPrueba.Columns.Count; i++)
            {
                table.AddCell(new Phrase(dgvPrueba.Columns[i].HeaderText));
            }
            table.HeaderRows = 1;
            for (int j = 0; j < dgvPrueba.Columns.Count; j++)
            {
                for (int k = 0; k < dgvPrueba.Columns.Count; k++)
                {
                    if (dgvPrueba[k, j].Value != null)
                    {
                        table.AddCell(new Phrase(dgvPrueba[k, j].Value.ToString()));
                    }
                }
            }
            return table;
        }

        public string retornarNombreCliente()
        {
            string sentencia = "SELECT cliente.nombre_cliente FROM cliente INNER JOIN pedido ON pedido.id_cliente = cliente.id_cliente WHERE pedido.num_orden = '{0}'";
            MySqlCommand command = new MySqlCommand(string.Format(sentencia, comboCodigos.Text), conexion.obtenerConexion());
            MySqlDataReader read = command.ExecuteReader();
            while (read.Read())
            {
                NOMBRE = read.GetString(0);
            }
            return NOMBRE;
        }

        public string retornarApellidoCliente()
        {
            string sentencia = "SELECT cliente.apellido_cliente FROM cliente INNER JOIN pedido ON pedido.id_cliente = cliente.id_cliente WHERE pedido.num_orden = '{0}'";
            MySqlCommand command = new MySqlCommand(string.Format(sentencia, comboCodigos.Text), conexion.obtenerConexion());
            MySqlDataReader read = command.ExecuteReader();
            while (read.Read())
            {
                APELLIDO = read.GetString(0);
            }
            return APELLIDO;
        }

        public string retornarNombreMesero()
        {
            string sentencia = "SELECT mesero.nombre_mesero FROM mesero INNER JOIN pedido ON pedido.id_mesero = mesero.id_mesero WHERE pedido.num_orden = '{0}'";
            MySqlCommand command = new MySqlCommand(string.Format(sentencia, comboCodigos.Text), conexion.obtenerConexion());
            MySqlDataReader read = command.ExecuteReader();
            while (read.Read())
            {
                nombre_mesero = read.GetString(0);
            }
            return nombre_mesero;
        }

        public string retornarApellidoMesero()
        {
            string sentencia = "SELECT mesero.apellido_mesero FROM mesero INNER JOIN pedido ON pedido.id_mesero = mesero.id_mesero WHERE pedido.num_orden = '{0}'";
            MySqlCommand command = new MySqlCommand(string.Format(sentencia, comboCodigos.Text), conexion.obtenerConexion());
            MySqlDataReader read = command.ExecuteReader();
            while (read.Read())
            {
                apellido_mesero = read.GetString(0);
            }
            return apellido_mesero;
        }
        private void Generar_Cuenta_Load(object sender, EventArgs e)
        {
            txtTipo.Text = "Efectivo";
            int estado = 1;

            MySqlCommand comando = new MySqlCommand(String.Format("select distinct num_orden from pedido where estado_pedido = '{0}'", estado), conexion.obtenerConexion());
            MySqlDataReader reader = comando.ExecuteReader();

            while (reader.Read())
            {
                comboCodigos.Refresh();
                comboCodigos.Items.Add(reader.GetValue(0).ToString());
            }
        }

        private void TxtTipo_TextChanged(object sender, EventArgs e)
        {

        }

        private void RectangleShape1_Click(object sender, EventArgs e)
        {

        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            MySqlCommand comando = new MySqlCommand(String.Format("SELECT num_orden FROM pedido WHERE num_orden = '{0}' AND estado_pedido = 1", Convert.ToInt32(comboCodigos.Text)), conexion.obtenerConexion());
            MySqlDataReader reader = comando.ExecuteReader();
            
            while (reader.Read())
            {
                num_o = reader.GetInt32(0);
            }
            if (comboCodigos.Text.Length == 0)
            {
                MessageBox.Show("No se han llenado un campo obligatorio.");
            }
            else if(num_o != Convert.ToInt32(comboCodigos.Text))
            {
                MessageBox.Show("No se encontró ese número de orden.");
            }
            else
            {
                MySqlConnection con = new MySqlConnection("server=127.0.0.1;database=restaurante;Uid=root;pwd=g1n4;");
                //int estado = 1;
                con.Open();
                MySqlCommand comm = new MySqlCommand(string.Format("SELECT pedido.cantidad_platillo AS CANTIDAD, alimento.nombre_alimento AS ALIMENTO, alimento.precio_alimento AS PRECIO, alimento.precio_alimento*pedido.cantidad_platillo AS IMPORTE FROM pedido INNER JOIN alimento ON pedido.id_alimento = alimento.id_alimento WHERE pedido.num_orden = '{0}'", comboCodigos.Text), con);
                //MySqlCommand comm = new MySqlCommand(string.Format("Select pedido.cantidad_platillo, alimento.nombre_alimento, alimento.precio_alimento FROM pedido INNER JOIN alimento ON pedido.id_alimento = alimento.id_alimento WHERE pedido.num_orden = '{0}'", txtNOrden.Text), con);
                DataTable dt = new DataTable();
                MySqlDataAdapter SDA = new MySqlDataAdapter(comm);
                //DataTable dt = new DataTable();
                SDA.Fill(dt);
                dgvPrueba.DataSource = dt;
            }
            MySqlCommand commando = new MySqlCommand(String.Format("SELECT DISTINCT nombre_mesero FROM mesero JOIN pedido ON mesero.id_mesero = pedido.id_mesero WHERE num_orden = '{0}'", comboCodigos.Text), conexion.obtenerConexion());
            MySqlDataReader reeader = commando.ExecuteReader();
            
            while (reeader.Read())
            {
                nombre = reeader.GetString(0);
                txtMesero.Text = nombre;
            }
            MySqlCommand coomando = new MySqlCommand(String.Format("SELECT DISTINCT nombre_cliente FROM cliente JOIN pedido ON cliente.id_cliente = pedido.id_cliente WHERE num_orden = '{0}'", comboCodigos.Text), conexion.obtenerConexion());
            MySqlDataReader reaader = coomando.ExecuteReader();
            while (reaader.Read())
            {
                codigo = reaader.GetString(0);
                txtCliente.Text = codigo;
            }
            int contador = 0;
            double suma = 0;
            foreach(DataGridViewRow R in dgvPrueba.Rows)
            {
                if(contador < dgvPrueba.Rows.Count -1 || contador == dgvPrueba.Rows.Count -1)
                {
                    dgvPrueba.Rows[contador].Selected = true;
                    suma = int.Parse(dgvPrueba.SelectedRows[0].Cells["IMPORTE"].Value.ToString()) + suma;
                    contador = contador + 1;
                }
            }
            txtTotal.Text = suma.ToString();
            MySqlCommand coomandoo = new MySqlCommand(String.Format("SELECT id_mesa FROM pedido WHERE num_orden = '{0}'", comboCodigos.Text), conexion.obtenerConexion());
            MySqlDataReader reaadeer = coomandoo.ExecuteReader();
            while (reaadeer.Read())
            {
                codigo_mesa = reaadeer.GetString(0);
            }
        }

        private void BtnCerrarSesion_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DgvPrueba_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void BtnGenerar_Click(object sender, EventArgs e)
        {
            if(txtMesero.Text.Length == 0 || txtCliente.Text.Length == 0 || txtPago.Text.Length == 0 || txtTipo.Text.Length == 0 || txtTotal.Text.Length == 0)
            {
                MessageBox.Show("Error. Hay uno o más campos vacíos.");
            }
            else if(Convert.ToInt32(txtPago.Text) < Convert.ToInt32(txtTotal.Text))
            {
                MessageBox.Show("La cantidad introducida es menor al total");
            }
            else
            {
                returnTicket();
                //MessageBox.Show(codigo_mesa);
                int retorno = Funciones.cambiarEstadoMesa(1, codigo_mesa);
                if (retorno > 0)
                {
                    //this.Close();
                }
                else
                {
                    MessageBox.Show("Ocurrió un error al modificar el estado de la Mesa.");
                }
                int ret = Funciones.cambiarEstadoPedido(0, comboCodigos.Text.ToString());
                if (ret > 0)
                {
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Ocurrió un error al modificar el estado del Pedido.");
                }

                MessageBox.Show("Se ha generado el ticket exitosamente.");
            }
            
            //Funciones.LiberaMesa(txtNOrden.Text);
            /*
            string nombre_archivo = txtNOrden.Text + " " + "cuenta.pdf";
            FileStream file = new FileStream("C:\\Users\\Gina\\Desktop\\" + nombre_archivo, FileMode.Create);
            Document document = new Document(PageSize.A4, 50, 10, 15, 30);
            PdfWriter pdf = PdfWriter.GetInstance(document, file);

            document.Open();

            iTextSharp.text.Image imagen = iTextSharp.text.Image.GetInstance("C:\\Users\\PAOLA\\Desktop\\SEMINARIO DE BASES DE DATOS\\AchisAchisv2.png");
            imagen.BorderWidth = 0;
            imagen.Alignment = Element.ALIGN_CENTER;
            float percentage = 0.0f;
            percentage = 150 / imagen.Width;
            imagen.ScalePercent(percentage * 85);

            document.Add(imagen);
            /*
            document.Add(new Paragraph("\nCliente: " + folioo));
            document.Add(new Paragraph("\nDatos: " + pelicula.Text));
            document.Add(new Paragraph("\nETC: " + horario.Text));
            
            document.Close();
            */
            //Funciones.LiberaMesa(0, comboCodigos.Text);
            //Funciones.LiberaMesa(txtNOrden.Text);
        }
    }
}
