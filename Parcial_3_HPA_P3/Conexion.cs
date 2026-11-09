using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parcial_3_HPA_P3
{
    public class Conexion
    {
    private readonly string connectionString = "Server=localhost;Database=Parcial3;Uid=root;Pwd=leonelM2005;";
        public MySqlConnection ObtenerConexion()
        {
            try
            {
                MySqlConnection conexion = new MySqlConnection(connectionString);
                return conexion;
            }
            catch (Exception ex)
            {
                throw new Exception("Error de conexión: " + ex.Message);
            }
        }
    }
}
