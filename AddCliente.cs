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
    class AddCliente
    {
        public string CODIGO { get; set; }
        public string NOMBRE { get; set; }
        public string APELLIDO { get; set; }
        public string TELEFONO { get; set; }

        public AddCliente() { }

        public AddCliente(string c_codigo, string c_nombre, string c_apellido, string c_telefono)
        {
            this.CODIGO = c_codigo;
            this.NOMBRE = c_nombre;
            this.APELLIDO = c_apellido;
            this.TELEFONO = c_telefono;
        }
    }
}
