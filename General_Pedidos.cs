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
    public partial class General_Pedidos : Form
    {
        public General_Pedidos()
        {
            InitializeComponent();
            MySqlConnection con = new MySqlConnection("server=127.0.0.1;database=restaurante;Uid=root;pwd=g1n4;");
            //int estado = 1;
            con.Open();
            MySqlCommand comando = new MySqlCommand(string.Format("select * from pedido"), con);
            //dgvPedidos.DataSource = Funciones.consultasGeneralesPedidos();
            DataTable dt = new DataTable();
            MySqlDataAdapter SDA = new MySqlDataAdapter(comando);
            //DataTable dt = new DataTable();
            SDA.Fill(dt);
            dgvPedidos.DataSource = dt;
        }

        private void BtnCerrarSesion_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void General_Pedidos_Load(object sender, EventArgs e)
        {

        }

        private void LblAgregarMesa_Click(object sender, EventArgs e)
        {

        }
    }
}
