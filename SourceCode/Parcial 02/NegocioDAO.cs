using System;
using System.Collections.Generic;
using System.Data;

namespace Parcial_02
{
    public static class NegocioDAO
    {
        public static List<Negocio> getlista()
        {
            var negocios = ConnectionDB.ExecuteQuery("SELECT * FROM business");
            var lista = new List<Negocio>();

            foreach (DataRow dr in negocios.Rows)
            {
                Negocio n = new Negocio();
                n.idBusiness = Convert.ToInt32(dr[0].ToString());
                n.name = dr[1].ToString();
                n.description = dr[2].ToString();
               
                lista.Add(n);
            }
            return lista;
        }
        
        public static void crearNuevo(string nombre, string descripcion)
        {
            string nonQuery = String.Format("INSERT INTO business(name, description) " +
                                            $"VALUES('{nombre}', '{descripcion}')");

            ConnectionDB.ExecuteNonQuery(nonQuery);
        }
        
        public static void eliminar(int id)
        {
            string nonQuery = String.Format($"DELETE FROM business WHERE idBusiness = {id};");
                                            
            ConnectionDB.ExecuteNonQuery(nonQuery);
        }
    }
}