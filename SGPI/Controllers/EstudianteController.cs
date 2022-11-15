using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SGPI.Models;

namespace SGPI.Controllers
{
    public class EstudianteController : Controller
    {

        BDSGPIContext context = new BDSGPIContext();
        public IActionResult ActualizarEstudiante(int? IdUsuario)
        {


            Usuario usuario = context.Usuarios.Find(IdUsuario);

            if (usuario != null)
            {
                ViewBag.genero = context.Generos.ToList();
                ViewBag.documento = context.Documentos.ToList();
                ViewBag.programa = context.Programas.ToList();
                return View(usuario);
            }
            else
            {
                return Redirect("/Estudiante/ActualizarEstudiante");
            }


        }

        [HttpPost]
        public IActionResult ActualizarEstudiante(Usuario user)
        {

            var usuarioActualizar = context.Usuarios
                .Where(consulta => consulta.Idusuario == user.Idusuario).FirstOrDefault();

            usuarioActualizar.Iddoc = user.Iddoc;
            usuarioActualizar.NumeroDocumento = user.NumeroDocumento;
            usuarioActualizar.Idgenero = user.Idgenero;
            usuarioActualizar.PrimerNombre = user.PrimerNombre;
            usuarioActualizar.PrimerApellido = user.PrimerApellido;
            usuarioActualizar.SegundoApellido = user.SegundoApellido;
            usuarioActualizar.Email = user.Email;
            usuarioActualizar.Idprograma = user.Idprograma;     
            
            context.Update(usuarioActualizar);
            context.SaveChanges();
            return Redirect("/Estudiante/ActualizarEstudiante/?Idusuario=" + usuarioActualizar.Idusuario);
        }


        public IActionResult Pagos(int? IdUsuario)
        {
            Usuario usuario = new Usuario();
            var usr = context.Usuarios.Where(consulta => consulta.Idusuario == IdUsuario).FirstOrDefault();
            ViewBag.idusuario = usr.Idusuario;
           
            return View();
        }

        [HttpPost]
        public IActionResult Pagos(int? IdUsuario, Pago usr)
        {
            Usuario user = context.Usuarios.Find(IdUsuario);


            context.Pagos.Add(usr);
            context.SaveChanges();

            Estudiante est = new Estudiante();
            est.Idestudiante = usr.Idpago;
            est.Archivo = null;
            est.Idusuario = user.Idusuario;
            est.Idpago = usr.Idpago;
            est.Egresado = true;

            
            context.Estudiantes.Add(est);
            context.SaveChanges();

            Usuario usuario = new Usuario();
            var usrc = context.Usuarios.Where(consulta => consulta.Idusuario == IdUsuario).FirstOrDefault();
            ViewBag.idusuario = usrc.Idusuario;

         

            return View();
        }
    }
}
