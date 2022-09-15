using Microsoft.AspNetCore.Mvc;
using PersonService.Data;
using PersonService.Repositories;

namespace PersonService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonsController : ControllerBase
    {
        private readonly ILogger<PersonsController> _logger;
        private readonly IPersonRepository _personRepository;
        public PersonsController(ILogger<PersonsController> logger, IPersonRepository movieRepositoryFactory)
        {
            _logger = logger;
            _personRepository = movieRepositoryFactory;
        }

        [HttpGet]
        public IEnumerable<Person> GetAll() => _personRepository.ReadAll();

        [HttpGet]
        [Route("{id:int}")]
        public Person Get(int id) => _personRepository.ReadById(id);

        [HttpPost]
        public void Add(Person person) => _personRepository.Create(person);

        [HttpDelete]
        [Route("{id:int}")]
        public void DeleteById(int id) => _personRepository.DeleteById(id);

        [HttpPut]
        [Route("{id:int}")]
        public void UpdateById(int id, Person person) => _personRepository.UpdateById(id, person);
    }
}