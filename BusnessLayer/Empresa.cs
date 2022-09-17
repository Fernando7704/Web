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
        public static ML.Result GetById(int IdDepartamento)
        {
            ML.Result result = new ML.Result();
            try
            {
                using(MySqlConnection con = new MySqlConnection(Conexion.Connection.Conexion()))
                {
                    con.Open();
                    string sql = "SELECT * FROM empresa WHERE IdEmpresa=" + IdDepartamento;
                    MySqlCommand cmd = new MySqlCommand(sql,con);
                    MySqlDataReader dr = cmd.ExecuteReader();
                    DataTable dt = new DataTable();
                    dt.Load(dr);
                    if (dt.Rows.Count > 0)
                    {
                        DataRow drw = dt.Rows[0];
                        ML.Empresa empresa = new ML.Empresa();
                        empresa.IdEmpresa = Convert.ToInt16(drw["IdEmpresa"]);
                        empresa.RazonSocial = drw["RazonSocial"].ToString();
                        empresa.Estatus = Convert.ToInt16(drw["Estatus"]);
                        result.Object = empresa;
                        result.result = true;
                        result.ErrorMessage = "Consulta Éxitosa";

                    }
                    else
                    {
                        result.ErrorMessage = "No se encuentra disponible ese Id";
                        result.result = false;
                    }
                }

            }catch(Exception ex)
            {
                result.ErrorMessage = ex.Message;
                result.result = false;
            }


            return result;

        }
        public static ML.Result Delete(int IdDepartamento)
        {
            ML.Result result = new ML.Result();
            try
            {
                using(MySqlConnection con = new MySqlConnection(Conexion.Connection.Conexion()))
                {
                    con.Open();
                    //string sql = "INSERT INTO empresa(RazonSocial,Estatus) VALUES('"+""+","+1+")";
                    string sql = "DELETE FROM empresa WHERE IdEmpresa="+IdDepartamento;
                    MySqlCommand cmd = new MySqlCommand(sql, con);
                    int row = cmd.ExecuteNonQuery();
                    if (row > 0)
                    {
                        result.ErrorMessage = "Se ha eliminado correctamente";
                        result.result = true;
                    }
                }

            }catch(Exception ex)
            {
                result.ErrorMessage = ex.Message;
                result.result = false;

            }
            return result;
        }
        public static ML.Result Agregar(ML.Empresa empresa)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (MySqlConnection con = new MySqlConnection(Conexion.Connection.Conexion()))
                {
                    con.Open();
                    string sql = "INSERT INTO empresa(RazonSocial,Estatus) VALUES('"+empresa.RazonSocial+"',"+empresa.Estatus+")";
                    MySqlCommand cmd = new MySqlCommand(sql, con);
                    int row = cmd.ExecuteNonQuery();
                    if (row > 0)
                    {
                        result.ErrorMessage = "Se ha insertado correctamente";
                        result.result = true;
                    }
                }

            }
            catch (Exception ex)
            {
                result.ErrorMessage = ex.Message;
                result.result = false;

            }
            return result;
        }
        public static ML.Result Actualizar(ML.Empresa empresa)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (MySqlConnection con = new MySqlConnection(Conexion.Connection.Conexion()))
                {
                    con.Open();
                    string sql = "UPDATE empresa SET RazonSocial='"+empresa.RazonSocial+"',Estatus="+empresa.Estatus+" WHERE IdEmpresa="+ empresa.IdEmpresa;
                    MySqlCommand cmd = new MySqlCommand(sql, con);
                    int row = cmd.ExecuteNonQuery();
                    if (row > 0)
                    {
                        result.ErrorMessage = "Se ha actualizado correctamente";
                        result.result = true;
                    }
                }

            }
            catch (Exception ex)
            {
                result.ErrorMessage = ex.Message;
                result.result = false;

            }
            return result;
        }
    }
}
