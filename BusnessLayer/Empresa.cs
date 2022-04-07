using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Data;

namespace BusnessLayer
{
    public class Empresa
    {
        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();
            try
            {
                using (MySqlConnection con = new MySqlConnection(Conexion.Connection.Conexion()))
                {
                    con.Open();
                    string sql = "SELECT * FROM empresa";
                    MySqlCommand cmd = new MySqlCommand(sql, con);
                    MySqlDataReader rdr = cmd.ExecuteReader();
                    DataTable dt = new DataTable();
                    dt.Load(rdr);
                    if (dt.Rows.Count > 0)
                    {
                        result.Objects = new List<object>();
                        foreach(DataRow row in dt.Rows)
                        {
                            ML.Empresa empresa = new ML.Empresa();
                            empresa.IdEmpresa = Convert.ToInt16(row["IdEmpresa"]);
                            empresa.RazonSocial = row["RazonSocial"].ToString();
                            empresa.Imagen = row["Imagen"].ToString();
                            empresa.Estatus = Convert.ToInt16(row["Estatus"]);
                            result.Objects.Add(empresa);
                        }
                        result.result = true;
                        result.ErrorMessage = "Se han consultados los datos correctamente";
                    }
                    else
                    {
                        result.result = false;
                        result.ErrorMessage = "No hay registros";
                    }


                }

            }catch(Exception ex)
            {
                result.ErrorMessage = ex.Message;
                result.result = false;
            }

            return result;
        }
    }
}
