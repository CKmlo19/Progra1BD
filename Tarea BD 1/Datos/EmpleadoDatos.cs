using System.Data.SqlClient;
using System.Data;
using Tarea_BD_1.Models;

namespace Tarea_BD_1.Datos
{
    public class EmpleadoDatos
    {
        // este metodo lista en orden alfabetico 
        public List<EmpleadoModel> Listar()
        {
            var oLista = new List<EmpleadoModel>();

            var cn = new Conexion();

            // abre la conexion
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                // el procedure de listar
                SqlCommand cmd = new SqlCommand("dbo.ListarEmpleado", conexion);
                cmd.Parameters.AddWithValue("ResultCode", 0); // se le coloca un 0 en el outresultcode
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader()) // este se utiliza cuando se retorna una gran cantidad de datos, por ejemplo la tabla completa
                {
                    // hace una lectura del procedimiento almacenado
                    while (dr.Read())
                    {
                        oLista.Add(new EmpleadoModel()
                        {
                            // tecnicamente hace un select, es por eso que se lee cada registro uno a uno que ya esta ordenado
                            Id = (int)Convert.ToInt64(dr["Id"]),
                            Nombre = dr["Nombre"].ToString(),
                            Salario = Convert.ToDecimal(dr["Salario"])
                        });
                    }
                }
            }
            return oLista;
        }

        public int Insertar(EmpleadoModel oEmpleado)
        {
            int resultado;

            try
            {
                var cn = new Conexion();

                // abre la conexion
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    // el procedure de listar
                    SqlCommand cmd = new SqlCommand("dbo.InsertarEmpleado", conexion);
                    cmd.Parameters.AddWithValue("inNombre", oEmpleado.Nombre.Trim()); // se le hace un trim a la hora de insertar
                    cmd.Parameters.AddWithValue("inSalario", oEmpleado.Salario);
                    cmd.Parameters.AddWithValue("OutResultCode", 0); // en un inicio se coloca en 0
                    cmd.CommandType = CommandType.StoredProcedure;
                    resultado = Convert.ToInt32(cmd.ExecuteScalar()); // Lo ejecuta y retorna un valor
                    Console.WriteLine(resultado);
                    // Registrar el script en la página para que se ejecute en el lado del cliente
                }
            }
            catch (Exception e)
            {
                string error = e.Message;
                resultado = 50006;

            }
            return resultado;
        }
    }
}
