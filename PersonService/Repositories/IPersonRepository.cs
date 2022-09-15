using PersonService.Data;

namespace PersonService.Repositories
{
    public interface IPersonRepository
    {
        void Create(Person person);
        public IEnumerable<Person> ReadAll();
        public Person ReadById(int id);
        void UpdateById(int id, Person person);
        void DeleteById(int id);
    }
}