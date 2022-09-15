using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using PersonService.Controllers;
using PersonService.Data;
using PersonService.Repositories;
using System.Xml.Linq;

namespace PersonService.Test
{
    [TestFixture]
    public class PersonControllerTests
    {
        private PersonsController _personController;

        [OneTimeSetUp]
        public void Setup()
        {
            _personController = new PersonsController(new Mock<ILogger<PersonsController>>().Object,
                                                        new SqlitePersonRepository(new SqliteDbContext()));
        }
    }
}