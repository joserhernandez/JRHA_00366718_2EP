using System.Collections.Generic;
using System;
using System.Data;

namespace Parcial_02
{
    public static class ProductoDAO
    {
        public static List<Producto> getlista(int id)
        {
            var productos = ConnectionDB.ExecuteQuery("SELECT p.idProduct, p.name FROM PRODUCT p "+
                                                       $"WHERE idBusiness = {id}");
            var lista = new List<Producto>();

            foreach (DataRow dr in productos.Rows)
            {
                Producto p = new Producto();
                p.idProduct = Convert.ToInt32(dr[0].ToString());
                p.name = dr[1].ToString();
                
                lista.Add(p);
            }
            return lista;
        }
        
        public static void crearNuevo(int id, string nombre)
        {
            string nonQuery = String.Format("INSERT INTO product(idBusiness, name) " +
                                            $"VALUES({id}, '{nombre}')");

            ConnectionDB.ExecuteNonQuery(nonQuery);
        }
        
        public static void eliminar(int id)
        {
            string nonQuery = String.Format($"DELETE FROM product WHERE idProduct = {id}");

            ConnectionDB.ExecuteNonQuery(nonQuery);
        }
    }
}