using apicrud.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace apicrud.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {

        [HttpGet]
        public IActionResult GetAllUsers()
        {
            using (var context = new UsuarioContext())
            {
                return Ok(context.Usuarios.ToList());
            }   
        }

        [HttpPost]
        public IActionResult InsertUser(Usuario user)
        {
            using (var context = new UsuarioContext())
            {
                context.Usuarios.Add(user);
                context.SaveChanges();
                return Ok("Usuario agregado");
            }
        }
        [HttpPut]
        public IActionResult UpDateUser(Usuario user) 
        {
            using (var context = new UsuarioContext()) 
            {
                var UserResult = context.Usuarios.Where(a => a.Id == user.Id).FirstOrDefault();
                UserResult.Nombre = user.Nombre;
                UserResult.Apellido = user.Apellido;
                UserResult.Correo = user.Correo;
                context.SaveChanges();
                return Ok();
            }
        
        }

        [HttpDelete]
        public IActionResult DeleteUser(int id)
        {
            using (var context = new UsuarioContext())
            {
                var user = context.Usuarios.Where(a => a.Id == id).FirstOrDefault();
                context.Usuarios.Remove(user);
                context.SaveChanges();
                return Ok("Usuario ELiminado");
            }
        }

    }
}
