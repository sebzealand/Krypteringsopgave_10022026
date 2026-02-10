using Krypteringsopgaver.repositories;

namespace Krypteringsopgaver.Test;

public class UnitTests
{
    [Fact]
    public void Test1()
    {
        var dpPath = Path.Combine(AppContext.BaseDirectory, "data", "flat_file_db.json");
        PersonRepository repo = new PersonRepository(dpPath);
        
        var persons = repo.GetAllAsync();
        
        Assert.True(persons.Result.Count > 0);
    }
}