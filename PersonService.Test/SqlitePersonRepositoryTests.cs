using PersonService.Controllers;
using PersonService.Data;
using PersonService.Repositories;

namespace PersonService.Test
{
    [TestFixture]
    public class SqlitePersonRepositoryTests
    {
        private SqlitePersonRepository _sqlitePersonRepository;

        [OneTimeSetUp]
        public void Setup()
        {
            _sqlitePersonRepository = new SqlitePersonRepository(new SqliteDbContext());
        }
    }
}
