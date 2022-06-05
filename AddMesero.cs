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

namespace Restaurante
{
    class AddMesero
    {
        public string CODIGO { get; set; }
        public string PASSWORD { get; set; }
        public string TIPO { get; set; }
        public string NOMBRE { get; set; }
        public string APELLIDO { get; set; }
        public string DIRECCION { get; set; }
        public string TELEFONO { get; set; }
        public string ESTADO { get; set; }

        public AddMesero() { }

        public AddMesero(string m_codigo, string m_password, string m_tipo, string m_nombre, string m_apellido, string m_direccion, string m_telefono, string m_estado)

        {
            this.CODIGO = m_codigo;
            this.PASSWORD = m_password;
            this.TIPO = m_tipo;
            this.NOMBRE = m_nombre;
            this.APELLIDO = m_apellido;
            this.DIRECCION = m_direccion;
            this.TELEFONO = m_telefono;
            this.ESTADO = m_estado;
        }
    }
}
