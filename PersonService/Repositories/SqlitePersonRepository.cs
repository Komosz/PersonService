using Microsoft.EntityFrameworkCore;
using PersonService.Data;

namespace PersonService.Repositories
{
    public class SqlitePersonRepository : IPersonRepository
    {
        private SqliteDbContext _context;
        public SqlitePersonRepository(SqliteDbContext context)
        {
            _context = context;
        }
        public void Create(Person person)
        {
            _context.Persons.Add(person);
            _context.SaveChanges();
        }

        public void DeleteById(int id)
        {
            var person = _context.Persons.Single(p => p.Id == id);
            _context.Persons.Remove(person);
            _context.SaveChanges();
        }

        public IEnumerable<Person> ReadAll()
        {
            return _context.Persons;
        }

        public Person ReadById(int id)
        {
            return _context.Persons.SingleOrDefault(m => m.Id == id);
        }

        public void UpdateById(int id, Person newPerson)
        {
            var person = _context.Persons.Single(p => p.Id == id);
            person.ApartmentNumber = newPerson.ApartmentNumber;
            person.DateOfBirth = newPerson.DateOfBirth;
            person.FirstName = newPerson.FirstName;
            person.HouseNumber = newPerson.HouseNumber;
            person.LastName = newPerson.LastName;
            person.PhoneNumber = newPerson.PhoneNumber;
            person.PostalCode = newPerson.PostalCode;
            person.StreetName = newPerson.StreetName;
            person.Town = newPerson.Town;
            _context.Persons.Update(person);
            //_context.Entry(person).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
