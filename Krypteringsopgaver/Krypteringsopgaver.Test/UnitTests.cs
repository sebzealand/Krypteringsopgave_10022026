using Krypteringsopgaver.repositories;

namespace Krypteringsopgaver.Test;

public class UnitTests
{
    [Fact]
    public async Task GetById_Pass()
    {
        // Given
        var dpPath = Path.Combine(AppContext.BaseDirectory, "data", "flat_file_db.json");
        PersonRepository repo = new PersonRepository(dpPath);
        
        // When
        var person = await repo.GetById(1);
        
        // Then
        Assert.Equal(1, person.Person_id);
        Assert.Equal("John", person.First_name);
        Assert.Equal("Doe", person.Last_name);
        Assert.Equal("Somewhere", person.Adress);
        Assert.Equal("", person.Street_number);
        Assert.Equal("Test", person.Password);
        Assert.True(person.Enabled);
        
    }
}