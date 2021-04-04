using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PROYECTOSIIX.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult MiPagina()
        {
            ViewBag.Message = "Esta es mi pagina";

            return View();
        }

        // Get Consultando todos los Usuarios 
        [HttpGet]
        public JsonResult GetUsuarios()
        {
            try
            {
                using (Models.BDPruebaSIIX db = new Models.BDPruebaSIIX())
                {
                    var ObjetoUsuarios = (from d in db.Usuarios select d).ToList();
                    return Json(ObjetoUsuarios, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                return Json(ex.Message, JsonRequestBehavior.AllowGet);
            }
        }

        // Get Consutlar Usuarios por Id
        [HttpGet]
        public JsonResult ConsultaUsuariosId(int IdUsuarios)
        {
            try
            {
                using (Models.BDPruebaSIIX db = new Models.BDPruebaSIIX())
                {
                    var ObjetoUsuarios = (from d in db.Usuarios where d.IDUsuarios == IdUsuarios select d).ToList();
                    return Json(ObjetoUsuarios, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                return Json(ex.Message, JsonRequestBehavior.AllowGet);
            }
        }

        // Get Guardar Usuarios
        [HttpPost]
        public JsonResult InsertarUsuarios(Models.Usuarios usuarios)
        {
            try
            {
                using (Models.BDPruebaSIIX db = new Models.BDPruebaSIIX())
                {
                    var ObjetoUsuarios = new Models.Usuarios{
                    Apellido_Paterno = usuarios.Apellido_Paterno, 
                    Apellido_Materno = usuarios.Apellido_Materno,
                    Nombre = usuarios.Nombre,
                    Celular = usuarios.Celular,
                    CURP = usuarios.CURP,
                    Email = usuarios.Email,
                    RFC = usuarios.RFC,
                    IDUsuarios = usuarios.IDUsuarios
                    };
                    db.Usuarios.Add(ObjetoUsuarios);
                    db.SaveChanges();
                    return Json(ObjetoUsuarios, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                return Json(ex.Message, JsonRequestBehavior.AllowGet);
            }
        }

        //Get Actualizar Usuarios
        [HttpPost]
        public JsonResult ActualizarUsuarios(Models.Usuarios usuarios)
        {
            try
            {
                using (Models.BDPruebaSIIX db = new Models.BDPruebaSIIX())
                {
                    
                    var User = db.Usuarios.FirstOrDefault(x => x.IDUsuarios == usuarios.IDUsuarios);

                    if (User != null)
                    {
                        User.Apellido_Paterno = usuarios.Apellido_Paterno;
                        User.Apellido_Materno = usuarios.Apellido_Materno;
                        User.Nombre = usuarios.Nombre;
                        User.Celular = usuarios.Celular;
                        User.CURP = usuarios.CURP;
                        User.Email = usuarios.Email;
                        User.RFC = usuarios.RFC;

                        db.SaveChanges();
                        return Json(User, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json("Usuario no encontrado", JsonRequestBehavior.AllowGet);
                    }
                    
                }
            }
            catch (Exception ex)
            {
                return Json(ex.Message, JsonRequestBehavior.AllowGet);
            }
        }

        // Get Eliminar Usuarios
        [HttpPost]
        public JsonResult EliminarUsuarios(int IdUsuarios)
        {
            try
            {
                using (Models.BDPruebaSIIX db = new Models.BDPruebaSIIX())
                {

                    var Usuario = db.Usuarios.FirstOrDefault(x => x.IDUsuarios == IdUsuarios);

                    if (Usuario != null)
                    {
                        db.Usuarios.Remove(Usuario);
                        db.SaveChanges();
                        return Json(Usuario, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json("Usuario no encontrado", JsonRequestBehavior.AllowGet);
                    }
                }
            }
            catch (Exception ex)
            {
                return Json(ex.Message, JsonRequestBehavior.AllowGet);
            }
        }
    }
}