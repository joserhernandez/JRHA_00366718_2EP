using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;

namespace Parcial_02
{
    public class OrdenesDAO
    {
        public static List<Ordenes> getlista()
        {
            var ordenes = ConnectionDB.ExecuteQuery(
                "SELECT ao.idOrder, ao.createDate, pr.name, au.fullname, ad.address " +
                "FROM APPORDER ao, ADDRESS ad, PRODUCT pr, APPUSER au " +
                "WHERE ao.idProduct = pr.idProduct " +
                "AND ao.idAddress = ad.idAddress " +
                "AND ad.idUser = au.idUser");
            var lista = new List<Ordenes>();

            foreach (DataRow dr in ordenes.Rows)
            {
                Ordenes o = new Ordenes();
                o.idOrder = Convert.ToInt32(dr[0].ToString());
                o.createDate = Convert.ToDateTime(dr[1].ToString());
                o.name = dr[2].ToString();
                o.fullName = dr[3].ToString();
                o.address = dr[4].ToString();
                
                lista.Add(o);
            }
            return lista;
        }
        
        public static List<Ordenes> ordenesDelUsuario(int id)
        {
            var ordenes = ConnectionDB.ExecuteQuery(
                                "SELECT ao.idOrder, ao.createDate, pr.name, au.fullname, ad.address " + 
                                "FROM APPORDER ao, ADDRESS ad, PRODUCT pr, APPUSER au " +
                                "WHERE ao.idProduct = pr.idProduct " +
                                "AND ao.idAddress = ad.idAddress " +
                                $"AND ad.idUser = au.idUser AND au.idUser = {id}");
            
            var lista = new List<Ordenes>();

            foreach (DataRow dr in ordenes.Rows)
            {
                Ordenes o = new Ordenes();
                o.idOrder = Convert.ToInt32(dr[0].ToString());
                o.createDate = Convert.ToDateTime(dr[1].ToString());
                o.name = dr[2].ToString();
                o.fullName = dr[3].ToString();
                o.address = dr[4].ToString();
                
                lista.Add(o);
            }
            return lista;
        }
        
        public static void crearOrden(DateTime fecha, int idP, int idA)
        {
            string f = fecha.ToShortDateString();
            string nonQuery = String.Format("INSERT INTO apporder(createDate, idProduct, idAddress) " +
                                            $"VALUES('{f}', {idP}, {idA})");

            ConnectionDB.ExecuteNonQuery(nonQuery);
        }
        
        public static void eliminar(int id)
        {
            string nonQuery = String.Format($"DELETE FROM apporder WHERE idOrder = {id};");

            ConnectionDB.ExecuteNonQuery(nonQuery);
        }
    }
}