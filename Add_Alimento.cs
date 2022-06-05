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
    public partial class Add_Alimento : Form
    {
        public Add_Alimento()
        {
            InitializeComponent();
        }

        private void BtnCerrarSesion_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnAnadir_Click(object sender, EventArgs e)
        {
            if (txtNombre.Text.Length == 0 || txtPrecio.Text.Length == 0 || txtEstado.Text.Length == 0)
            {
                MessageBox.Show("No se han llenado uno o más campos obligatorios.");
            }
            else
            {
                AddAlimento a = new AddAlimento();
                a.CODIGO = Funciones.codigoAlimento().ToString();
                a.NOMBRE = txtNombre.Text;
                a.PRECIO = Convert.ToDouble(txtPrecio.Text.ToString());
                a.DESCRIPCION = txtDescripcion.Text;
                a.ESTADO = txtEstado.Text;
                int retorno = Funciones.agregarAlimento(a);
                if (retorno > 0)
                {
                    this.Close();
                    MessageBox.Show("Alimento agregado correctamente.");
                }
                else
                {
                    MessageBox.Show("Ocurrió un error al agregar el alimento. Inténtelo nuevamente");
                }
            }
        }

        private void Add_Alimento_Load(object sender, EventArgs e)
        {

        }
    }
}
