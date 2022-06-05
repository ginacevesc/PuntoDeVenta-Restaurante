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
    public partial class General_Alimento : Form
    {
        public General_Alimento()
        {
            InitializeComponent();
            dgvAlimentosGeneral.DataSource = Funciones.consultasGeneralesAlimentos();
        }

        private void BtnCerrarSesion_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LblAgregarMesa_Click(object sender, EventArgs e)
        {

        }

        private void General_Alimento_Load(object sender, EventArgs e)
        {

        }
    }
}
