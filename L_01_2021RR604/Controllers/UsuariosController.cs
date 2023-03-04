using L_01_2021RR604.Modelos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace L_01_2021RR604.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly BlogContext _blogContext;

        public UsuariosController(BlogContext  blogContext)
        {
            _blogContext= blogContext;
        }
        [HttpGet]
        [Route("GetAll")]
        public IActionResult Get() 
        {

            List<Usuarios> ListUser = (from e in _blogContext.Usuarios select e).ToList();
            if(ListUser.Count == 0)
            {
                return NotFound();
            }
            return Ok(ListUser);

        }
        [HttpPost]
        [Route("Add")]
        public IActionResult GuardarUsurio([FromBody] Usuarios usuarios) 
        {
            try
            {
                _blogContext.Usuarios.Add(usuarios);
                _blogContext.SaveChanges();
                return Ok(usuarios);
            }
            catch (Exception ex) 
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPut]
        [Route("actualizar")]
        public IActionResult UpdateUser(int id, [FromBody] Usuarios UserUpdate) 
        {
            Usuarios? ActualUser = (from e in _blogContext.Usuarios where e.usuarioId== id select e).FirstOrDefault();

            if(ActualUser == null)
            { return NotFound(); }

            ActualUser.nombreUsuario = UserUpdate.nombreUsuario;
            ActualUser.clave = UserUpdate.clave;
            ActualUser.nombre = UserUpdate.nombre;
            ActualUser.apellido = UserUpdate.apellido;

            _blogContext.Entry(ActualUser).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _blogContext.SaveChanges();

            return Ok(UserUpdate);
        }

        [HttpDelete]
        [Route("Eliminar")]
        public IActionResult DeleteUser(int id) 
        {

            Usuarios? usuarios = (from e in _blogContext.Usuarios
                                  where e.usuarioId == id
                                  select e).FirstOrDefault();
            if(usuarios == null)
            { return NotFound(); }

            _blogContext.Usuarios.Attach(usuarios);
            _blogContext.Usuarios.Remove(usuarios);
            _blogContext.SaveChanges();

            return Ok();

        }

        [HttpGet]
        [Route("GetByID/{Id}")]
        public IActionResult Get(int Id)
        {
            Usuarios? user = (from e in _blogContext.Usuarios
                              where e.rolId == Id
                              select e).FirstOrDefault();
            if (user == null) 
            { return NotFound();}
            return Ok(user);

        }
        [HttpGet]
        [Route("Find/{Filtro}")]
        public IActionResult FindByDescripcion(string filtor)
        {
            Usuarios? user = (from e in _blogContext.Usuarios
                              where e.nombre.Contains(filtor) || e.apellido.Contains(filtor)
                              select e).FirstOrDefault();
            if (user == null)
            { return NotFound(); }
            return Ok(user);

        }

    }
}
