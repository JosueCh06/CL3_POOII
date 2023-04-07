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
    public class ReportesController : Controller
    {
        SqlConnection cn = new SqlConnection(
            ConfigurationManager.ConnectionStrings["CNX"].ConnectionString);

        List<reporte> ReporteXAño(int year)
        {
            List<reporte> temporal = new List<reporte>();

            SqlCommand cmd = new SqlCommand("Proc_Listar_Matriculas", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@año", year);

            cn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                reporte reg = new reporte
                {
                    idAlum = dr.GetString(0),
                    ApeAlum = dr.GetString(1),
                    NombAlum = dr.GetString(2),
                    ExParcial = dr.GetDecimal(3),
                    ExFinal = dr.GetDecimal(4),
                    Prom = dr.GetDecimal(5)
                };
                temporal.Add(reg);
            }
            dr.Close();
            cn.Close();
            return temporal;
        }
        public ActionResult Reportes(int ? y=0)
        {
            ViewBag.y = y;
            return View(ReporteXAño((int)y));
        }
    }
}