using GHMNUNIDADDECAPACITACION.Models;
using OfficeOpenXml;
using Rotativa;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;


namespace GHMNUNIDADDECAPACITACION.Controllers
{
   [Authorize]
    public class UnidadCapacitacionController : Controller
    {
        private GHUContext db = new GHUContext();

        // GET: UnidadCapacitacion
        public ActionResult UnidadCapacitacion()
        {
            using (GHUContext db = new GHUContext())
            {
                ViewBag.filial = new List<SelectListItem>(db.Filiales.Select(l => new SelectListItem
                { Value = l.Descripcion.ToString(), Text = l.Descripcion }));

                ViewBag.dpto = new List<SelectListItem>(db.Departamento.Select(l => new SelectListItem
                { Value = l.IdDepartamentoss.ToString(), Text = l.Descripcion  }));


                ViewBag.result = db.UnidaddeCaptacion.OrderByDescending(x => x.idUnidaddeCaptacion).Take(250).ToList();
            }
            return View();
        }

        // GET: UnidadCapacitacion/Details/5
        public ActionResult ReporteCapacitacion()
        {
            using (GHUContext db = new GHUContext())
            {
                

                ViewBag.result = db.UnidaddeCaptacion.OrderBy(x => x.filial).ThenByDescending(x => x.Region).Take(250).ToList();

                return new ViewAsPdf("ReporteCapacitacion", ViewBag.result = db.UnidaddeCaptacion.OrderByDescending(x => x.idUnidaddeCaptacion).Take(250).ToList());
            }
            

        }


        public void ExportListUsingEPPlus()
        {
           
            using (GHUContext db = new GHUContext())
            {


                var exportexc = db.UnidaddeCaptacion.OrderBy(x => x.filial).ThenByDescending(x => x.Region).Take(250).ToList();

            

            ExcelPackage excel = new ExcelPackage();
            var workSheet = excel.Workbook.Worksheets.Add("Sheet1");
            workSheet.Cells[1, 1].LoadFromCollection(exportexc, true);
            using (var memoryStream = new MemoryStream())
            {
                Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                //here i have set filname as Students.xlsx
                Response.AddHeader("content-disposition", "attachment;  filename=Reporte.xlsx");
                excel.SaveAs(memoryStream);
                memoryStream.WriteTo(Response.OutputStream);
                Response.Flush();
                Response.End();
            }
            }
        }

        // GET: UnidadCapacitacion/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UnidadCapacitacion/Create
        [HttpPost]
        public ActionResult UnidadCapacitacion(string Descripcion, string Departamento,string Administrador,
               string nombrearea, DateTime? Fecha, string cantidadempleado,string cursorequerido, 
               string importancia,string puestoempleado,int IdDepartamentoss,string Region
            )
        {
                // TODO: Add insert logic here
                using (GHUContext db =  new GHUContext() )
                {
                    var dpto = db.Departamento.Where(x => x.IdDepartamentoss == IdDepartamentoss).FirstOrDefault();

                    var UnidaddeCaptacion = new UnidaddeCaptacion();
                    UnidaddeCaptacion.filial = ( Descripcion);
                    UnidaddeCaptacion.departamento = Departamento;
                    UnidaddeCaptacion.fechasolicitud = Fecha;
                    UnidaddeCaptacion.Areadepartamento = nombrearea;
                    UnidaddeCaptacion.cursorequerido = cursorequerido;
                    UnidaddeCaptacion.cantidadempleados = Convert.ToInt32(cantidadempleado);
                    UnidaddeCaptacion.fechacreacion = DateTime.Now;
                    UnidaddeCaptacion.importanciacurso = importancia;
                    UnidaddeCaptacion.puestoempleado = puestoempleado;
                    UnidaddeCaptacion.departamento = dpto.Descripcion;
                    UnidaddeCaptacion.Region = Region;

                    db.UnidaddeCaptacion.Add(UnidaddeCaptacion);
                    db.SaveChanges();

                    ViewBag.messs = "ok";



                    return PartialView("_UC");

                }
          
            
            
            
        }

        public JsonResult GetbyID(int idUnidaddeCaptacion)
        {
            using (GHUContext db = new GHUContext())
            {
                var result = db.UnidaddeCaptacion.Where( x => x.idUnidaddeCaptacion.Equals(idUnidaddeCaptacion)) ;
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            
        }

        
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UnidaddeCaptacion unidaddeCaptacion = db.UnidaddeCaptacion.Find(id);
            if (unidaddeCaptacion == null)
            {
                return HttpNotFound();
            }
            return View(unidaddeCaptacion);
        }

        // POST: UnidaddeCaptacions/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idUnidaddeCaptacion,filial,departamento,puestoempleado,fechasolicitud,Areadepartamento,cursorequerido,importanciacurso,cantidadempleados,fechacreacion,estadosolicitud,usuariocreacion,Region")] UnidaddeCaptacion unidaddeCaptacion)
        {
            if (ModelState.IsValid)
            {
                

               

                db.Entry(unidaddeCaptacion).State = EntityState.Modified;
             
               
                db.SaveChanges();
                return RedirectToAction("UnidadCapacitacion");
            }
            return View();
        }


        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UnidaddeCaptacion unidaddeCaptacion = db.UnidaddeCaptacion.Find(id);
            if (unidaddeCaptacion == null)
            {
                return HttpNotFound();
            }
            return View(unidaddeCaptacion);
        }

        // POST: UnidaddeCaptacions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UnidaddeCaptacion unidaddeCaptacion = db.UnidaddeCaptacion.Find(id);
            db.UnidaddeCaptacion.Remove(unidaddeCaptacion);
            db.SaveChanges();
            return RedirectToAction("UnidadCapacitacion");
        }

        //private readonly int _RegistrosPorPagina = 10;

        //private GHUContext _DbContext;
        //private List<UnidaddeCaptacion> _Customers;
        //private PaginadorGenerico<UnidaddeCaptacion> _PaginadorCustomers;

        // GET: Customers
        //public ActionResult UnidadCapacitacion(int pagina = 1)
        //{
        //    int _TotalRegistros = 0;
        //    using (_DbContext = new GHUContext())
        //    {
        //        // Número total de registros de la tabla Customers
        //        _TotalRegistros = _DbContext.UnidaddeCaptacion.Count();
        //        // Obtenemos la 'página de registros' de la tabla Customers
        //        _Customers = _DbContext.UnidaddeCaptacion.OrderBy(x => x.filial)
        //                                         .Skip((pagina - 1) * _RegistrosPorPagina)
        //                                         .Take(_RegistrosPorPagina)
        //                                         .ToList();
        //        // Número total de páginas de la tabla Customers
        //        var _TotalPaginas = (int)Math.Ceiling((double)_TotalRegistros / _RegistrosPorPagina);
        //        // Instanciamos la 'Clase de paginación' y asignamos los nuevos valores
        //        _PaginadorCustomers = new PaginadorGenerico<UnidaddeCaptacion>()
        //        {
        //            RegistrosPorPagina = _RegistrosPorPagina,
        //            TotalRegistros = _TotalRegistros,
        //            TotalPaginas = _TotalPaginas,
        //            PaginaActual = pagina,
        //            Resultado = _Customers
        //        };
        //        // Enviamos a la Vista la 'Clase de paginación'
        //        return View(_PaginadorCustomers);
        //    }
        //}

    }
}
