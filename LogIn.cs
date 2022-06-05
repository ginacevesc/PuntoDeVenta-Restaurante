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
using MySql.Data.MySqlClient;

namespace Restaurante
{
    public partial class LogIn : Form
    {
        public LogIn()
        {
            InitializeComponent();
        }

        MySqlConnection conexion = new MySqlConnection("server=127.0.0.1;database=restaurante;Uid=root;pwd=g1n4;");

        public void log(string codigo, string password)
        {
            try
            {
                conexion.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT nombre_mesero, tipo_mesero FROM mesero WHERE codigo_mesero = @code AND password_mesero = @pass AND estado_mesero !=0", conexion);
                cmd.Parameters.AddWithValue("code", codigo);
                cmd.Parameters.AddWithValue("pass", password);
                MySqlDataAdapter sda = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);

                if (dt.Rows.Count == 1)
                {
                    if (dt.Rows[0][1].ToString() == "administrador")
                    {
                        this.Hide();
                        PrincipalAdmi admi = new PrincipalAdmi(dt.Rows[0][0].ToString(), txtUser.Text);
                        //Pedido p = new Pedido(txtUser.Text);
                        //Administrador admi = new Administrador(dt.Rows[0][0].ToString());
                        txtPassword.Clear();
                        txtUser.Clear();
                        admi.ShowDialog();
                        this.Show();
                    }
                    else if(dt.Rows[0][1].ToString() == "mesero")
                    {
                        this.Hide();
                        PrincipalMesero mes = new PrincipalMesero(dt.Rows[0][0].ToString(), txtUser.Text);
                        txtPassword.Clear();
                        txtUser.Clear();
                        mes.ShowDialog();
                        this.Show();
                    }
                }
                else
                {
                    MessageBox.Show("Usuario/Contraseña incorrectos.");
                    txtPassword.Clear();
                    txtUser.Clear();
                }

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            finally
            {
                conexion.Close();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void PictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void LineShape2_Click(object sender, EventArgs e)
        {

        }

        private void TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void RadioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void RadioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void TextBox1_Enter(object sender, EventArgs e)
        {
            
        }

        private void TxtUser_Leave(object sender, EventArgs e)
        {
            
        }

        private void TxtPassword_Enter(object sender, EventArgs e)
        {
            
        }

        private void TxtPassword_Leave(object sender, EventArgs e)
        {
            
        }

        private void BtAcceder_Click(object sender, EventArgs e)
        {
            //this.Hide();
            //GHAPA forma = new GHAPA();
            //forma.ShowDialog();
            //forma.Show();
            log(this.txtUser.Text, this.txtPassword.Text);
        }

        private void LblCodigo_Click(object sender, EventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
