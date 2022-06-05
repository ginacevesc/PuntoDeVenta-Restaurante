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
    class AddMesa
    {
        public int id_meseroMesa { get; set; }
        public string ubicacionMesa { get; set; }
        public int estadoMesa { get; set; }

        public AddMesa() { }

        public AddMesa(int id_m, string u_m, int e_m)
        {
            this.id_meseroMesa = id_m;
            this.ubicacionMesa = u_m;
            this.estadoMesa = e_m;
        }
    }
}
