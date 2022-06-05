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
using Restaurante.MySQL;
using System.Security.Cryptography;

namespace Restaurante
{
    class Funciones
    {
        public static int agregarMesero(AddMesero add)
        {
            int retorno = 0;
            MySqlCommand comando = new MySqlCommand(string.Format("INSERT INTO mesero (codigo_mesero, password_mesero, tipo_mesero, nombre_mesero, apellido_mesero, direccion_mesero, telefono_mesero, estado_mesero) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}')", add.CODIGO, add.PASSWORD, add.TIPO, add.NOMBRE, add.APELLIDO, add.DIRECCION, add.TELEFONO, add.ESTADO), conexion.obtenerConexion());
            retorno = comando.ExecuteNonQuery();
            return retorno;
        }
        public static int agregarCliente(AddCliente add)
        {
            int retorno = 0;
            MySqlCommand comando = new MySqlCommand(string.Format("INSERT INTO cliente (codigo_cliente, nombre_cliente, apellido_cliente, telefono_cliente) VALUES ('{0}', '{1}', '{2}', '{3}')", add.CODIGO, add.NOMBRE, add.APELLIDO, add.TELEFONO), conexion.obtenerConexion());
            retorno = comando.ExecuteNonQuery();
            return retorno;
        }
        public static int codigoMesero()
        {
            MySqlCommand comando = new MySqlCommand(string.Format("select * from mesero"), conexion.obtenerConexion());
            MySqlDataReader reader = comando.ExecuteReader();
            int id = 0;
            while (reader.Read())
            {
                id = reader.GetInt32(0);
            }
            id += 1;
            return id;
        }

        public static int agregarAlimento(AddAlimento alimento)
        {
            int retorno = 0;
            MySqlCommand comando = new MySqlCommand(string.Format("Insert into alimento (codigo_alimento, nombre_alimento, precio_alimento, descripcion_alimento, estado_alimento) values ('{0}', '{1}', '{2}', '{3}', '{4}')", alimento.CODIGO, alimento.NOMBRE, alimento.PRECIO, alimento.DESCRIPCION, alimento.ESTADO), conexion.obtenerConexion());
            retorno = comando.ExecuteNonQuery();
            return retorno;
        }

        public static int codigoAlimento()
        {
            MySqlCommand comando = new MySqlCommand(string.Format("select * from alimento"), conexion.obtenerConexion());
            MySqlDataReader reader = comando.ExecuteReader();
            int id = 0;
            while (reader.Read())
            {
                id = reader.GetInt32(0);
            }
            id += 1;
            return id;
        }

        public static List<AddMesero> consultasGeneralesMeseros()
        {
            List<AddMesero> lista = new List<AddMesero>();
            MySqlCommand comando = new MySqlCommand(string.Format("SELECT * FROM mesero"),conexion.obtenerConexion());
            MySqlDataReader reader = comando.ExecuteReader();

            while (reader.Read())
            {
                AddMesero mesero = new AddMesero();
                mesero.CODIGO = reader.GetString(1);
                mesero.PASSWORD = reader.GetString(2);
                mesero.TIPO = reader.GetString(3);
                mesero.NOMBRE = reader.GetString(4);
                mesero.APELLIDO = reader.GetString(5);
                mesero.DIRECCION = reader.GetString(6);
                mesero.TELEFONO = reader.GetString(7);
                if (reader.GetString(8).ToString() == "1")
                    mesero.ESTADO = "activo";
                else
                    mesero.ESTADO = "inactivo";
                lista.Add(mesero);
            }

            return lista;
        }
        public static List<AddPedido> consultasGeneralesPedidos()
        {
            List<AddPedido> lista = new List<AddPedido>();
            MySqlCommand comando = new MySqlCommand(string.Format("select * from pedido"), conexion.obtenerConexion());
            MySqlDataReader reader = comando.ExecuteReader();

            while (reader.Read())
            {
                AddPedido p = new AddPedido();
                p.ORDEN = reader.GetInt32(1);
                p.CLIENTE = reader.GetInt32(2);
                p.MESA = reader.GetInt32(3);
                p.MESERO = reader.GetInt32(4);
                p.ALIMENTO = reader.GetInt32(5);
                p.CANTIDAD = reader.GetInt32(6);
                lista.Add(p);
            }

            return lista;
        }
        public static List<Cuenta> Cuenta()
        {
            List<Cuenta> lista = new List<Cuenta>();
            MySqlCommand comando = new MySqlCommand(string.Format("Select pedido.cantidad_platillo, alimento.nombre_alimento, alimento.precio_alimento FROM pedido INNER JOIN alimento ON pedido.id_alimento = alimento.id_alimento WHERE pedido.num_orden = '{0}'", 20), conexion.obtenerConexion());
            MySqlDataReader reader = comando.ExecuteReader();

            while (reader.Read())
            {
                Cuenta c = new Cuenta();
                c.cantidad = reader.GetInt32(0);
                c.nombre_A = reader.GetString(1);
                c.precio = reader.GetDouble(2);
                lista.Add(c);
            }

            return lista;
        }

        public static List<AddPedido> MostrarPedido()
        {
            List<AddPedido> lista = new List<AddPedido>();
            MySqlCommand comando = new MySqlCommand(string.Format("select * from pedido"), conexion.obtenerConexion());
            MySqlDataReader reader = comando.ExecuteReader();

            while (reader.Read())
            {
                AddPedido pedido = new AddPedido();
                pedido.ORDEN = reader.GetInt32(1);
                pedido.CLIENTE = reader.GetInt32(2);
                pedido.MESA = reader.GetInt32(3);
                pedido.MESERO = reader.GetInt32(4);
                pedido.ALIMENTO = reader.GetInt32(5);
                pedido.CANTIDAD = reader.GetInt32(6);
                lista.Add(pedido);
            }
            return lista;
        }

        public static List<AddAlimento> consultasGeneralesAlimentos()
        {
            List<AddAlimento> lista = new List<AddAlimento>();
            MySqlCommand comando = new MySqlCommand(string.Format("SELECT * FROM alimento"), conexion.obtenerConexion());
            MySqlDataReader reader = comando.ExecuteReader();

            while (reader.Read())
            {
                AddAlimento alimento = new AddAlimento();
                alimento.CODIGO = reader.GetString(1);
                alimento.NOMBRE = reader.GetString(2);
                alimento.PRECIO = reader.GetDouble(3);
                alimento.DESCRIPCION = reader.GetString(4);
                if(reader.GetInt32(5) == 1)
                    alimento.ESTADO = "activo";
                else
                    alimento.ESTADO = "inactivo";
                lista.Add(alimento);
            }

            return lista;
        }

        public static List<AddCliente> consultasGeneralesClientes()
        {
            List<AddCliente> lista = new List<AddCliente>();
            MySqlCommand comando = new MySqlCommand(string.Format("SELECT * FROM Cliente"), conexion.obtenerConexion());
            MySqlDataReader reader = comando.ExecuteReader();
            while (reader.Read())
            {
                AddCliente cliente = new AddCliente();
                cliente.CODIGO = reader.GetString(1);
                cliente.NOMBRE = reader.GetString(2);
                cliente.APELLIDO = reader.GetString(3);
                cliente.TELEFONO = reader.GetString(4);
                lista.Add(cliente);
            }

            return lista;
        }

        public static List<AddMesero> ConsultasIndividualesMeseros(string m_codigo)
        {
            List<AddMesero> lista = new List<AddMesero>();
            MySqlCommand comando = new MySqlCommand(String.Format("SELECT * FROM mesero WHERE codigo_mesero = '{0}'", m_codigo), conexion.obtenerConexion());
            MySqlDataReader reader = comando.ExecuteReader();
            while (reader.Read())
            {
                AddMesero mesero = new AddMesero();
                mesero.CODIGO = reader.GetString(1);
                mesero.PASSWORD = reader.GetString(2);
                mesero.TIPO = reader.GetString(3);
                mesero.NOMBRE = reader.GetString(4);
                mesero.APELLIDO = reader.GetString(5);
                mesero.DIRECCION = reader.GetString(6);
                mesero.TELEFONO = reader.GetString(7);
                if (reader.GetString(8).ToString() == "1")
                    mesero.ESTADO = "activo";
                else
                    mesero.ESTADO = "inactivo";
                lista.Add(mesero);
            }
            return lista;
        }

        public static List<AddCliente> ConsultasIndividualesClientes(string c_codigo)
        {
            List<AddCliente> lista = new List<AddCliente>();
            MySqlCommand comando = new MySqlCommand(String.Format("SELECT codigo_cliente,nombre_cliente,apellido_cliente,telefono_cliente FROM cliente WHERE codigo_cliente = '{0}'", c_codigo), conexion.obtenerConexion());
            MySqlDataReader reader = comando.ExecuteReader();
            while (reader.Read())
            {
                AddCliente cliente = new AddCliente();
                cliente.CODIGO = reader.GetString(0);
                cliente.NOMBRE = reader.GetString(1);
                cliente.APELLIDO = reader.GetString(2);
                cliente.TELEFONO = reader.GetString(3);
                lista.Add(cliente);
            }
       
            return lista;
        }

        public static List<AddAlimento> ConsultasIndividualesAlimentos(string m_codigo)
        {
            List<AddAlimento> lista = new List<AddAlimento>();
            MySqlCommand comando = new MySqlCommand(String.Format("SELECT * FROM alimento WHERE codigo_alimento = '{0}'", m_codigo), conexion.obtenerConexion());
            MySqlDataReader reader = comando.ExecuteReader();

            while (reader.Read())
            {
                AddAlimento alimento = new AddAlimento();
                alimento.CODIGO = reader.GetString(1);
                alimento.NOMBRE = reader.GetString(2);
                alimento.PRECIO = reader.GetDouble(3);
                alimento.DESCRIPCION = reader.GetString(4);
                if (reader.GetInt32(5) == 1)
                    alimento.ESTADO = "activo";
                else
                    alimento.ESTADO = "inactivo";
                lista.Add(alimento);
            }
            return lista;
        }
        public static int actualizarMesero(AddMesero add, string codigo_anterior)
        {
            int retorno = 0;
            MySqlCommand comando = new MySqlCommand(string.Format("UPDATE mesero SET codigo_mesero = '{0}', password_mesero = '{1}', " +
            "tipo_mesero = '{2}', nombre_mesero = '{3}', apellido_mesero = '{4}', direccion_mesero = '{5}', " +
            "telefono_mesero = '{6}', estado_mesero = '{7}' WHERE codigo_mesero = '{8}'", add.CODIGO, add.PASSWORD, add.TIPO, add.NOMBRE, add.APELLIDO,
            add.DIRECCION, add.TELEFONO, Convert.ToInt32(add.ESTADO), codigo_anterior), conexion.obtenerConexion());
            retorno = comando.ExecuteNonQuery();
            return retorno;
        }

        public static int actualizarAlimento(AddAlimento add, string codigo_anterior)
        {
            int retorno = 0;
            MySqlCommand comando = new MySqlCommand(string.Format("Update alimento set codigo_alimento = '{0}', nombre_alimento = '{1}', " +
            "precio_alimento = '{2}', descripcion_alimento = '{3}', estado_alimento = '{4}' where codigo_alimento = '{5}'", add.CODIGO, add.NOMBRE, 
            add.PRECIO, add.DESCRIPCION, add.ESTADO, codigo_anterior), conexion.obtenerConexion());
            retorno = comando.ExecuteNonQuery();
            return retorno;
        }
        public static int actualizarPedido1(int alimento, int cantidad, int id_pedido)
        {
            int retorno = 0;
            MySqlCommand comando = new MySqlCommand(string.Format("Update from pedido set id_alimento = '{0}', cantidad_platillo = '{1}' where id_pedido = '{2}'", alimento , cantidad, id_pedido), conexion.obtenerConexion());
            retorno = comando.ExecuteNonQuery();
            return retorno;
        }

        public static int eliminarMesero(AddMesero add, int estado)
        {
            int retorno = 0;
            MySqlCommand comando = new MySqlCommand(string.Format("UPDATE mesero SET estado_mesero = '{0}' WHERE codigo_mesero = '{1}'", estado, add.CODIGO), conexion.obtenerConexion());
            retorno = comando.ExecuteNonQuery();
            return retorno;
        }
        public static int eliminarPedido(string codigo)
        {
            int retorno = 0;
            MySqlCommand comando = new MySqlCommand(string.Format("Delete from pedido where num_orden = '{0}'", codigo), conexion.obtenerConexion());
            retorno = comando.ExecuteNonQuery();
            return retorno;
        }
        public static int LiberaMesa(string codigo)
        {
            int retorno = 0;
            MySqlCommand comando = new MySqlCommand(string.Format("Update mesa set estado_mesa = '{0}' where codigo_mesa = '{1}'", 1, codigo), conexion.obtenerConexion());
            retorno = comando.ExecuteNonQuery();
            return retorno;
        }
        public static int NoLiberaMesa(string codigo)
        {
            int retorno = 0;
            MySqlCommand comando = new MySqlCommand(string.Format("Update mesa set estado_mesa = '{0}' where codigo_mesa = '{1}'", 0, codigo), conexion.obtenerConexion());
            retorno = comando.ExecuteNonQuery();
            return retorno;
        }

        public static int eliminarAlimento(AddAlimento add, int estado)
        {
            int retorno = 0;
            MySqlCommand comando = new MySqlCommand(string.Format("Update alimento set estado_alimento = '{0}' where codigo_alimento = '{1}'", estado, add.CODIGO), conexion.obtenerConexion());
            retorno = comando.ExecuteNonQuery();
            return retorno;
        }

        public static int actualizarCliente(AddCliente add, string codigo)
        {
            int retorno = 0;
            MySqlCommand comando = new MySqlCommand(string.Format("Update cliente set codigo_cliente= '{0}', nombre_cliente = '{1}', " +
                "apellido_cliente = '{2}', telefono_cliente = '{3}' where codigo_cliente = '{4}'", add.CODIGO, add.NOMBRE, add.APELLIDO,
            add.TELEFONO, codigo), conexion.obtenerConexion());
            retorno = comando.ExecuteNonQuery();
            return retorno;
        }

        public static int actualizarMesa(AddMesa add, string codigo)
        {
            int retorno = 0;
            MySqlCommand comando = new MySqlCommand(string.Format("Update mesa set id_mesero = '{0}', " +
                "ubicacion_mesa = '{1}', estado_mesa = '{2}' where codigo_mesa = '{3}'", add.id_meseroMesa, add.ubicacionMesa,
            add.estadoMesa, codigo), conexion.obtenerConexion());
            retorno = comando.ExecuteNonQuery();
            return retorno;
        }

        public static int cambiarEstadoMesa(int estado, string codigo_mesa)
        {
            int retorno = 0;
            MySqlCommand comando = new MySqlCommand(string.Format("Update mesa set estado_mesa = '{0}' where codigo_mesa = '{1}'", estado, codigo_mesa), conexion.obtenerConexion());
            retorno = comando.ExecuteNonQuery();
            return retorno;
        }

        public static int cambiarEstadoPedido(int estado, string no_orden)
        {
            int retorno = 0;
            MySqlCommand comando = new MySqlCommand(string.Format("Update pedido set estado_pedido = '{0}' where num_orden = '{1}'", estado, no_orden), conexion.obtenerConexion());
            retorno = comando.ExecuteNonQuery();
            return retorno;
        }
    }
}
