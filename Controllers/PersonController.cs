using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Zadanie3_przetwarzanie_rozproszone.Models;

namespace Zadanie3_przetwarzanie_rozproszone.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly DataContext _dataContext;
        public readonly IConfiguration _config;
        public PersonController(DataContext dataContext, IConfiguration configuration)
        {
            _config = configuration;
            _dataContext = dataContext;
        }

        [HttpGet("/persons")]
        public List<Person> GetPersons()
        {
            return _dataContext.Persons.ToList();
            //return persons;
        }

        [HttpPost("/persons/add")]
        public string AddPerson(Person person)
        {
            _dataContext.Persons.Add(person);
            _dataContext.SaveChanges();
            return "Ok";
        }

        [HttpDelete("/persons/remove")]
        public string RemovePerson(int id)
        {

            var person = _dataContext.Persons.FirstOrDefault(x => x.Id == id);
            _dataContext.Persons.Remove(person);
            _dataContext.SaveChanges();
            return "user deleted";
        }

        [HttpPut("/persons/update")]
        public IActionResult UpdatePerson(Person person)
        {
            if (person == null)
            {
                return BadRequest("Person object is null");
            }

            var existingPerson = _dataContext.Persons.FirstOrDefault(x => x.Id == person.Id);

            if (existingPerson == null)
            {
                return NotFound("Person not found");
            }

            //Aktualizacja istniejącej osoby
            existingPerson.FirstName = person.FirstName;
            existingPerson.LastName = person.LastName;
            existingPerson.Age = person.Age;

            _dataContext.Persons.Update(existingPerson);
            _dataContext.SaveChanges();

            return Ok(existingPerson);
        }

    }
}
