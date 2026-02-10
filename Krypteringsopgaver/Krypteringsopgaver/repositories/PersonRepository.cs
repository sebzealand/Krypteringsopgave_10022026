using Krypteringsopgaver.models;

namespace Krypteringsopgaver.repositories;

using Newtonsoft.Json;

public class PersonRepository
{
    private readonly string _filepath;
    
    public PersonRepository(string filepath) 
    {
        _filepath = filepath;
    }

    private async Task<List<Person>> LoadAsync() 
    {
        if (!File.Exists(_filepath))
           throw new FileNotFoundException("DB file not found!");
        
        var json = await File.ReadAllTextAsync(_filepath);
 
        return JsonConvert.DeserializeObject<List<Person>>(json) ?? throw new ArgumentException("No persons");
    }
    
    private async Task SaveAsync(List<Person> persons) => await File.WriteAllTextAsync(_filepath, JsonConvert.SerializeObject(persons));
    
    public async Task<List<Person>> GetAllAsync() => await LoadAsync();

    public async Task<Person> GetById(int id) 
    {
        var persons = await LoadAsync();
        return persons.Find(p => p.Person_id == id) ?? throw new ArgumentException("Person not found"); 
    }

    public async Task<Person> CreatePerson(Person person)
    {
        var personer = await LoadAsync();

        int nyId = personer.Any() ? personer.Max(p => p.Person_id) + 1 : 1;
        person.Person_id = nyId;
        
        personer.Add(person);
        await SaveAsync(personer);
        
        return person;
    }
}