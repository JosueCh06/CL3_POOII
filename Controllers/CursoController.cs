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
    public class CursoController : Controller
    {
        SqlConnection cn = new SqlConnection(
            ConfigurationManager.ConnectionStrings["CNX"].ConnectionString);

        
        // Lista para dropDownList
        List<tarifa> tarifas()
        {
            List<tarifa> temporal = new List<tarifa>();
            SqlCommand cmd = new SqlCommand("ListarTarifa", cn);
            cn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                tarifa reg = new tarifa
                {
                    idTarifa = dr.GetString(0),
                    descrip = dr.GetString(1)
                };
                temporal.Add(reg);
            }
            dr.Close();
            cn.Close();
            return temporal;
        }

        // Metodo Get
        public ActionResult Create()
        {
            ViewBag.tarifa = new SelectList(tarifas(),"idTarifa", "descrip"); 
            return View(new curso());
        }

        // Metodo POST
        [HttpPost]
        public ActionResult Create(curso reg)
        {
            if (!ModelState.IsValid)
            {
                return View(reg);
            }
            ViewBag.mensaje = " ";
            cn.Open();
            SqlTransaction tr = cn.BeginTransaction(IsolationLevel.Serializable);
            try
            {
                SqlCommand cmd = new SqlCommand("IngresarCurso", cn, tr);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idCurso", reg.idCur);
                cmd.Parameters.AddWithValue("@idTarifa", reg.idTar);
                cmd.Parameters.AddWithValue("@NombCurso", reg.NomCur);
                int q = cmd.ExecuteNonQuery();
                tr.Commit();
                ViewBag.mensaje = q.ToString() + "Curso agregado...";
            }
            catch (SqlException ex)
            {
                ViewBag.mensaje = ex.Message;
                tr.Rollback();
            }
            finally
            {
                cn.Close();
            }
            ViewBag.tarifa = new SelectList(tarifas(),"idTarifa", "descrip", reg.idTar);
            return View(reg);
            }
    }
}