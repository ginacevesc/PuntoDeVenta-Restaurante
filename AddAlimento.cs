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
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Restaurante
{
    class AddAlimento
    {
        public string CODIGO { get; set; }
        public string NOMBRE { get; set; }
        public double PRECIO { get; set; }
        public string DESCRIPCION { get; set; }
        public string ESTADO { get; set; }

        public AddAlimento() { }

        public AddAlimento (string a_codigo, string a_nombre, double a_precio, string a_descripcion, string a_estado)
        {
            this.CODIGO = a_codigo;
            this.NOMBRE = a_nombre;
            this.PRECIO = a_precio;
            this.DESCRIPCION = a_descripcion;
            this.ESTADO = a_estado;
        }
    }
}
