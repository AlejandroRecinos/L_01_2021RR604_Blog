using L_01_2021RR604.Modelos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace L_01_2021RR604.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalificacionesController : ControllerBase
    {
        private readonly BlogContext _blogContext;
        public CalificacionesController(BlogContext blogContext)
        {
            _blogContext = blogContext;
        }
        [HttpGet]
        [Route("GetAll")]
        public IActionResult Get()
        {

            List<calificaciones> calificaciones = (from e in _blogContext.Calificaciones select e).ToList();
            if (calificaciones.Count == 0)
            {
                return NotFound();
            }
            return Ok(calificaciones);

        }
        [HttpPost]
        [Route("Add")]
        public IActionResult GuardarUsurio([FromBody] calificaciones calificaciones)
        {
            try
            {
                _blogContext.Calificaciones.Add(calificaciones);
                _blogContext.SaveChanges();
                return Ok(calificaciones);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPut]
        [Route("actualizar")]
        public IActionResult UpdateNotes(int id, [FromBody] calificaciones updatenotes)
        {
            calificaciones? Updatenotes = (from e in _blogContext.Calificaciones where e.calificacionId == id select e).FirstOrDefault();

            if (Updatenotes == null)
            { return NotFound(); }

            Updatenotes.calificacionId = updatenotes.calificacionId;
            Updatenotes.publicacionId = updatenotes.publicacionId;
            Updatenotes.usuarioId = updatenotes.usuarioId;
            Updatenotes.calificacion = updatenotes.calificacion;


            _blogContext.Entry(Updatenotes).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _blogContext.SaveChanges();

            return Ok(updatenotes);
        }

    }