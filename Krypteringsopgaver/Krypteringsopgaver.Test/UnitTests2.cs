using Krypteringsopgaver.models;
using Krypteringsopgaver.repositories;

namespace Krypteringsopgaver.Test;

public class UnitTests2
{
    private readonly PersonRepository _repo;

    public UnitTests2()
    {
        var dbPath = Path.Combine(AppContext.BaseDirectory, "data", "flat_file_db.json");
        _repo = new PersonRepository(dbPath);
    }
    [Fact]
    public async Task CreatePerson()
    {
        //Given
        Person newPerson = new Person
        {
            First_name="John",
            Last_name="Smith",
            Adress="Somewhere",
            Street_number="69",
            Password="Secret",
            Enabled=false
        };
        //when
        await _repo.CreatePerson(newPerson);
        //then
        List<Person> persons = await _repo.GetAllAsync();
        Assert.Equal(newPerson, persons.Last());
    }
    
    [Fact]
    public async Task CreatePersonFail()
    {
        
    }

}