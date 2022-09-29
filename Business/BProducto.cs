using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using Data;

namespace Business
{
    public class BProducto
    {
        private DProductos DProducto = null;

        public List<Productos> Listar(int IdProducto)
        {
            List<Productos> productos = null;

            try
            {
                DProducto = new DProductos();
                productos = DProducto.Listar(new Productos { IdProducto = IdProducto });
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return productos;
        }

        public bool Insertar(Productos producto)
        {
            bool result = true;
            try
            {
                DProducto = new DProductos();
                DProducto.Insertar(producto);
            }
            catch (Exception ex)
            {
                throw ex;
                result = false;
            }
            return result;
        }

        public bool Actualizar(Productos producto)
        {
            bool result = true;
            try
            {
                DProducto = new DProductos();
                DProducto.Actualizar(producto);
            } catch (Exception ex)
            {
                result = false;
            }
            return result;
        }

        public bool Eliminar(int IdProducto)
        {
            bool result = true; 
            try
            {
                DProducto = new DProductos();
                DProducto.Eliminar(IdProducto);
            } catch (Exception ex)
            {
                result = false;
            }
            return result;
        }
    }
}
