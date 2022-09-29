using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using System.Data;

namespace Data
{
    public class DProductos
    {
        public List<Productos> Listar(Productos producto)
        {
            SqlParameter[] parameters = null;
            string commandText = string.Empty;
            List<Productos> productos = null;

            try
            {
                commandText = "USP_GetProductosLab";
                parameters = new SqlParameter[1];
                parameters[0] = new SqlParameter("@idproducto", SqlDbType.Int);
                parameters[0].Value = producto.IdProducto;
                productos = new List<Productos>();

                //utilizamos using para crear un entorno de contexto
                //es decir las variables creadas allí no van a poder ser
                //usadas afuera

                using (SqlDataReader reader = SQLHelper.ExecuteReader(SQLHelper.Connection, commandText, CommandType.StoredProcedure, parameters))
                {
                    while (reader.Read())
                    {
                        productos.Add(new Productos
                        {
                            IdProducto = reader["IdProducto"] != null ? Convert.ToInt32(reader["IdProducto"]) : 0,
                            NombreProducto = reader["NombreProducto"] != null ? Convert.ToString(reader["NombreProducto"]) : string.Empty,
                            PrecioUnidad = reader["PrecioUnidad"] != null ? Convert.ToDouble(reader["PrecioUnidad"]) : 0,
                            Suspendido = reader["Suspendido"] != null ? Convert.ToInt32(reader["Suspendido"]) : 0
                        });
                    }
                }

            } catch (Exception ex)
            {
                throw ex;
            }

            return productos;
        }

        public void Insertar(Productos producto)
        {
            SqlParameter[] parameters = null;
            string commandText = string.Empty;

            try
            {
                commandText = "USP_InsProductoLab";
                parameters = new SqlParameter[3];
                parameters[0] = new SqlParameter("@nombreproducto", SqlDbType.VarChar);
                parameters[0].Value = producto.NombreProducto;
                parameters[1] = new SqlParameter("@preciounidad", SqlDbType.Decimal);
                parameters[1].Value = producto.PrecioUnidad;
                parameters[2] = new SqlParameter("@suspendido", SqlDbType.Int);
                parameters[2].Value = producto.Suspendido;
                SQLHelper.ExecuteNonQuery(SQLHelper.Connection, commandText, CommandType.StoredProcedure, parameters);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Actualizar(Productos producto)
        {
            SqlParameter[] parameters = null;
            string commandText = string.Empty;

            try
            {
                commandText = "USP_UpdProductosLab";
                parameters = new SqlParameter[4];
                parameters[0] = new SqlParameter("@idproducto", SqlDbType.Int);
                parameters[0].Value = producto.IdProducto;
                parameters[1] = new SqlParameter("@nombreproducto", SqlDbType.VarChar);
                parameters[1].Value = producto.NombreProducto;
                parameters[2] = new SqlParameter("@preciounidad", SqlDbType.Decimal);
                parameters[2].Value = producto.PrecioUnidad;
                parameters[3] = new SqlParameter("@suspendido", SqlDbType.Int);
                parameters[3].Value = producto.Suspendido;
                SQLHelper.ExecuteNonQuery(SQLHelper.Connection, commandText, CommandType.StoredProcedure, parameters);
            } catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Eliminar(int IdProducto)
        {
            SqlParameter[] parameters = null;
            string commandText = string.Empty;

            try
            {
                commandText = "USP_DelProductoLab";
                parameters = new SqlParameter[1];
                parameters[0] = new SqlParameter("@idproducto", SqlDbType.Int);
                parameters[0].Value = IdProducto;
                SQLHelper.ExecuteNonQuery(SQLHelper.Connection, commandText, CommandType.StoredProcedure, parameters);
            } catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
