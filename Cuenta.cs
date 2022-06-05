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
    class Cuenta
    {
        public int cantidad;
        public string nombre_A;
        public double precio;

        public Cuenta() { }

        public Cuenta(int c, string n, double p)
        {
            this.cantidad = c;
            this.nombre_A = n;
            this.precio = p;
        }
    }
}
