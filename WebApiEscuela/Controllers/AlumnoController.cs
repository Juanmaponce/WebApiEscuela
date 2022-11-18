using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using WebApiEscuela.Data;
using WebApiEscuela.Models;

namespace WebApiEscuela.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlumnoController : ControllerBase
    {
        public AlumnoController(DBEscuelaAPIContext context)
        {
            Context = context;
        }

        public DBEscuelaAPIContext Context { get; set; }

        [HttpGet]
        public List<Alumno> Get()
        {
            //EF
            List<Alumno> alumnos = Context.Alumnos.ToList();
            return alumnos;
        }
        [HttpGet("{id}")]
        public Alumno Get(int id)
        {
            //EF
            Alumno alumno = Context.Alumnos.Find(id);

            return alumno;
        }
        [HttpPost]
        public ActionResult Post(Alumno alumno)
        {
            //EF -- memoria
            Context.Alumnos.Add(alumno);
            //EF - Guardar en la DB
            Context.SaveChanges();

            return Ok();
        }
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Alumno alumno)
        {
            if (id != alumno.Id)
            {
                return BadRequest();
            }

            //EF para modificar en la DB
            Context.Entry(alumno).State = EntityState.Modified;
            Context.SaveChanges();

            return NoContent();
        }
        [HttpDelete("{id}")]
        public ActionResult<Alumno> Delete(int id)
        {
            //EF
            var alumno = Context.Alumnos.Find(id);

            if (alumno == null)
            {
                return NotFound();
            }

            //EF
            Context.Alumnos.Remove(alumno);
            Context.SaveChanges();

            return  alumno;

        }
    }
}
