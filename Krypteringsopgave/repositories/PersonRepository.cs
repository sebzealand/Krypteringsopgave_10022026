using System;
using System.IO;
using System.Threading.Tasks;
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
    
    public async Task<List<Person>> GetAllAsync() => await LoadAsync();
}
