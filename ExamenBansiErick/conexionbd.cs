using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenBansiErick
{
    public class conexionbd
    {
        string cadena = "Data Source=DESKTOP-1GBNJ6E;Initial Catalog=Prueba1;Persist Security Info=True;User ID=sa;Password=#AdminArce;Encrypt=False;TrustServerCertificate=True";
        public SqlConnection conectarbd = new SqlConnection();
        public conexionbd()
        {
            conectarbd.ConnectionString = cadena;
        }
        public void abrir()
        {
            try
            {
                conectarbd.Open();
                Console.WriteLine("Conexion abierta");
            }catch (Exception ex)
            {
                Console.WriteLine("Error al abrir la BD"+ex.Message);
            }
        }
        public void cerrar()
        {
            conectarbd.Close();
        }
    }
}
