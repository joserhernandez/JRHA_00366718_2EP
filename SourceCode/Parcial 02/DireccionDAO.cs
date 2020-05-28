using System.Collections.Generic;
using System;
using System.Data;

namespace Parcial_02
{
    public static class DireccionDAO
    {
        public static List<Direccion> getlista(int id)
        {
            var direcciones = ConnectionDB.ExecuteQuery("SELECT ad.idAddress, ad.address " +
                                                     $"FROM ADDRESS ad WHERE idUser = {id}");
            var lista = new List<Direccion>();

            foreach (DataRow dr in direcciones.Rows)
            {
                Direccion d = new Direccion();
                d.idAddress = Convert.ToInt32(dr[0].ToString());
                d.address = dr[1].ToString();
                d.idUser = id;
                
                lista.Add(d);
            }
            return lista;
        }
        
        public static void crearNuevo(int id, string direccion)
        {
            string nonQuery = String.Format("INSERT INTO address(idUser, address) " +
                                            $"VALUES({id}, '{direccion}')");

            ConnectionDB.ExecuteNonQuery(nonQuery);
        }
        
        public static void eliminar(int id)
        {
            string nonQuery = String.Format($"DELETE FROM address WHERE idAddress = {id};");

            ConnectionDB.ExecuteNonQuery(nonQuery);
        }
        
        public static void modificar(int id, string nueva)
        {
            string nonQuery = String.Format($"UPDATE address SET address = '{nueva}' " +
                                            $"WHERE idAddress = {id}");

            ConnectionDB.ExecuteNonQuery(nonQuery);
        }
    }
}