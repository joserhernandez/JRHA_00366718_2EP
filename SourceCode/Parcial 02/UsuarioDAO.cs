using System;
using System.Collections.Generic;
using System.Data;

namespace Parcial_02
{
    public static class UsuarioDAO
    {
        public static List<Usuario> getlista()
        {
            var usuarios = ConnectionDB.ExecuteQuery("SELECT * FROM appuser");
            var lista = new List<Usuario>();

            foreach (DataRow dr in usuarios.Rows)
            {
                Usuario u = new Usuario();
                u.idUser = Convert.ToInt32(dr[0].ToString());
                u.fullName = dr[1].ToString();
                u.userName = dr[2].ToString();
                u.password = dr[3].ToString();
                u.admin = Convert.ToBoolean(dr[4].ToString());

                lista.Add(u);
            }
            return lista;
        }
        
        public static void actualizarPassword(string user, string newPassword)
        {
            string nonQuery = String.Format($"UPDATE appuser SET password = '{newPassword}' " +
                                            $"WHERE username = '{user}'");

            ConnectionDB.ExecuteNonQuery(nonQuery);
        }
        
        public static void crearNuevo(string nombre, string usuario)
        {
            string nonQuery = String.Format("INSERT INTO APPUSER(fullname, username, password, userType) " +
                                            $"VALUES('{nombre}','{usuario}','{usuario}', false)");

            ConnectionDB.ExecuteNonQuery(nonQuery);
        }
        
        public static void eliminar(int id)
        {
            string nonQuery = String.Format($"DELETE FROM appuser WHERE idUser = {id}");

            ConnectionDB.ExecuteNonQuery(nonQuery);
        }

    }
}