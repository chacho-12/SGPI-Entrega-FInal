using Microsoft.AspNetCore.Mvc;
using SGPI.Models;
using System.Security.Principal;

namespace SGPI.Controllers
{
    public class AdministradorController : Controller
    {
        BDSGPIContext context = new BDSGPIContext();
        public IActionResult Login()
        {
            //Create

            /*
            Usuario usr = new Usuario();
            usr.Idusuario = 1;
            usr.NumeroDocumento = "1000536287";
            usr.PrimerNombre = "Valentina";
            usr.SegundoNombre = String.Empty;
            usr.PrimerApellido = "Vélez";
            usr.SegundoApellido = "Duque";
            usr.Idgenero = 1;
            usr.Email = "valeveleduq@gmail.com";
            usr.Idrol = 1;
            usr.Password = "123456789";
            usr.Idprograma = 1;

            context.Add(usr);
            context.SaveChanges();*/






            //Query

            /*
        Usuario usuario = new Usuario();

        usuario = context.Usuarios
                .Single(b => b.NumeroDocumento == "123456789");

        List<Usuario> usuarios = new List<Usuario>();
        usuarios=context.Usuarios.ToList();


        //Update
        var usr = context.Usuarios
            .Where(cursor =>cursor.Idusuario==1)
            .FirstOrDefault();

        if (usr!=null)
        {
            usr.SegundoNombre = "Diego";
            usr.SegundoApellido = "camacho";

            context.Usuarios.Update(usr);
            context.SaveChanges();  



        }
             




            //Delate

            var UsuarioEliminar = context.Usuarios
                .Where(cursor => cursor.Idusuario == 1)
                .FirstOrDefault();

             */

            return View();
        }

        [HttpPost]


        public IActionResult Login(Usuario user)
        {
            string NumeroDoc = user.NumeroDocumento;
            string pass = user.Password;

            var usuarioLogin = context.Usuarios
                .Where(consulta =>
                consulta.NumeroDocumento == NumeroDoc &&
                consulta.Password == pass).FirstOrDefault();

            if (usuarioLogin != null)
            {


                //Administrador
                if (usuarioLogin.Idrol == 1)
                {
                    return Redirect("Administrador/CrearUsuario");
                }
                //Coordinador
                else if (usuarioLogin.Idrol == 2)

                {
                    CoordinadorController coordi = new CoordinadorController();
                    coordi.BuscarCoordinador();
                    return Redirect("/Coordinador/BuscarCoordinador");
                }

                //Estudiante
                else if (usuarioLogin.Idrol == 3)
                {
                    EstudianteController estudi = new EstudianteController();
                    //estudi.ActualizarEstudiante();
                    return Redirect("/Estudiante/ActualizarEstudiante/?Idusuario=" +usuarioLogin.Idusuario);
                }
                //no existe este rol
                else { }
            }
            else
            {
                ViewBag.mensaje = "Usuario no existe" +
                     "o usuario y/o contraseña invalida";

            }
            return View();
        }


        public IActionResult OlvidarContraseña()
        {
            return View();
        }
        public IActionResult CrearUsuario()
        {
            ViewBag.genero = context.Generos.ToList();
            ViewBag.rol = context.Rols.ToList();
            ViewBag.documento = context.Documentos.ToList();
            ViewBag.programa = context.Programas.ToList();

            return View();

        }
        [HttpPost]
        public IActionResult CrearUsuario(Usuario usuario)
        {
            context.Usuarios.Add(usuario);
            context.SaveChanges();

            ViewBag.genero = context.Generos.ToList();
            ViewBag.rol = context.Rols.ToList();
            ViewBag.documento = context.Documentos.ToList();
            ViewBag.programa = context.Programas.ToList();
            ViewBag.mensaje = "Usuario Creado Exitosamente";

            return View();
        }

        public IActionResult BuscarUsuario()
        {
            Usuario us = new Usuario();
            return View();
        }
        [HttpPost]
        public IActionResult BuscarUsuario(Usuario usuario)
        {
            String NumeroDoc = usuario.NumeroDocumento;

            var user = context.Usuarios
                .Where(consulta =>
                consulta.NumeroDocumento == NumeroDoc).FirstOrDefault();

            if (user != null)
            {

                return View(user);
            }
            else
                ViewBag.mensaje = "Usuario No Encontrado, Favor Verifcar Nuevamente Los Datos";
            return View();



        }

        public IActionResult ModificarUsuario(int? IdUsuario)
        {
            Usuario usuario = context.Usuarios.Find(IdUsuario);

            if (usuario != null)
            {
                ViewBag.genero = context.Generos.ToList();
                ViewBag.rol = context.Rols.ToList();
                ViewBag.documento = context.Documentos.ToList();
                ViewBag.programa = context.Programas.ToList();
                ViewBag.mensaje = "Usuario Creado Exitosamente";
                return View(usuario);
            }

            else
            {
                return Redirect("Administrador/BuscarUsuario");
            }
        }
        [HttpPost]
        public IActionResult ModificarUsuario(Usuario user)
        {
            context.Update(user);
            context.SaveChanges();
            return Redirect("/Administrador/BuscarUsuario");
        }
        //public IActionResult ModificarUsuario(int? idusuario)
        //{
        //   Usuario usuario = context.Usuarios.Find(idusuario);
        //    if (usuario != null)
        //        return View(usuario);
        //    else
        //        return Redirect("/Administrador/BuscarUsuario");
        //}

        public IActionResult Delete(Usuario usuario)
        {
            context.Remove(usuario);
            context.SaveChanges();
            return Redirect("/Administrador/BuscarUsuario");
        }
        //public IActionResult ModificarUsuario()
        //{
        //    return View();
        //}
        public IActionResult Reportar()
        {
            return View();
        }
        public IActionResult BuscarCoordinador()
        {
            return View();
        }
    }

}


