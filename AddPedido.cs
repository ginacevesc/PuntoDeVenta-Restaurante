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
    class AddPedido
    {
        public int ORDEN;
        public int CLIENTE;
        public int MESA;
        public int MESERO;
        public int ALIMENTO;
        public int CANTIDAD;

        public AddPedido() { }
        public AddPedido(int num_orden, int id_cliente, int id_mesa, int id_mesero, int id_alimento, int cantidad)
        {
            this.ORDEN = num_orden;
            this.CLIENTE = id_cliente;
            this.MESA = id_mesa;
            this.MESERO = id_mesero;
            this.ALIMENTO = id_alimento;
            this.CANTIDAD = cantidad;
        }
    }
}
