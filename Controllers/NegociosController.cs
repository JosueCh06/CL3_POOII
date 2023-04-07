using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
// Importamos Librerias
using CL3_POOII_JosueDanielChupicaInga.Models;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace CL3_POOII_JosueDanielChupicaInga.Controllers
{
    public class NegociosController : Controller
    {
        SqlConnection cn = new SqlConnection(
            ConfigurationManager.ConnectionStrings["CNX"].ConnectionString);

        List<Matricula> matriculas(String FechaInicial, String FechaFinal)
        {

            List<Matricula> temporal = new List<Matricula>();
            SqlCommand cmd = new SqlCommand("ListarMatriculasXIntervaloDeAños", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@fechainicial", FechaInicial);
            cmd.Parameters.AddWithValue("@fechafinal", FechaFinal);
            cn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Matricula reg = new Matricula
                {
                    IdAlum = dr.GetString(0),
                    ApeAlum = dr.GetString(1),
                    NomAlum = dr.GetString(2),
                    DirAlum = dr.GetString(3),
                    TelAlum = dr.GetString(4),
                    EmailAlum = dr.GetString(5),
                    ClavelAlum = dr.GetString(6)
                };
                temporal.Add(reg);
            }
            dr.Close();
            cn.Open();
            return temporal;
        }


        public ActionResult VistaConsulta()
        {
            return View();
        }
    }
}