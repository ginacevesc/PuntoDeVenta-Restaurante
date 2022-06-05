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
    public partial class PrincipalMesero : Form
    {
        string codigo_mesero;
        public PrincipalMesero(string nombre, string text)
        {
            InitializeComponent();
            lblAdministradorNombre.Text = nombre;
            codigo_mesero = text;
        }

        public PrincipalMesero()
        {
        }

        private void BtnCerrarSesion_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnModificar_Click(object sender, EventArgs e)
        {
            if(panelModificar.Visible == true)
            {
                panelModificar.Visible = false;
            }
            else
            {
                panelModificar.Visible = true;
            }
            btnModificar.Location = new Point(3, 5);
            panelModificar.Location = new Point(3,47);
            btnConsultaIndividual.Location = new Point(3, 89);
            btnConsultaGeneral.Location = new Point(3, 131);
            panelConsultasIndividuales.Hide();
            panelConsultasGenerales.Hide();
            if (panelModificar.Visible == false)
            {
                btnModificar.Location = new Point(3, 5);
                btnConsultaIndividual.Location = new Point(3, 47);
                btnConsultaGeneral.Location = new Point(3, 89);
            }
        }

        private void PrincipalMesero_Load(object sender, EventArgs e)
        {
            btnModificar.Location = new Point(3, 5);
            btnConsultaIndividual.Location = new Point(3, 47);
            btnConsultaGeneral.Location = new Point(3, 89);
            panelConsultasIndividuales.Hide();
            panelConsultasGenerales.Hide();
            panelModificar.Hide();
        }

        private void btnAlimentoCG_Click(object sender, EventArgs e)
        {
            btnModificar.Location = new Point(3, 5);
            btnConsultaIndividual.Location = new Point(3, 47);
            btnConsultaGeneral.Location = new Point(3, 89);
            panelConsultasIndividuales.Hide();
            panelConsultasGenerales.Hide();
            panelModificar.Hide();
            General_Alimento gA = new General_Alimento();
            this.Hide();
            gA.ShowDialog();
            this.Show();
        }

        private void btnConsultaIndividual_Click(object sender, EventArgs e)
        {
            if (panelConsultasIndividuales.Visible == true)
            {
                panelConsultasIndividuales.Visible = false;
            }
            else
            {
                panelConsultasIndividuales.Visible = true;
            }
            btnModificar.Location = new Point(3, 5);
            btnConsultaIndividual.Location = new Point(3, 47);
            panelConsultasIndividuales.Location = new Point(3, 87);
            btnConsultaGeneral.Location = new Point(3, 200);
            panelModificar.Hide();
            panelConsultasGenerales.Hide();
            if (panelConsultasIndividuales.Visible == false)
            {
                btnModificar.Location = new Point(3, 5);
                btnConsultaIndividual.Location = new Point(3, 47);
                btnConsultaGeneral.Location = new Point(3, 89);
            }
        }

        private void btnConsultaGeneral_Click(object sender, EventArgs e)
        {
            if (panelConsultasGenerales.Visible == true)
            {
                panelConsultasGenerales.Visible = false;
            }
            else
            {
                panelConsultasGenerales.Visible = true;
            }
            btnModificar.Location = new Point(3, 5);
            btnConsultaIndividual.Location = new Point(3, 47);
            btnConsultaGeneral.Location = new Point(3, 89);
            panelConsultasGenerales.Location = new Point(3, 131);
            panelModificar.Hide();
            panelConsultasIndividuales.Hide();
            if (panelConsultasGenerales.Visible == false)
            {
                btnModificar.Location = new Point(3, 5);
                btnConsultaIndividual.Location = new Point(3, 47);
                btnConsultaGeneral.Location = new Point(3, 89);
            }
        }

        private void BtnGenerarPedido_Click(object sender, EventArgs e)
        {
            btnModificar.Location = new Point(3, 5);
            btnConsultaIndividual.Location = new Point(3, 47);
            btnConsultaGeneral.Location = new Point(3, 89);
            panelConsultasIndividuales.Hide();
            panelConsultasGenerales.Hide();
            panelModificar.Hide();
            Cliente_Existe c = new Cliente_Existe(codigo_mesero.ToString());
            this.Hide();
            c.ShowDialog();
            this.Show();
        }

        private void BtnGenerarCuenta_Click(object sender, EventArgs e)
        {
            btnModificar.Location = new Point(3, 5);
            btnConsultaIndividual.Location = new Point(3, 47);
            btnConsultaGeneral.Location = new Point(3, 89);
            panelConsultasIndividuales.Hide();
            panelConsultasGenerales.Hide();
            panelModificar.Hide();
            Generar_Cuenta gc = new Generar_Cuenta();
            this.Hide();
            gc.ShowDialog();
            this.Show();
        }

        private void BtnClienteModificar_Click(object sender, EventArgs e)
        {
            btnModificar.Location = new Point(3, 5);
            btnConsultaIndividual.Location = new Point(3, 47);
            btnConsultaGeneral.Location = new Point(3, 89);
            panelConsultasIndividuales.Hide();
            panelConsultasGenerales.Hide();
            panelModificar.Hide();
            Update_Cliente uC = new Update_Cliente();
            this.Hide();
            uC.ShowDialog();
            this.Show();
        }

        private void BtnClienteCI_Click(object sender, EventArgs e)
        {
            btnModificar.Location = new Point(3, 5);
            btnConsultaIndividual.Location = new Point(3, 47);
            btnConsultaGeneral.Location = new Point(3, 89);
            panelConsultasIndividuales.Hide();
            panelConsultasGenerales.Hide();
            panelModificar.Hide();
            Individual_Cliente iC = new Individual_Cliente();
            this.Hide();
            iC.ShowDialog();
            this.Show();
        }

        private void BtnAlimentoCI_Click(object sender, EventArgs e)
        {
            btnModificar.Location = new Point(3, 5);
            btnConsultaIndividual.Location = new Point(3, 47);
            btnConsultaGeneral.Location = new Point(3, 89);
            panelConsultasIndividuales.Hide();
            panelConsultasGenerales.Hide();
            panelModificar.Hide();
            Individual_Alimento iA = new Individual_Alimento();
            this.Hide();
            iA.ShowDialog();
            this.Show();
        }

        private void BtnPedidoCI_Click(object sender, EventArgs e)
        {
            btnModificar.Location = new Point(3, 5);
            btnConsultaIndividual.Location = new Point(3, 47);
            btnConsultaGeneral.Location = new Point(3, 89);
            panelConsultasIndividuales.Hide();
            panelConsultasGenerales.Hide();
            panelModificar.Hide();
            Individual_Pedidos ip = new Individual_Pedidos();
            this.Hide();
            ip.ShowDialog();
            this.Show();
        }

        private void BtnClienteCG_Click(object sender, EventArgs e)
        {
            btnModificar.Location = new Point(3, 5);
            btnConsultaIndividual.Location = new Point(3, 47);
            btnConsultaGeneral.Location = new Point(3, 89);
            panelConsultasIndividuales.Hide();
            panelConsultasGenerales.Hide();
            panelModificar.Hide();
            General_Cliente gC = new General_Cliente();
            this.Hide();
            gC.ShowDialog();
            this.Show();
        }

        private void BtnPedidoCG_Click(object sender, EventArgs e)
        {
            btnModificar.Location = new Point(3, 5);
            btnConsultaIndividual.Location = new Point(3, 47);
            btnConsultaGeneral.Location = new Point(3, 89);
            panelConsultasIndividuales.Hide();
            panelConsultasGenerales.Hide();
            panelModificar.Hide();
            General_Pedidos gp = new General_Pedidos();
            this.Hide();
            gp.ShowDialog();
            this.Show();
        }
    }
}
