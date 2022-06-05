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
    public partial class PrincipalAdmi : Form
    {
        string codigo_mesero;
        public PrincipalAdmi(string nombre, string text)
        {
            InitializeComponent();
            lblAdministradorNombre.Text = nombre;
            codigo_mesero = text;
        }

        public PrincipalAdmi()
        {
        }

        private void PictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void PrincipalAdmi_Load(object sender, EventArgs e)
        {
            btnAnadir.Location = new Point(3, 5);
            btnModificar.Location = new Point(3, 47);
            btnConsultaIndividual.Location = new Point(3, 89);
            btnConsultaGeneral.Location = new Point(3, 131);
            btnDelete.Location = new Point(3, 173);
            panelConsultasIndividuales.Hide();
            panelConsultasGenerales.Hide();
            panelElimina.Hide();
            panelModificar.Hide();
            panelAdd.Hide();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Button1_Click_1(object sender, EventArgs e)
        {
            if (panelAdd.Visible == true)
            {
                panelAdd.Visible = false;
            }
            else
            {
                panelAdd.Visible = true;
            }
            btnAnadir.Location = new Point(3, 5);
            panelAdd.Location = new Point(3, 91);
            btnModificar.Location = new Point(3, 131);
            btnConsultaIndividual.Location = new Point(3, 173);
            btnConsultaGeneral.Location = new Point(3, 215);
            btnDelete.Location = new Point(3, 257);
            panelConsultasIndividuales.Hide();
            panelConsultasGenerales.Hide();
            panelElimina.Hide();
            panelModificar.Hide();
            if (panelAdd.Visible == false)
            {
                btnAnadir.Location = new Point(3, 5);
                btnModificar.Location = new Point(3, 47);
                btnConsultaIndividual.Location = new Point(3, 89);
                btnConsultaGeneral.Location = new Point(3, 131);
                btnDelete.Location = new Point(3, 173);
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Button2");
            if (panelModificar.Visible == true)
            {
                panelModificar.Visible = false;
            }
            else
            {
                panelModificar.Visible = true;
            }
            btnModificar.Location = new Point(3, 47);
            panelModificar.Location = new Point(3, 133);
            btnConsultaIndividual.Location = new Point(3, 257);
            btnConsultaGeneral.Location = new Point(3, 299);
            btnDelete.Location = new Point(3, 341);
            panelConsultasIndividuales.Hide();
            panelConsultasGenerales.Hide();
            panelElimina.Hide();
            panelAdd.Hide();
            if (panelModificar.Visible == false)
            {
                btnAnadir.Location = new Point(3, 5);
                btnModificar.Location = new Point(3, 47);
                btnConsultaIndividual.Location = new Point(3, 89);
                btnConsultaGeneral.Location = new Point(3, 131);
                btnDelete.Location = new Point(3, 173);
            }
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Button3");
            if (panelConsultasIndividuales.Visible == true)
            {
                panelConsultasIndividuales.Visible = false;
            }
            else
            {
                panelConsultasIndividuales.Visible = true;
            }
            btnConsultaIndividual.Location = new Point(3, 89);
            panelConsultasIndividuales.Location = new Point(3, 175);
            btnConsultaGeneral.Location = new Point(3, 299);
            btnDelete.Location = new Point(3, 341);
            panelConsultasGenerales.Hide();
            panelElimina.Hide();
            panelModificar.Hide();
            panelAdd.Hide();
            if (panelConsultasIndividuales.Visible == false)
            {
                btnAnadir.Location = new Point(3, 5);
                btnModificar.Location = new Point(3, 47);
                btnConsultaIndividual.Location = new Point(3, 89);
                btnConsultaGeneral.Location = new Point(3, 131);
                btnDelete.Location = new Point(3, 173);
            }
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Button4");
            if (panelConsultasGenerales.Visible == true)
            {
                panelConsultasGenerales.Visible = false;
            }
            else
            {
                panelConsultasGenerales.Visible = true;
            }
            btnConsultaGeneral.Location = new Point(3, 131);
            panelConsultasGenerales.Location = new Point(3, 217);
            btnDelete.Location = new Point(3, 341);
            panelConsultasIndividuales.Hide();
            panelElimina.Hide();
            panelModificar.Hide();
            panelAdd.Hide();
            if (panelConsultasGenerales.Visible == false)
            {
                btnAnadir.Location = new Point(3, 5);
                btnModificar.Location = new Point(3, 47);
                btnConsultaIndividual.Location = new Point(3, 89);
                btnConsultaGeneral.Location = new Point(3, 131);
                btnDelete.Location = new Point(3, 173);
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (panelElimina.Visible == true)
            {
                panelElimina.Visible = false;
            }
            else
            {
                panelElimina.Visible = true;
            }
            btnDelete.Location = new Point(3, 173);
            panelElimina.Location = new Point(3, 259);
            panelConsultasIndividuales.Hide();
            panelConsultasGenerales.Hide();
            panelModificar.Hide();
            panelAdd.Hide();
            if (panelElimina.Visible == false)
            {
                btnAnadir.Location = new Point(3, 5);
                btnModificar.Location = new Point(3, 47);
                btnConsultaIndividual.Location = new Point(3, 89);
                btnConsultaGeneral.Location = new Point(3, 131);
                btnDelete.Location = new Point(3, 173);
            }
        }

        private void BtnAlimentoCI_Click(object sender, EventArgs e)
        {
            btnAnadir.Location = new Point(3, 5);
            btnModificar.Location = new Point(3, 47);
            btnConsultaIndividual.Location = new Point(3, 89);
            btnConsultaGeneral.Location = new Point(3, 131);
            btnDelete.Location = new Point(3, 173);
            panelConsultasIndividuales.Hide();
            panelConsultasGenerales.Hide();
            panelElimina.Hide();
            panelModificar.Hide();
            panelAdd.Hide();
            Individual_Alimento iA = new Individual_Alimento();
            this.Hide();
            iA.ShowDialog();
            this.Show();
        }

        private void BtnClienteCI_Click(object sender, EventArgs e)
        {
            btnAnadir.Location = new Point(3, 5);
            btnModificar.Location = new Point(3, 47);
            btnConsultaIndividual.Location = new Point(3, 89);
            btnConsultaGeneral.Location = new Point(3, 131);
            btnDelete.Location = new Point(3, 173);
            panelConsultasIndividuales.Hide();
            panelConsultasGenerales.Hide();
            panelElimina.Hide();
            panelModificar.Hide();
            panelAdd.Hide();
            Individual_Cliente iC = new Individual_Cliente();
            this.Hide();
            iC.ShowDialog();
            this.Show();
        }

        private void BtnMeseroCI_Click(object sender, EventArgs e)
        {
            btnAnadir.Location = new Point(3, 5);
            btnModificar.Location = new Point(3, 47);
            btnConsultaIndividual.Location = new Point(3, 89);
            btnConsultaGeneral.Location = new Point(3, 131);
            btnDelete.Location = new Point(3, 173);
            panelConsultasIndividuales.Hide();
            panelConsultasGenerales.Hide();
            panelElimina.Hide();
            panelModificar.Hide();
            panelAdd.Hide();
            Individual_Mesero iM = new Individual_Mesero();
            this.Hide();
            iM.ShowDialog();
            this.Show();
        }

        private void BtnPedidoCI_Click(object sender, EventArgs e)
        {
            btnAnadir.Location = new Point(3, 5);
            btnModificar.Location = new Point(3, 47);
            btnConsultaIndividual.Location = new Point(3, 89);
            btnConsultaGeneral.Location = new Point(3, 131);
            btnDelete.Location = new Point(3, 173);
            panelConsultasIndividuales.Hide();
            panelConsultasGenerales.Hide();
            panelElimina.Hide();
            panelModificar.Hide();
            panelAdd.Hide();
            Individual_Pedidos ip = new Individual_Pedidos();
            this.Hide();
            ip.ShowDialog();
            this.Show();
        }

        private void BtnPedidoCG_Click(object sender, EventArgs e)
        {
            btnAnadir.Location = new Point(3, 5);
            btnModificar.Location = new Point(3, 47);
            btnConsultaIndividual.Location = new Point(3, 89);
            btnConsultaGeneral.Location = new Point(3, 131);
            btnDelete.Location = new Point(3, 173);
            panelConsultasIndividuales.Hide();
            panelConsultasGenerales.Hide();
            panelElimina.Hide();
            panelModificar.Hide();
            panelAdd.Hide();
            General_Pedidos gp = new General_Pedidos();
            this.Hide();
            gp.ShowDialog();
            this.Show();
        }

        private void BtnMeseroCG_Click(object sender, EventArgs e)
        {
            btnAnadir.Location = new Point(3, 5);
            btnModificar.Location = new Point(3, 47);
            btnConsultaIndividual.Location = new Point(3, 89);
            btnConsultaGeneral.Location = new Point(3, 131);
            btnDelete.Location = new Point(3, 173);
            panelConsultasIndividuales.Hide();
            panelConsultasGenerales.Hide();
            panelElimina.Hide();
            panelModificar.Hide();
            panelAdd.Hide();
            General_Mesero gM = new General_Mesero();
            this.Hide();
            gM.ShowDialog();
            this.Show();
        }

        private void BtnClienteCG_Click(object sender, EventArgs e)
        {
            btnAnadir.Location = new Point(3, 5);
            btnModificar.Location = new Point(3, 47);
            btnConsultaIndividual.Location = new Point(3, 89);
            btnConsultaGeneral.Location = new Point(3, 131);
            btnDelete.Location = new Point(3, 173);
            panelConsultasIndividuales.Hide();
            panelConsultasGenerales.Hide();
            panelElimina.Hide();
            panelModificar.Hide();
            panelAdd.Hide();
            General_Cliente gC = new General_Cliente();
            this.Hide();
            gC.ShowDialog();
            this.Show();
        }

        private void BtnAlimentoCG_Click(object sender, EventArgs e)
        {
            btnAnadir.Location = new Point(3, 5);
            btnModificar.Location = new Point(3, 47);
            btnConsultaIndividual.Location = new Point(3, 89);
            btnConsultaGeneral.Location = new Point(3, 131);
            btnDelete.Location = new Point(3, 173);
            panelConsultasIndividuales.Hide();
            panelConsultasGenerales.Hide();
            panelElimina.Hide();
            panelModificar.Hide();
            panelAdd.Hide();
            General_Alimento gA = new General_Alimento();
            this.Hide();
            gA.ShowDialog();
            this.Show();
        }

        private void BtnPedidoElimina_Click(object sender, EventArgs e)
        {
            btnAnadir.Location = new Point(3, 5);
            btnModificar.Location = new Point(3, 47);
            btnConsultaIndividual.Location = new Point(3, 89);
            btnConsultaGeneral.Location = new Point(3, 131);
            btnDelete.Location = new Point(3, 173);
            panelConsultasIndividuales.Hide();
            panelConsultasGenerales.Hide();
            panelElimina.Hide();
            panelModificar.Hide();
            panelAdd.Hide();
            Delete_Pedido dp = new Delete_Pedido();
            this.Hide();
            dp.ShowDialog();
            this.Show();
        }

        private void BtnMeseroElimina_Click(object sender, EventArgs e)
        {
            btnAnadir.Location = new Point(3, 5);
            btnModificar.Location = new Point(3, 47);
            btnConsultaIndividual.Location = new Point(3, 89);
            btnConsultaGeneral.Location = new Point(3, 131);
            btnDelete.Location = new Point(3, 173);
            panelConsultasIndividuales.Hide();
            panelConsultasGenerales.Hide();
            panelElimina.Hide();
            panelModificar.Hide();
            panelAdd.Hide();
            Delete_Mesero dM = new Delete_Mesero();
            this.Hide();
            dM.ShowDialog();
            this.Show();
        }

        private void BtnMesaElimina_Click(object sender, EventArgs e)
        {
            
        }

        private void BtnAlimentoElimina_Click(object sender, EventArgs e)
        {
            btnAnadir.Location = new Point(3, 5);
            btnModificar.Location = new Point(3, 47);
            btnConsultaIndividual.Location = new Point(3, 89);
            btnConsultaGeneral.Location = new Point(3, 131);
            btnDelete.Location = new Point(3, 173);
            panelConsultasIndividuales.Hide();
            panelConsultasGenerales.Hide();
            panelElimina.Hide();
            panelModificar.Hide();
            panelAdd.Hide();
            Delete_Alimento dA = new Delete_Alimento();
            this.Hide();
            dA.ShowDialog();
            this.Show();
        }

        private void BtnAlimentoModificar_Click(object sender, EventArgs e)
        {
            btnAnadir.Location = new Point(3, 5);
            btnModificar.Location = new Point(3, 47);
            btnConsultaIndividual.Location = new Point(3, 89);
            btnConsultaGeneral.Location = new Point(3, 131);
            btnDelete.Location = new Point(3, 173);
            panelConsultasIndividuales.Hide();
            panelConsultasGenerales.Hide();
            panelElimina.Hide();
            panelModificar.Hide();
            panelAdd.Hide();
            Update_Alimento uAlim = new Update_Alimento();
            this.Hide();
            uAlim.ShowDialog();
            this.Show();
        }

        private void BtnClienteModificar_Click(object sender, EventArgs e)
        {
            btnAnadir.Location = new Point(3, 5);
            btnModificar.Location = new Point(3, 47);
            btnConsultaIndividual.Location = new Point(3, 89);
            btnConsultaGeneral.Location = new Point(3, 131);
            btnDelete.Location = new Point(3, 173);
            panelConsultasIndividuales.Hide();
            panelConsultasGenerales.Hide();
            panelElimina.Hide();
            panelModificar.Hide();
            panelAdd.Hide();
            Update_Cliente uC = new Update_Cliente();
            this.Hide();
            uC.ShowDialog();
            this.Show();
        }

        private void BtnMesaModificar_Click(object sender, EventArgs e)
        {
            btnAnadir.Location = new Point(3, 5);
            btnModificar.Location = new Point(3, 47);
            btnConsultaIndividual.Location = new Point(3, 89);
            btnConsultaGeneral.Location = new Point(3, 131);
            btnDelete.Location = new Point(3, 173);
            panelConsultasIndividuales.Hide();
            panelConsultasGenerales.Hide();
            panelElimina.Hide();
            panelModificar.Hide();
            panelAdd.Hide();
            Update_Mesa uM = new Update_Mesa();
            this.Hide();
            uM.ShowDialog();
            this.Show();
        }

        private void BtnMeseroModificar_Click(object sender, EventArgs e)
        {
            btnAnadir.Location = new Point(3, 5);
            btnModificar.Location = new Point(3, 47);
            btnConsultaIndividual.Location = new Point(3, 89);
            btnConsultaGeneral.Location = new Point(3, 131);
            btnDelete.Location = new Point(3, 173);
            panelConsultasIndividuales.Hide();
            panelConsultasGenerales.Hide();
            panelElimina.Hide();
            panelModificar.Hide();
            panelAdd.Hide();
            Update_Mesero uMes = new Update_Mesero();
            this.Hide();
            uMes.ShowDialog();
            this.Show();
        }

        private void BtnPedidoModificar_Click(object sender, EventArgs e)
        {
            btnAnadir.Location = new Point(3, 5);
            btnModificar.Location = new Point(3, 47);
            btnConsultaIndividual.Location = new Point(3, 89);
            btnConsultaGeneral.Location = new Point(3, 131);
            btnDelete.Location = new Point(3, 173);
            panelConsultasIndividuales.Hide();
            panelConsultasGenerales.Hide();
            panelElimina.Hide();
            panelModificar.Hide();
            panelAdd.Hide();
// Update_Pedido uP = new Update_Pedido();
            this.Hide();
// uP.ShowDialog();
// uP.Show();
        }

        private void BtnAlimentoAdd_Click(object sender, EventArgs e)
        {
            btnAnadir.Location = new Point(3, 5);
            btnModificar.Location = new Point(3, 47);
            btnConsultaIndividual.Location = new Point(3, 89);
            btnConsultaGeneral.Location = new Point(3, 131);
            btnDelete.Location = new Point(3, 173);
            panelConsultasIndividuales.Hide();
            panelConsultasGenerales.Hide();
            panelElimina.Hide();
            panelModificar.Hide();
            panelAdd.Hide();
            Add_Alimento addA = new Add_Alimento();
            this.Hide();
            addA.ShowDialog();
            this.Show();
        }

        private void BtnMesaAdd_Click(object sender, EventArgs e)
        {
            btnAnadir.Location = new Point(3, 5);
            btnModificar.Location = new Point(3, 47);
            btnConsultaIndividual.Location = new Point(3, 89);
            btnConsultaGeneral.Location = new Point(3, 131);
            btnDelete.Location = new Point(3, 173);
            panelConsultasIndividuales.Hide();
            panelConsultasGenerales.Hide();
            panelElimina.Hide();
            panelModificar.Hide();
            panelAdd.Hide();
            Update_Alimento AddMesa = new Update_Alimento();
            this.Hide();
            AddMesa.ShowDialog();
            this.Show();
        }

        private void BtnMeseroAdd_Click(object sender, EventArgs e)
        {
            btnAnadir.Location = new Point(3, 5);
            btnModificar.Location = new Point(3, 47);
            btnConsultaIndividual.Location = new Point(3, 89);
            btnConsultaGeneral.Location = new Point(3, 131);
            btnDelete.Location = new Point(3, 173);
            panelConsultasIndividuales.Hide();
            panelConsultasGenerales.Hide();
            panelElimina.Hide();
            panelModificar.Hide();
            panelAdd.Hide();
            Add_Mesero AddM = new Add_Mesero();
            this.Hide();
            AddM.ShowDialog();
            this.Show();
        }

        private void BtnGenerarPedido_Click(object sender, EventArgs e)
        {
            btnAnadir.Location = new Point(3, 5);
            btnModificar.Location = new Point(3, 47);
            btnConsultaIndividual.Location = new Point(3, 89);
            btnConsultaGeneral.Location = new Point(3, 131);
            btnDelete.Location = new Point(3, 173);
            panelConsultasIndividuales.Hide();
            panelConsultasGenerales.Hide();
            panelElimina.Hide();
            panelModificar.Hide();
            panelAdd.Hide();
            Cliente_Existe c = new Cliente_Existe(codigo_mesero.ToString());
            this.Hide();
            c.ShowDialog();
            this.Show();        }

        private void BtnGenerarCuenta_Click(object sender, EventArgs e)
        {
            btnAnadir.Location = new Point(3, 5);
            btnModificar.Location = new Point(3, 47);
            btnConsultaIndividual.Location = new Point(3, 89);
            btnConsultaGeneral.Location = new Point(3, 131);
            btnDelete.Location = new Point(3, 173);
            panelConsultasIndividuales.Hide();
            panelConsultasGenerales.Hide();
            panelElimina.Hide();
            panelModificar.Hide();
            panelAdd.Hide();
            Generar_Cuenta gc = new Generar_Cuenta();
            this.Hide();
            gc.ShowDialog();
            this.Show();
            //MessageBox.Show("Cuenta");
        }
    }
}
