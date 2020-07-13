using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PruebaNetCore.Model;

namespace PruebaNetCore.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonController : ControllerBase
    {
        private readonly ILogger<PersonController> _logger;
        private readonly PersonDbContext _context;

        public PersonController(ILogger<PersonController> logger, PersonDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        /* Metodo para consultaar las personas */
        [HttpGet]
        [Route("getPersons")]
        public ActionResult<IEnumerable<string>> getPersons()
        {
            try
            {
                var persons = _context.Persons.ToList();
                return Ok(persons);
            }
            catch (Exception ex) {
                Console.WriteLine("Excepcion ... " + ex.ToString());
                return BadRequest("Error");
            }
        }

        /* Metodo para guardar a la persona */
        [HttpPost]
        [Route("savePerson")]
        [AllowAnonymous]
        public IActionResult savePerson([FromForm] Person person)
        {
            try
            {
                _context.Persons.Add(person);
                // Saves changes
                _context.SaveChanges();
                return Ok(person);
            }
            catch(Exception ex)
            {
                Console.WriteLine("Excepcion ... " + ex.ToString());
                return BadRequest("Error");
            }
        }


        /* Metodo para guardar a la persona */
        [HttpPost]
        [Route("deletePerson")]
        [AllowAnonymous]
        public IActionResult deletePerson([FromForm] Person person)
        {
            try
            {
                _context.Persons.Remove(person);
                // Saves changes
                _context.SaveChanges();
                return Ok(person);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Excepcion ... " + ex.ToString());
                return BadRequest("Error");
            }
        }



        /* Metodo para guardar a la persona */
        [HttpPost]
        [Route("updatePerson")]
        [AllowAnonymous]
        public IActionResult updatePerson([FromForm] Person person)
        {
            try
            {
                _context.Persons.Update(person);
                // Saves changes
                _context.SaveChanges();
                return Ok(person);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Excepcion ... " + ex.ToString());
                return BadRequest("Error");
            }
        }

    }
}
