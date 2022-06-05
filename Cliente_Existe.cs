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
using MySql.Data.MySqlClient;
using Restaurante.MySQL;
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
    public partial class Cliente_Existe : Form
    {
        string codigo_M;
        public Cliente_Existe()
        {
            InitializeComponent();
        }
        public Cliente_Existe(string v)
        {
            InitializeComponent();
            codigo_M = v;
        }

        private void Cliente_Existe_Load(object sender, EventArgs e)
        {

        }

        private void BtnClienteExistente_Click(object sender, EventArgs e)
        {
            Buscar_Cliente bc = new Buscar_Cliente(codigo_M.ToString());
            this.Close();
            bc.ShowDialog();
            this.Show();
        }

        private void BtnClienteNuevo_Click(object sender, EventArgs e)
        {
            int codigo_cliente = 0;
            MySqlCommand comando_codigo = new MySqlCommand(String.Format("SELECT MAX(codigo_cliente) FROM cliente"), conexion.obtenerConexion());
            MySqlDataReader reader_codigo = comando_codigo.ExecuteReader();
            while (reader_codigo.Read())
            {
                codigo_cliente = Convert.ToInt32(reader_codigo.GetString(0));
            }
            codigo_cliente++;
            Add_Cliente ac = new Add_Cliente(codigo_M.ToString(), codigo_cliente);
            this.Close();
            ac.ShowDialog();
            this.Show();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCuentaExistente_Click(object sender, EventArgs e)
        {
            Buscar_Cuenta bcu = new Buscar_Cuenta(codigo_M.ToString());
            this.Close();
            bcu.ShowDialog();
            this.Show();
        }
    }
}
