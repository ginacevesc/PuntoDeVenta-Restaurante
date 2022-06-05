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
    public partial class Pedido : Form
    {
        int CLIENTE, MESERO, ALIMENTO;
        public Pedido()
        {
            InitializeComponent();
            
        }
        public Pedido(string CODIGO, int numero_orden, string c, int mesa)
        {
            InitializeComponent();
            txtCodigoCliente.Text = CODIGO;
            txtNOrden.Text = numero_orden.ToString();
            txtCodigoMesero.Text = c;
            txtNOrden.Enabled = false;
            if (mesa == 0)
            {
                comboCodigos.Text = " ";
            }
            if (mesa!=0)
            {
              comboCodigos.Text = mesa.ToString();
                comboCodigos.Enabled = false;
            }
            MySqlCommand comando = new MySqlCommand(string.Format("select * from pedido"), conexion.obtenerConexion());
            MySqlDataReader reader = comando.ExecuteReader();
            int id = 0;
            while (reader.Read())
            {
                id = reader.GetInt32(0);
            }
            id += 1;
            //txtID.Text = id.ToString();
        }

        private void BtnCerrarSesion_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void RectangleShape1_Click(object sender, EventArgs e)
        {

        }

        private void Pedido_Load(object sender, EventArgs e)
        {
            int estado = 1;
            
            MySqlCommand comando = new MySqlCommand(String.Format("select codigo_mesa from mesa where estado_mesa = '{0}'", estado), conexion.obtenerConexion());
            MySqlDataReader reader = comando.ExecuteReader();

            while (reader.Read())
            {
                comboCodigos.Refresh();
                comboCodigos.Items.Add(reader.GetValue(0).ToString());
            }
            
            MySqlCommand commando = new MySqlCommand(String.Format("select nombre_alimento from alimento where estado_alimento = '{0}'", estado), conexion.obtenerConexion());
            MySqlDataReader rexder = commando.ExecuteReader();

            while (rexder.Read())
            {
                comboAlimento.Refresh();
                comboAlimento.Items.Add(rexder.GetValue(0).ToString());
            }
        }

        private void BtnMostrar_Click(object sender, EventArgs e)
        {
            //dgvPedido.DataSource = Funciones.MostrarPedido();
            MySqlConnection con = new MySqlConnection("server=127.0.0.1;database=restaurante;Uid=root;pwd=g1n4;");
            int estado = 1;
            con.Open();
            MySqlCommand comm = new MySqlCommand(string.Format("SELECT * FROM pedido WHERE num_orden = '{0}'", Convert.ToInt32(txtNOrden.Text)), con);
            DataTable dt = new DataTable();
            MySqlDataAdapter SDA = new MySqlDataAdapter(comm);
            //DataTable dt = new DataTable();
            SDA.Fill(dt);
            dgvPedido.DataSource = dt;
        }

        private void DgvPedido_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void DgvPedido_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            string idAlimento, cant, nom;
            int nombre;

            idAlimento = dgvPedido.SelectedRows[0].Cells[5].Value.ToString();
            txtCantidad.Text = dgvPedido.SelectedRows[0].Cells[6].Value.ToString();
            //int cantidad = Convert.ToInt32(idAlimento);
            nombre = Convert.ToInt32(idAlimento);
            MySqlCommand commando = new MySqlCommand(String.Format("select nombre_alimento from alimento where id_alimento = '{0}'", nombre), conexion.obtenerConexion());
            MySqlDataReader reader = commando.ExecuteReader();

            while (reader.Read())
            {
                nom = reader.GetString(0);
                comboAlimento.Text = nom.ToString();
            }           
            
        }

        private void BtnModificar_Click(object sender, EventArgs e)
        {
            int pedido, alimento, cantidad;
            string p, a, c, o, cl;
            p = dgvPedido.SelectedRows[0].Cells[0].Value.ToString();
            o = dgvPedido.SelectedRows[0].Cells[1].Value.ToString();
            cl = dgvPedido.SelectedRows[0].Cells[2].Value.ToString();
            a = comboAlimento.Text;
            c = txtCantidad.Text;
            MessageBox.Show(p);
            pedido = Convert.ToInt32(p);
            alimento = Convert.ToInt32(a);
            cantidad = Convert.ToInt32(c);
            AddPedido pe = new AddPedido();
            pe.ALIMENTO = alimento;
            pe.CANTIDAD = cantidad;
            //MySqlCommand comando = new MySqlCommand(string.Format("Update pedido set id_alimento = '{0}', cantidad_platillo = '{1}' where id_pedido = '{2}'", alimento, cantidad, Convert.ToInt32(txtID.Text)), conexion.obtenerConexion());
            
        }

        private void ComboCodigos_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void BtnGenerar_Click(object sender, EventArgs e)
        {
            Funciones.NoLiberaMesa(comboCodigos.Text);
            this.Close();

        }

        private void Label6_Click(object sender, EventArgs e)
        {

        }

        private void TxtCodigoCliente_TextChanged(object sender, EventArgs e)
        {

        }

        private void ComboCodigos_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void BtnAnadir_Click(object sender, EventArgs e)
        {
            if(comboCodigos.Text.Length == 0 || comboAlimento.Text.Length == 0 || txtCantidad.Text.Length == 0)
            {
                MessageBox.Show("No se han llenado uno o más campos obligatorios.");
            }
            MySqlCommand commando = new MySqlCommand(String.Format("select id_cliente from cliente where codigo_cliente = '{0}'", txtCodigoCliente.Text), conexion.obtenerConexion());
            MySqlDataReader rexder = commando.ExecuteReader();

            while (rexder.Read())
            {
                CLIENTE = rexder.GetInt32(0);
            }

            MySqlCommand comando = new MySqlCommand(String.Format("select id_mesero from mesero where codigo_mesero = '{0}'", txtCodigoMesero.Text), conexion.obtenerConexion());
            MySqlDataReader reader = comando.ExecuteReader();

            while (reader.Read())
            {
                MESERO = reader.GetInt32(0);
            }

            MySqlCommand cxmando = new MySqlCommand(String.Format("select id_alimento from alimento where nombre_alimento = '{0}'", comboAlimento.Text), conexion.obtenerConexion());
            MySqlDataReader reeader = cxmando.ExecuteReader();

            while (reeader.Read())
            {
                ALIMENTO = reeader.GetInt32(0);
            }


            MySqlCommand comandoo = new MySqlCommand(String.Format("INSERT INTO pedido (num_orden, id_cliente, id_mesa, id_mesero, " +
                "id_alimento, cantidad_platillo, estado_pedido) values('{0}', '{1}','{2}','{3}','{4}','{5}',{6})", 
                txtNOrden.Text, CLIENTE, Convert.ToInt32(comboCodigos.Text), MESERO, ALIMENTO, 
                Convert.ToInt32(txtCantidad.Text), 1), conexion.obtenerConexion());
            MySqlDataReader readeer = comandoo.ExecuteReader();

            while (reader.Read())
            {
                comboCodigos.Refresh();
                comboCodigos.Items.Add(readeer.GetValue(0).ToString());
            }
            MySqlConnection con = new MySqlConnection("server=127.0.0.1;database=restaurante;Uid=root;pwd=g1n4;");
            int estado = 1;
            con.Open();
            MySqlCommand comm = new MySqlCommand(string.Format("SELECT pedido.num_orden AS NUM_ORDEN,CONCAT" +
                "(cliente.nombre_cliente,\" \", cliente.apellido_cliente) AS CLIENTE," +
                "CONCAT(mesero.nombre_mesero,\" \", mesero.apellido_mesero) AS MESERO, alimento.nombre_alimento AS ALIMENTO," +
                "pedido.cantidad_platillo AS CANTIDAD,pedido.id_mesa AS MESA,pedido.estado_pedido AS ESTADO FROM pedido " +
                "INNER JOIN cliente ON pedido.id_cliente = cliente.id_cliente " +
                "INNER JOIN mesero ON pedido.id_mesero = mesero.id_mesero " +
                "INNER JOIN alimento ON pedido.id_alimento = alimento.id_alimento WHERE num_orden = '{0}'", Convert.ToInt32(txtNOrden.Text)), con);
            DataTable dt = new DataTable();
            MySqlDataAdapter SDA = new MySqlDataAdapter(comm);
            //DataTable dt = new DataTable();
            SDA.Fill(dt);
            dgvPedido.DataSource = dt;
            txtCantidad.Clear();
        }
    }
}
